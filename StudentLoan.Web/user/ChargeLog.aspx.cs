using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using System.Reflection;
using System.Web.UI.HtmlControls;

namespace StudentLoan.Web.user
{
    public partial class ChargeLog : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    #region 设置导航样式

                    string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                    Control objControl = Master.FindControl(id.Replace("Log", ""));

                    if (objControl != null)
                    {
                        HtmlAnchor objAnchor = objControl as HtmlAnchor;

                        objAnchor.Attributes.Add("class", "active");
                    }

                    #endregion
                }


                string orderNo = this.Request<string>("orderNo");

                if (!string.IsNullOrEmpty(orderNo))
                {
                    this.Charge(orderNo);
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
            string strWhere = string.Format(@" 1 = 1 and T.UserId = '{0}'", base.GetUserModel().UserId);

            #region 计算分页数据

            int startIndex = objAspNetPager.CurrentPageIndex * objAspNetPager.PageSize - objAspNetPager.PageSize + 1;
            int endIndex = objAspNetPager.StartRecordIndex + objAspNetPager.PageSize - 1;

            #endregion

            List<UserChargeEntityEx> sourceList = new UserChargeBLL().GetListByPage(strWhere, " CreateTime Desc ", startIndex, endIndex);
            this.objAspNetPager.RecordCount = new UserChargeBLL().GetRecordCount(strWhere);

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


        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                UserChargeEntityEx model = e.Item.DataItem as UserChargeEntityEx;
                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                if (model.Status == 0)
                {
                    objLiteral.Text = string.Format("<a href=\"ChargeLog.aspx?orderNo={0}\">支付</a>", model.OrderNo);
                }
                else if (model.Status == 1)
                {
                    objLiteral.Text = "充值中";
                }
                else if (model.Status == 2)
                {
                    objLiteral.Text = "成功";
                }
            }
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="orderNo"></param>
        public void Charge(string orderNo)
        {
            //获取用户信息
            UsersEntityEx userModel = base.GetUserModel();

            //获取充值渠道
            ChannelEntityEx channelModel = new ChannelBLL().GetList("").RandomExtractByWeight<ChannelEntityEx>(1).First();

            UserChargeEntityEx model = new UserChargeBLL().GetModel(orderNo);


            if (channelModel.ChannelFlag.ToLower() == "dinpay")
            {
                string postString = string.Format("merchant_code={0}&order_amount={1}&bank_code={2}&key={3}&product_name={4}&order_no={5}&order_time={6}",
                                                    channelModel.AppId, model.ChargeMoney, model.Ext5, channelModel.AppKey,
                                                    model.ProductName, model.OrderNo, model.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));

                Response.Redirect(string.Format("http://{0}/channel/dinpay.aspx?{1}", Request.Url.Authority, postString));
            }
            else if (channelModel.ChannelFlag.ToLower() == "alipay")
            {
                this.Alert("渠道未接入");
            }
        }
    }
}