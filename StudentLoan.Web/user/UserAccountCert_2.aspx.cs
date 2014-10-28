using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.user
{
    public partial class UserAccountCert_2 : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id.Replace("_2", ""));

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion               
                IsWritten();
            }
        }
        //判断是否已经完善过信息
        protected void IsWritten()
        {
            UsersEntityEx userModel = Usermodel();
            if (!string.IsNullOrEmpty(userModel.TrueName))
            {
                    this.txtTruename.Attributes.Add("ReadOnly", "true");
                    this.txtIdentityCard.Attributes.Add("ReadOnly", "true");
                    txtBirthday.Text = userModel.Birthday.ToString();
                    txtIdentityCard.Text = userModel.IdentityCard;
                    txtMobile.Text = userModel.Mobile;
                    txtTruename.Text = userModel.TrueName;
                    ddlGender.SelectedValue = userModel.Gender;
                    ddlNation.SelectedValue = userModel.Nation;
            }
            else
            {
                //
            }
        }
        //获取用户Model
        protected UsersEntityEx Usermodel()
        { 
            UsersEntityEx userModel = base.GetUserModel();
            return userModel;
        }
        //保存基本信息一
        protected void btnSaveStepOne_ServerClick(object sender, EventArgs e)
        {
            UsersEntityEx userModel = Usermodel();          
            string truename = txtTruename.Text.Trim().HtmlEncode();
            string identityCard = txtIdentityCard.Text.Trim().HtmlEncode();
            string mobile = txtMobile.Text.Trim().HtmlEncode();
            string gender = ddlGender.SelectedValue;
            string nation = ddlNation.SelectedValue;
            string birthday = txtBirthday.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(truename))
            {
                this.artDialog("错误", "真实姓名不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(identityCard))
            {
                this.artDialog("错误", "身份证号码不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(mobile))
            {
                this.artDialog("错误", "电话号码不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(gender))
            {
                this.artDialog("错误", "请选择性别");
                return;
            }
            if (string.IsNullOrEmpty(nation))
            {
                this.artDialog("错误", "请选择民族");
                return;
            }
            if (string.IsNullOrEmpty(birthday))
            {
                this.artDialog("错误", "生日不能为空，请重新填写");
                return;
            }

            if (Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] == null)
            {
                Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] = 1;
            }

            else
            {
                Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM] = Convert.ToInt32(Session[StudentLoanKeys.SESSION_USER_LOGIN_SUM]) + 1;
            }
           
            userModel.TrueName = truename;
            userModel.Mobile = mobile;
            userModel.IdentityCard = identityCard;
            userModel.Gender = gender;
            userModel.Nation = nation;
            userModel.Birthday =Convert.ToDateTime(birthday);

            bool result = new UsersBLL().Update(userModel);
            if (result)
            {
                this.artDialog("提示", "保存成功！");
            }
            else
            {
                this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
            }
        }
    }
}