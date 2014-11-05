using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using StudentLoan.API;
using StudentLoan.Common.Logging;
using System.Text;
using NPOI.SS.UserModel;
using System.IO;
using NPOI.XSSF.UserModel;

namespace StudentLoan.Web.Admin
{
    public partial class UserManageMoneyList : AdminBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

                string action = this.Request<string>("Action");

                if (action == "DrawMoney")
                {
                    int drawId = this.Request<int>("DrawId");

                    if (drawId > 0)
                    {
                        DrawMoneyEntityEx model = new DrawMoneyEntityEx();
                        model.DrawId = drawId;
                        model.AdminId = base.GetAdminInfo().AdminId;
                        model.Status = 2;

                        bool result = new DrawMoneyBLL().UpdateByAdmin(model);

                        if (result)
                        {
                            int userId = this.Request<int>("UserId");
                            string userMobile = new UsersBLL().GetModel(userId).Mobile;

                            string code =  Message.Send(userMobile, "亲，你的提现申请已受理，请注意查收！【学子易贷】");

                            LogHelper.Default.Info("短信发送记录:" + code);
                        }

                        this.Alert(string.Format("更新提现记录状态{0}", result == true ? "成功" : "失败"));
                    }
                    else
                    {
                        this.Alert("参数不正确！", "DrawMoneyList.aspx");
                    }

                }

                this.BindData();
            }
        }

        protected void objAspNetPager_PageChanged(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.BindData();
        }

        public void BindData()
        {
            string strWhere = @" 1=1 ";

            string queryContent = this.txtQueryContent.Text.Trim().HtmlEncode();
            string startTime = this.txtStartTime.Text.Trim();
            string endTime = this.txtEndTime.Text.Trim();

            if (!string.IsNullOrEmpty(queryContent))
            {
                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(@" and c.UserName = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(@" and b.SchemeName = '{0}'", queryContent);
                }
            }

            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(@" and T.CreateTime >= '{0}'", startTime.Convert<DateTime>());
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(@" and T.CreateTime <= '{0}'", endTime.Convert<DateTime>());
            }

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserManageMoneyEntityEx> sourceList = new UserManageMoneyBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserManageMoneyBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            if (endIndex > this.objAspNetPager.RecordCount)
            {
                this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            }


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        public string GetStatusName(int status)
        {
            if (status == 0)
            {
                //  0=等待付款，1=已付款，2=用户消费付款
                return "等待付款";
            }
            else if (status == 0)
            {
                return "等待付款";
            }
            else if (status == 1)
            {
                return "已付款";
            }
            else if (status == 2)
            {
                return "用户消费付款";
            }
            else
            {
                return "异常";
            }
        }

        protected void btnExport_ServerClick(object sender, EventArgs e)
        {
            string strWhere = @" 1=1 ";

            string queryContent = this.txtQueryContent.Text.Trim().HtmlEncode();
            string startTime = this.txtStartTime.Text.Trim();
            string endTime = this.txtEndTime.Text.Trim();

            if (!string.IsNullOrEmpty(queryContent))
            {
                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(@" and c.UserName = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(@" and b.SchemeName = '{0}'", queryContent);
                }
            }

            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(@" and T.CreateTime >= '{0}'", startTime.Convert<DateTime>());
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(@" and T.CreateTime <= '{0}'", endTime.Convert<DateTime>());
            }


            List<UserManageMoneyEntityEx> sheetAdapter = new UserManageMoneyBLL().GetExportList(strWhere);

            string filename = string.Format("理财记录-{0}_{1}.xlsx", startTime, endTime);
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


                firstRow.CreateCell(0, CellType.String).SetCellValue("理财编号");
                firstRow.CreateCell(1, CellType.String).SetCellValue("用户名");
                firstRow.CreateCell(2, CellType.String).SetCellValue("产品名称");
                firstRow.CreateCell(3, CellType.String).SetCellValue("方案名称");
                firstRow.CreateCell(4, CellType.Numeric).SetCellValue("购买数量");
                firstRow.CreateCell(5, CellType.Numeric).SetCellValue("金额");
                firstRow.CreateCell(6, CellType.String).SetCellValue("订单日期");
                firstRow.CreateCell(7, CellType.String).SetCellValue("支付日期");
                firstRow.CreateCell(8, CellType.String).SetCellValue("状态");


                //居中对齐
                for (int j = 0; j <= 8; j++)
                {
                    firstRow.Cells[j].CellStyle.VerticalAlignment = VerticalAlignment.Center;
                    firstRow.Cells[j].CellStyle.Alignment = HorizontalAlignment.Center;
                }

                //冻结首行
                sheet.CreateFreezePane(0, 1);


                IRow row = sheet.CreateRow(i + 1);

                row.HeightInPoints = 25;

                row.CreateCell(0, CellType.String).SetCellValue(sheetAdapter[i].BuyId);
                row.CreateCell(1, CellType.String).SetCellValue(sheetAdapter[i].UserName);
                row.CreateCell(2, CellType.String).SetCellValue(sheetAdapter[i].ProductName);
                row.CreateCell(3, CellType.String).SetCellValue(sheetAdapter[i].SchemeName);
                row.CreateCell(4, CellType.Numeric).SetCellValue(sheetAdapter[i].Count);
                row.CreateCell(5, CellType.Numeric).SetCellValue(sheetAdapter[i].Amount.Convert<double>());
                row.CreateCell(6, CellType.String).SetCellValue(string.Format("{0}", sheetAdapter[i].CreateTime));
                row.CreateCell(7, CellType.String).SetCellValue(string.Format("{0}", sheetAdapter[i].PayTime));
                row.CreateCell(8, CellType.String).SetCellValue(string.Format("{0}", this.GetStatusName(sheetAdapter[i].Status)));

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