using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;

namespace StudentLoan.Web.Admin
{
    public partial class AdminAdd : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AdminEntityEx model = new AdminEntityEx()
            {
                RoleId = this.ddlRoleId.SelectedValue.Convert<int>(),
                AdminName = this.txtAdminName.Text.Trim(),
                RealName = this.txtRealName.Text.Trim(),
                Telephone = this.txtTelephone.Text.Trim(),
                Email = this.txtEmail.Text.Trim(),
                Salt = Guid.NewGuid().ToString().Split('-')[1],
                IsLock = 1,
                CreateTime = DateTime.Now
            };

            model.Password = DESHelper.Encrypt(this.txtPassword.Text.Trim(), model.Salt);

            AdminBLL bll = new AdminBLL();

            if (bll.Exists(model.AdminName))
            {
                this.Alert("管理员名称已存在，请修改后再试 ");
            }
            else
            {
                bool result = new AdminBLL().Insert(model);

                this.Alert(string.Format("添加{0}", result == true ? "成功" : "失败"), "AdminList.aspx");
            }
        }
    }
}