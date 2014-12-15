using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace StudentLoan.Web.Admin
{
    public partial class ChargeList : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtStartTime.Text = DateTime.Now.ToString("yyyy-MM-dd");

                string action = this.Request<string>("action");

                if (action == "delete")
                {
                    int Id = this.Request<int>("Id");

                    bool result = new UserChargeBLL().Delete(new UserChargeEntityEx() { Id = Id });

                    this.Alert(string.Format("操作{0}", result == true ? "成功" : "失败"));
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

            string queryContent = this.txtQueryContent.Text.Trim();
            string status = this.ddlStatus.SelectedValue;
            string startTime = this.txtStartTime.Text.Trim();
            string endTime = this.txtEndTime.Text.Trim();

            if (!string.IsNullOrEmpty(queryContent))
            {
                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(@" and T.UserId = '{0}'", new UsersBLL().GetUserId(queryContent));
                }

                if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(@" and OrderNo = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "3")
                {
                    strWhere += string.Format(@" and ChannelOrderNo = '{0}'", queryContent);
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                strWhere += string.Format(@" and T.Status = {0}", status);
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

            List<UserChargeEntityEx> sourceList = new UserChargeBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserChargeBLL().GetRecordCount(strWhere);

            //如果查询的结束索引大于数据总条数，当前页为最后一页，并重新绑定分页数据
            //if (endIndex > this.objAspNetPager.RecordCount)
            //{
            //    this.objAspNetPager.CurrentPageIndex = this.objAspNetPager.RecordCount / this.objAspNetPager.CurrentPageIndex + 1;
            //}


            objRepeater.DataSource = sourceList;
            objRepeater.DataBind();

        }

        public string GetStatusName(int status)
        {
            if (status == 0)
            {
                //  0=未支付，1=充值中，2=已完成充值
                return "未支付";
            }
            else if (status == 1)
            {
                return "充值中";
            }
            else if (status == 2)
            {
                return "已完成充值";
            }
            else
            {
                return "支付失败";
            }
        }

        protected void btnExport_ServerClick(object sender, EventArgs e)
        {
            string strWhere = @" 1=1 ";

            string queryContent = this.txtQueryContent.Text.Trim();
            string status = this.ddlStatus.SelectedValue;
            string startTime = this.txtStartTime.Text.Trim();
            string endTime = this.txtEndTime.Text.Trim();

            if (!string.IsNullOrEmpty(queryContent))
            {
                if (this.ddlQueryType.SelectedValue == "1")
                {
                    strWhere += string.Format(@" and T.UserId = '{0}'", new UsersBLL().GetUserId(queryContent));
                }

                if (this.ddlQueryType.SelectedValue == "2")
                {
                    strWhere += string.Format(@" and OrderNo = '{0}'", queryContent);
                }

                if (this.ddlQueryType.SelectedValue == "3")
                {
                    strWhere += string.Format(@" and ChannelOrderNo = '{0}'", queryContent);
                }
            }

            if (!string.IsNullOrEmpty(status))
            {
                strWhere += string.Format(@" and T.Status = {0}", status);
            }

            if (!string.IsNullOrEmpty(startTime))
            {
                strWhere += string.Format(@" and T.CreateTime >= '{0}'", startTime.Convert<DateTime>());
            }

            if (!string.IsNullOrEmpty(endTime))
            {
                strWhere += string.Format(@" and T.CreateTime <= '{0}'", endTime.Convert<DateTime>());
            }

            List<UserChargeEntityEx> sheetAdapter = new UserChargeBLL().GetList(strWhere);

            string filename = string.Format("充值记录-{0}_{1}.xlsx", startTime, endTime);
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


                firstRow.CreateCell(0, CellType.String).SetCellValue("用户名");
                firstRow.CreateCell(1, CellType.String).SetCellValue("订单号");
                firstRow.CreateCell(2, CellType.String).SetCellValue("充值渠道");
                firstRow.CreateCell(3, CellType.String).SetCellValue("第三方流水号");
                firstRow.CreateCell(4, CellType.Numeric).SetCellValue("确认金额");
                firstRow.CreateCell(5, CellType.String).SetCellValue("订单时间");
                firstRow.CreateCell(6, CellType.String).SetCellValue("支付时间");
                firstRow.CreateCell(7, CellType.String).SetCellValue("回调时间");
                firstRow.CreateCell(8, CellType.String).SetCellValue("回调代码");
                firstRow.CreateCell(9, CellType.String).SetCellValue("状态");


                //居中对齐
                for (int j = 0; j <= 9; j++)
                {
                    firstRow.Cells[j].CellStyle.VerticalAlignment = VerticalAlignment.Center;
                    firstRow.Cells[j].CellStyle.Alignment = HorizontalAlignment.Center;
                }

                //冻结首行
                sheet.CreateFreezePane(0, 1);


                IRow row = sheet.CreateRow(i + 1);

                row.HeightInPoints = 25;

                row.CreateCell(0, CellType.String).SetCellValue(sheetAdapter[i].UserName);
                row.CreateCell(1, CellType.String).SetCellValue(sheetAdapter[i].OrderNo);
                row.CreateCell(2, CellType.String).SetCellValue(sheetAdapter[i].ChannelName);
                row.CreateCell(3, CellType.String).SetCellValue(sheetAdapter[i].ChannelOrderNo);
                row.CreateCell(4, CellType.Numeric).SetCellValue(sheetAdapter[i].ConfirmMoney.Convert<double>());
                row.CreateCell(5, CellType.String).SetCellValue(string.Format("{0}", sheetAdapter[i].CreateTime));
                row.CreateCell(6, CellType.String).SetCellValue(string.Format("{0}", sheetAdapter[i].PayTime));
                row.CreateCell(7, CellType.String).SetCellValue(string.Format("{0}", sheetAdapter[i].CallbackTime));
                row.CreateCell(8, CellType.String).SetCellValue(sheetAdapter[i].CallbackCode);
                row.CreateCell(9, CellType.String).SetCellValue(string.Format("{0}", this.GetStatusName(sheetAdapter[i].Status)));


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