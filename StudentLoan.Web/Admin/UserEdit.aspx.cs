using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.Admin
{
    public partial class UserEdit : AdminBasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = this.Request<int>("UserId");

                if (userId <= 0)
                {
                    this.Alert("参数不正确");
                    return;
                }

                UsersEntityEx model = new UsersBLL().GetModel(userId);
                if (model == null)
                {
                    this.Alert("用户不存在");
                    return;
                }
                this.ddlStatus.SelectedValue = model.Status.ToString();
                this.txtNewPassword.Text = DESHelper.Decrypt(model.Password, model.Salt);
                this.txtDrawMoneyPassword.Text = DESHelper.Decrypt(model.DrawMoneyPassword, model.Salt);
                this.ddlCanModifyUserInfo.SelectedValue = model.CanModify.ToString();

                UserSchoolEntityEx schoolModel = new UserSchoolBLL().GetModel(userId);
                UserCertificationEntityEx userCertModel = new UserCertificationBLL().GetList(string.Format(" UserId = {0}", userId)).FirstOrDefault();
                UserRelationshipEntityEx userRelationshipModel = new UserRelationshipBLL().GetModel(userId);

                if (schoolModel != null)
                {
                    this.ddlCanModifySchool.SelectedValue = schoolModel.Status.ToString();
                }

                if (userCertModel != null)
                {
                    this.ddlCanModifyUserCert.SelectedValue = userCertModel.CanModify.ToString();
                }
                if (userRelationshipModel != null)
                {
                    this.ddlCanModifyRelationship.SelectedValue = userRelationshipModel.Status.ToString();
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int userId = this.Request<int>("UserId");
            string salt = new UsersBLL().GetModel(userId).Salt;

            int canModifyUserInfo = this.ddlCanModifyUserInfo.SelectedValue.Convert<int>();
            int canModifyUserCert = this.ddlCanModifyUserCert.SelectedValue.Convert<int>();
            int canModifyRelationship = this.ddlCanModifyRelationship.SelectedValue.Convert<int>();
            int canModifySchool = this.ddlCanModifySchool.SelectedValue.Convert<int>();

            //是否可以更新用户资料
            UsersEntityEx model = new Model.UsersEntityEx()
            {
                UserId = userId,
                Password = DESHelper.Encrypt(this.txtNewPassword.Text.Trim(), salt),
                Status = this.ddlStatus.SelectedValue.Convert<int>(),
                DrawMoneyPassword = DESHelper.Encrypt(this.txtDrawMoneyPassword.Text.Trim(), salt),
                CanModify = canModifyUserInfo
            };

            bool result = new UsersBLL().UpdatePasswordByAdmin(model);


            //是否可以更新用户认证信息
            UserCertificationEntityEx certModel = new UserCertificationEntityEx()
            {
                UserId = userId,
                CanModify = canModifyUserCert
            };

            result = new UserCertificationBLL().UpdateByAdmin(certModel);

            //是否可以更新学校信息
            UserSchoolEntityEx schoolModel = new UserSchoolEntityEx()
            {
                UserId = userId,
                Status = canModifySchool
            };


            result = new UserSchoolBLL().UpdateByAdmin(schoolModel);


            //是否可以更新联系人信息
            UserRelationshipEntityEx relateionshipModel = new UserRelationshipEntityEx()
            {
                UserId = userId,
                Status = canModifyRelationship
            };

            result = new UserRelationshipBLL().UpdateByAdmin(relateionshipModel);

            this.Alert(string.Format("更新{0}", result == true ? "成功" : "失败"), "UserList.aspx");
        }
    }
}