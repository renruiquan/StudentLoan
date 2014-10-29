using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using StudentLoan.Common;

namespace StudentLoan.Web.user
{
    public partial class Withdraw : BasePage
    {
        public UsersEntityEx UserModel { get { return base.GetUserModel(); } }

        public UserBankEntityEx BankModel { get { return new UserBankBLL().GetModel(this.UserModel.UserId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式



                Control objControl = Master.FindControl("Charge");

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion


                this.BindData();
            }
        }


        private void BindData()
        {
            string strWhere = string.Format(@" 1=1  and UserId = {0} and Status=1 Order By IsDefault Desc, CreateTime desc ", base.GetUserModel().UserId);

            List<UserBankEntityEx> list = new UserBankBLL().GetList(strWhere);

            if (list == null || list.Count == 0)
            {
                this.artDialog("提示", "请先绑定银行卡", "/user/BindBank.aspx");
            }
            else
            {
                this.objRepeater.DataSource = list;
                this.objRepeater.DataBind();
            }
        }

        protected void btnWithdraw_ServerClick(object sender, EventArgs e)
        {
            int bankId = this.Request<int>("bank_id", 0);
            decimal drawMoney = this.txtWithdrawMoney.Text.Trim().Convert<decimal>();
            string drawMoneyPassword = this.txtDrawMoneyPassword.Text.Trim().HtmlEncode();

            UsersEntityEx userModel = new UsersBLL().GetModel(this.UserModel.UserId);

            if (userModel.Amount == 0)
            {
                this.artDialog("错误", "对不起，你的余额为0元，无法提现！");
                return;
            }
            else if (userModel.Amount < drawMoney)
            {
                this.artDialog("错误", string.Format("对不起，你的余额不足，最多只能提取{0}元！", userModel.Amount));
                return;
            }

            if (bankId == 0)
            {
                this.artDialog("提示", "请选择提现银行卡");
                return;
            }

            if (DESHelper.Encrypt(drawMoneyPassword, this.UserModel.Salt) != this.UserModel.DrawMoneyPassword)
            {
                this.artDialog("错误", "对不起，提现密码不正确，请修正后重试！");
                return;
            }

            DrawMoneyEntityEx model = new DrawMoneyEntityEx()
            {
                UserId = this.UserModel.UserId,
                BindBankId = bankId,
                DrawMoney = drawMoney,
                Fee = 0,
                LockMoney = this.txtWithdrawMoney.Text.Trim().Convert<decimal>(),
                ApplyTime = DateTime.Now,
                Status = 0
            };

            bool result = new DrawMoneyBLL().Insert(model);

            this.artDialog("提示", string.Format("提现申请{0}", result == true ? "成功" : "失败"), "Withdraw.aspx");
        }


        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                UserBankEntityEx model = e.Item.DataItem as UserBankEntityEx;

                Literal objLiteral = e.Item.FindControl("objLiteral") as Literal;

                switch (model.BankId)
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