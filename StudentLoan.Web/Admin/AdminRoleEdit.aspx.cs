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
    public partial class AdminRoleEdit : AdminBasePage
    {
        public int RoleId { get { return this.Request<int>("RoleId"); } }

        public AdminEntityEx AdminModel { get { return base.GetAdminInfo(); } }

        public List<AdminRoleValueEntityEx> AdminRoleValueModel { get { return new AdminRoleValueBLL().GetList(string.Format(" 1=1 and RoleId={0} ", this.RoleId)); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        protected void BindData()
        {
            AdminRoleEntityEx model = new AdminRoleBLL().GetModel(this.RoleId);

            if (model != null)
            {
                this.txtAdminRoleName.Text = model.RoleName;
                this.ddlIsSystem.SelectedValue = model.IsSystem.ToString();
                this.ddlRoleType.SelectedValue = model.RoleType.ToString();
            }

            this.objRepeater.DataSource = new AdminRoleValueBLL().GetNavList(" 1=1 ");
            this.objRepeater.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AdminRoleEntityEx model = new AdminRoleEntityEx()
            {
                RoleId = this.RoleId,
                RoleName = this.txtAdminRoleName.Text.Trim(),
                RoleType = this.ddlRoleType.SelectedValue.Convert<int>(),
                IsSystem = this.ddlIsSystem.SelectedValue.Convert<int>()
            };

            bool result = new AdminRoleValueBLL().Delete(new AdminRoleValueEntityEx() { RoleId = this.RoleId });

            result = new AdminRoleBLL().Update(model);

            List<AdminRoleValueEntityEx> roleValueList = new List<AdminRoleValueEntityEx>();

            for (int i = 0; i < objRepeater.Items.Count; i++)
            {
                CheckBox objCheckBox = objRepeater.Items[i].FindControl("objCheckBox") as CheckBox;

                if (objCheckBox.Checked == true)
                {
                    result = new AdminRoleValueBLL().Insert(new AdminRoleValueEntityEx() { RoleId = this.RoleId, NavId = objCheckBox.Attributes["value"].Convert<int>() });
                }
            }

            this.Alert(string.Format("修改{0}", result == true ? "成功" : "失败"), "AdminRoleList.aspx");
        }

        protected void objRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                if (this.RoleId == 1)
                {
                    CheckBox objCheckBox = e.Item.FindControl("objCheckBox") as CheckBox;

                    objCheckBox.Checked = true;

                }
                else
                {
                    foreach (AdminRoleValueEntityEx model in AdminRoleValueModel)
                    {
                        CheckBox objCheckBox = e.Item.FindControl("objCheckBox") as CheckBox;

                        if (objCheckBox.Attributes["value"] == model.NavId.ToString())
                        {
                            objCheckBox.Checked = true;
                        }
                    }

                }
            }
        }
    }
}