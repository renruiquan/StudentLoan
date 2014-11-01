using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentLoan.Web.Admin
{
    /// <summary>
    /// 管理员基类
    /// </summary>
    public class AdminBasePage : System.Web.UI.Page
    {
        public AdminBasePage()
        {
            this.Load += new EventHandler(AdminBasePage_Load);

        }

        private void AdminBasePage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!IsAdminLogin())
            {
                Response.Write("<script>parent.location.href='login.aspx'</script>");
                Response.End();
            }
        }

        #region 管理员============================================
        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin()
        {
            //如果Session为Null
            if (Session[StudentLoanKeys.SESSION_ADMIN_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string adminname = this.GetCookie("AdminName", "DTcms");
                string adminpwd = this.GetCookie("AdminPwd", "DTcms");
                if (adminname != "" && adminpwd != "")
                {
                    AdminBLL bll = new BLL.AdminBLL();
                    AdminEntityEx model = bll.GetModel(adminname, adminpwd, true);
                    if (model != null)
                    {
                        Session[StudentLoanKeys.SESSION_ADMIN_INFO] = model;
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得管理员信息
        /// </summary>
        public AdminEntityEx GetAdminInfo()
        {
            if (IsAdminLogin())
            {
                AdminEntityEx model = Session[StudentLoanKeys.SESSION_ADMIN_INFO] as AdminEntityEx;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 检查管理员权限
        /// </summary>
        /// <param name="url">菜单名称</param>
        /// <param name="action_type">操作类型</param>
        public void ChkAdminLevel(string url)
        {
            AdminEntityEx model = GetAdminInfo();
            AdminRoleBLL bll = new AdminRoleBLL();
            bool result = bll.Exists(model.RoleId, url);

            if (!result)
            {
                string msgbox = "parent.jsdialog(\"错误提示\", \"您没有管理该页面的权限，请勿非法进入！\", \"back\", \"Error\")";
                Response.Write("<script type=\"text/javascript\">" + msgbox + "</script>");
                Response.End();
            }
        }

        /// <summary>
        /// 写入管理日志
        /// </summary>
        /// <param name="action_type"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public bool AddAdminLog(string action_type, string remark)
        {
            AdminEntityEx model = GetAdminInfo();

            //写入登录日志
            AdminLogEntityEx adminLogModel = new AdminLogEntityEx()
            {
                AdminId = model.AdminId,
                AdminName = model.AdminName,
                UserIP = Request.UserHostAddress,
                ActionType = "登录"
            };

            return new AdminLogBLL().Insert(adminLogModel);

        }


        #endregion
    }
}