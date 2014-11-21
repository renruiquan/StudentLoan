using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.Web.user
{
    public partial class BindBank : BasePage
    {
        public UsersEntityEx UserModel { get { return base.GetUserModel(); } }

        public UserBankEntityEx BankModel { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id);

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

                this.BindBankList();

                this.BindData();
            }
        }

        protected void btnSubmit_ServerClick(object sender, EventArgs e)
        {
            string bankName = this.txtBankName.Text.Trim();
            int baseBankId = this.ddlBankTypeList.SelectedValue.Convert<int>();
            string bankCard = this.txtBankCard.Text.Trim();
            string province = this.Request<string>("ddlProvince");
            string city = this.Request<string>("ddlCity");

            UsersEntityEx userModel = base.GetUserModel();


            bool isExist = new UserBankBLL().IsExist(userModel.UserId, bankCard);

            if (isExist)
            {
                this.artDialog("提示", "您已经绑定此银行卡，无需再次绑定！");
                return;
            }

            this.BankModel = new UserBankEntityEx()
            {
                UserId = userModel.UserId,
                BankName = bankName,
                BankCardNo = bankCard,
                BankProvince = province,
                BankCity = city,
                BaseBankId = baseBankId,
                IsDefault = true,
            };

            bool result = new UserBankBLL().Insert(this.BankModel);

            this.artDialog(string.Format("添加{0}", result == true ? "成功" : "失败"));

        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        public void BindData()
        {
            string strWhere = string.Format(@" 1=1  and UserId = {0} and Status=1 Order By CreateTime desc ", base.GetUserModel().UserId);

            List<UserBankEntityEx> list = new UserBankBLL().GetList(strWhere);

            if (list == null || list.Count == 0)
            {
                lblBindBankInfo.Visible = false;
            }

            this.objRepeater.DataSource = list;
            this.objRepeater.DataBind();
        }

        /// <summary>
        /// 绑定银行列表
        /// </summary>
        public void BindBankList()
        {
            this.ddlBankTypeList.DataSource = new BaseBankBLL().GetList(" Status =1 ");
            this.ddlBankTypeList.DataTextField = "BankName";
            this.ddlBankTypeList.DataValueField = "BankId";
            this.ddlBankTypeList.DataBind();
        }

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                UserBankEntityEx model = e.Item.DataItem as UserBankEntityEx;

                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                switch (model.BaseBankId)
                {
                    case 1: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_ICBC.jpg\" alt=\"\"></i>中国工商银行"; break;
                    case 2: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_ABC.jpg\" alt=\"\"></i>中国农业银行"; break;
                    case 3: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_BOC.jpg\" alt=\"\"></i>中国银行"; break;
                    case 4: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_CCB.jpg\" alt=\"\"></i>中国建设银行"; break;
                    case 5: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_BCOM.jpg\" alt=\"\"></i>交通银行"; break;
                    case 6: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_ECITIC.jpg\" alt=\"\"></i>中信银行"; break;
                    case 7: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_CEBB.jpg\" alt=\"\"></i>中国光大银行"; break;
                    case 8: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_HXB.jpg\" alt=\"\"></i>华夏银行"; break;
                    case 9: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_CMBC.jpg\" alt=\"\"></i>中国民生银行"; break;
                    case 10: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_GDB.jpg\" alt=\"\"></i>广发银行"; break;
                    case 11: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_SDB.jpg\" alt=\"\"></i>深圳发展银行"; break;
                    case 12: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_CMB.jpg\" alt=\"\"></i>招商银行"; break;
                    case 13: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_CIB.jpg\" alt=\"\"></i>兴业银行"; break;
                    case 14: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_SPDB.jpg\" alt=\"\"></i>上海浦东发展银行"; break;
                    case 18: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_PSBC.jpg\" alt=\"\"></i>中国邮政储蓄银行"; break;
                    case 57: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_EBA.jpg\" alt=\"\"></i>东亚银行"; break;
                    case 316: objLiteral.Text = "<i><img src=\"../css/img/banks/icon_SPABANK.jpg\" alt=\"\"></i>平安银行"; break;

                }
            }
        }
    }
}