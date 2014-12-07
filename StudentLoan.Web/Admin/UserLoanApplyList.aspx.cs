using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using System.Text;
using NPOI.XSSF.UserModel;
using System.IO;
using NPOI.SS.UserModel;
using System.Data;

namespace StudentLoan.Web.Admin
{
    public partial class UserLoanApplyList : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtStartTime.Attributes.Add("ReadOnly", "true");
                this.txtEndTime.Attributes.Add("ReadOnly", "true");

                if (!IsPostBack)
                {
                    string action = this.Request<string>("action");

                    if (action == "delete")
                    {
                        int loanId = this.Request<int>("loanId");

                        bool result = new UserLoanBLL().Delete(new UserLoanEntityEx() { LoanId = loanId });

                        this.Alert(string.Format("操作{0}", result == true ? "成功" : "失败"));
                    }

                    this.BindData();
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        protected void BindData()
        {

            string startTime = txtStartTime.Text.Trim().HtmlEncode();
            string endTime = txtEndTime.Text.Trim().HtmlEncode();
            string loanCategory = this.ddlLoanCategory.SelectedValue.HtmlEncode();
            string queryContent = this.txtQueryContent.Text.Trim().HtmlEncode();

            string strWhere = "1 = 1";

            if (!string.IsNullOrEmpty(loanCategory))
            {
                strWhere += string.Format(" and  T.ProductID = {0}", loanCategory);
            }

            if (!string.IsNullOrEmpty(this.ddlStatus.SelectedValue))
            {
                strWhere += string.Format(" and T.Status ={0} ", this.ddlStatus.SelectedValue);
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(" and T.CreateTime >='{0}'", startTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(" and T.CreateTime <='{0}'", endTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(queryContent))
            {
                int userId = new UsersBLL().GetUserId(queryContent);

                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(" and T.UserId = '{0}'", userId);
                }
                else if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(" and T.LoanNo = '{0}' ", queryContent);
                }
            }



            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserLoanEntityEx> sourceList = new UserLoanBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserLoanBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            if (endIndex > this.objAspNetPager.RecordCount)
            {
                this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            }


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="loanCategory"></param>
        /// <returns></returns>
        public string GetLoanCategoryName(int loanCategory)
        {
            string result = string.Empty;

            switch (loanCategory)
            {
                case 1:
                    result = "因为爱情（恋爱贷款）";
                    break;
                case 2:
                    result = "游山玩水（旅游贷款）";
                    break;
                case 3:
                    result = "时尚达人（购物贷款）";
                    break;
                case 4:
                    result = "追求自我（娱乐贷款）";
                    break;
                case 5:
                    result = "急人所急（应急贷款）";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取状态名称
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetStatusName(int status)
        {
            string result = string.Empty;

            switch (status)
            {
                case 0:
                    result = "<span>审核中</span>";
                    break;
                case 1:
                    result = "<span style='color:Green'>审核通过</span>";
                    break;
                case 2:
                    result = "<span style='color:#ff0000'>已拒绝</span>";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取管理员名称
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public string GetAdminName(int adminId)
        {
            string result = string.Empty;

            if (adminId == 0)
            {
                return string.Empty;
            }

            Dictionary<int, string> adminDictionary = new AdminBLL().GetAdminDictionary(" isLock = 1");

            return adminDictionary[adminId];
        }

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                UserLoanEntityEx model = e.Item.DataItem as UserLoanEntityEx;
                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                StringBuilder objSB = new StringBuilder();
                objSB.AppendFormat("<a href=\"CheckUserInfo.aspx?loanid={0}\">审核资料</a>", model.LoanId);
                objSB.AppendFormat(" | <a onclick=\"return confirm('删除后无法恢复，是否删除？');\" href=\"UserLoanApplyList.aspx?action=delete&loanId={0}\">删除</a>", model.LoanId);
                objLiteral.Text = objSB.ToString();
            }
        }

        protected void btnExport_ServerClick(object sender, EventArgs e)
        {
            string startTime = txtStartTime.Text.Trim().HtmlEncode();
            string endTime = txtEndTime.Text.Trim().HtmlEncode();
            string loanCategory = this.ddlLoanCategory.SelectedValue.HtmlEncode();
            string queryContent = this.txtQueryContent.Text.Trim().HtmlEncode();


            if (string.IsNullOrEmpty(startTime))
            {
                this.Alert("请选择起始查询日期");
                return;
            }
            if (string.IsNullOrEmpty(endTime))
            {
                this.Alert("请选择结束查询日期");
                return;
            }

            string strWhere = "1 = 1";

            if (!string.IsNullOrEmpty(loanCategory))
            {
                strWhere += string.Format(" and  T.ProductID = {0}", loanCategory);
            }

            if (!string.IsNullOrEmpty(this.ddlStatus.SelectedValue))
            {
                strWhere += string.Format(" and T.Status ={0} ", this.ddlStatus.SelectedValue);
            }
            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(" and T.CreateTime >='{0}'", startTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(" and T.CreateTime <='{0}'", endTime.Convert<DateTime>());
            }
            if (!string.IsNullOrEmpty(queryContent))
            {
                int userId = new UsersBLL().GetUserId(queryContent);

                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(" and T.UserId = '{0}'", userId);
                }
                else if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(" and T.LoanNo = '{0}' ", queryContent);
                }
            }


            List<UserLoanEntityEx> sheetAdapter = new UserLoanBLL().GetList(strWhere);

            string filename = string.Format("借款记录-{0}_{1}.xlsx", startTime, endTime);
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", filename));
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");

            for (int i = 0; i < sheetAdapter.Count; i++)
            {
                //首行
                IRow firstRow = sheet.CreateRow(0);
                firstRow.HeightInPoints = 25;
                sheet.DefaultColumnWidth = 15;


                firstRow.CreateCell(0, CellType.String).SetCellValue("借款编号");
                firstRow.CreateCell(1, CellType.String).SetCellValue("借款人");
                firstRow.CreateCell(2, CellType.String).SetCellValue("类型");
                firstRow.CreateCell(3, CellType.Numeric).SetCellValue("借款金额");
                firstRow.CreateCell(4, CellType.Numeric).SetCellValue("费率");
                firstRow.CreateCell(5, CellType.String).SetCellValue("申请时间");
                firstRow.CreateCell(6, CellType.String).SetCellValue("应还金额");
                firstRow.CreateCell(7, CellType.Numeric).SetCellValue("已还期数");
                firstRow.CreateCell(8, CellType.Numeric).SetCellValue("总期数");
                firstRow.CreateCell(9, CellType.String).SetCellValue("借款状态");
                firstRow.CreateCell(10, CellType.String).SetCellValue("管理员");
                firstRow.CreateCell(11, CellType.String).SetCellValue("通过日期");



                //居中对齐
                for (int j = 0; j <= 11; j++)
                {
                    firstRow.Cells[j].CellStyle.VerticalAlignment = VerticalAlignment.Center;
                    firstRow.Cells[j].CellStyle.Alignment = HorizontalAlignment.Center;
                }

                //冻结首行
                sheet.CreateFreezePane(0, 1);


                IRow row = sheet.CreateRow(i + 1);

                row.HeightInPoints = 25;

                row.CreateCell(0, CellType.String).SetCellValue(sheetAdapter[i].LoanNo);
                row.CreateCell(1, CellType.String).SetCellValue(string.Format("{0}/{1}", sheetAdapter[i].UserName, sheetAdapter[i].TrueName));
                row.CreateCell(2, CellType.String).SetCellValue(sheetAdapter[i].ProductName);
                row.CreateCell(3, CellType.Numeric).SetCellValue(sheetAdapter[i].LoanMoney.Convert<double>());
                row.CreateCell(4, CellType.Numeric).SetCellValue(sheetAdapter[i].AnnualFee.Convert<double>());
                row.CreateCell(5, CellType.String).SetCellValue(sheetAdapter[i].CreateTime);
                row.CreateCell(6, CellType.Numeric).SetCellValue(sheetAdapter[i].ShouldRepayMoney.Convert<double>());
                row.CreateCell(7, CellType.Numeric).SetCellValue(sheetAdapter[i].AlreadyAmortization);
                row.CreateCell(8, CellType.Numeric).SetCellValue(sheetAdapter[i].TotalAmortization);
                row.CreateCell(9, CellType.String).SetCellValue(string.Format("{0}", this.GetStatusName(sheetAdapter[i].Status)));
                row.CreateCell(10, CellType.String).SetCellValue(string.Format("{0}", sheetAdapter[i].AdminName));
                row.CreateCell(11, CellType.String).SetCellValue(string.Format("{0}", sheetAdapter[i].PassTime));


            }

            string savePath = string.Format("{0}", MapPath("~/Excels"));

            if (!Directory.Exists(savePath))
            {
                Directory.CreateDirectory(savePath);
            }

            using (var f = File.Create(string.Format("{0}/{1}", MapPath("~/Excels"), filename)))
            {
                workbook.Write(f);
            }
            Response.WriteFile(string.Format("{0}/{1}", MapPath("~/Excels"), filename));
            Response.Flush();
            Response.End();
        }

    }
}