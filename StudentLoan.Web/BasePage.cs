using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudentLoan.Common;
using StudentLoan.BLL;

namespace StudentLoan.Web
{
    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            this.Load += new EventHandler(BasePage_Load);
        }

        private void BasePage_Load(object sender, EventArgs e)
        {
            //判断管理员是否登录
            if (!IsUsersLogin())
            {
                Response.Write("<script>parent.location.href='login.aspx'</script>");
                Response.End();
            }
        }




        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsUsersLogin()
        {
            //如果Session为Null
            if (Session[StudentLoanKeys.SESSION_USER_INFO] != null)
            {
                return true;
            }
            else
            {
                //检查Cookies
                string userName = this.GetCookie("UserName", "StudentLoan");

                string userPwd = this.GetCookie("UserPwd", "StudentLoan");

                if (userName != "" && userPwd != "")
                {
                    UsersBLL bll = new UsersBLL();

                    UsersEntityEx model = bll.GetModel(userName, userPwd, true);

                    if (model != null)
                    {
                        Session[StudentLoanKeys.SESSION_USER_INFO] = model;

                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 取得用户信息
        /// </summary>
        public UsersEntityEx GetUserModel()
        {
            if (IsUsersLogin())
            {
                UsersEntityEx model = Session[StudentLoanKeys.SESSION_USER_INFO] as UsersEntityEx;
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }

        /// <summary>
        /// 写入管理日志
        /// </summary>
        public bool AddAdminLog(string action_type, string remark)
        {
            return false;
        }
    }
}
