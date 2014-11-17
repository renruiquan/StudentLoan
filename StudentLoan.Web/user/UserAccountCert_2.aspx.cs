using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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

                this.SetSchoolList();

                this.BindUserSchool();

                this.BindUserRelationship();
            }
        }
        //判断是否已经完善过信息
        protected void IsWritten()
        {
            this.txtBirthday.Attributes.Add("ReadOnly", "true");

            UsersEntityEx userModel = base.GetUserModel();

            if (!string.IsNullOrEmpty(userModel.TrueName))
            {
                this.txtTruename.Attributes.Add("ReadOnly", "true");
                txtBirthday.Text = userModel.Birthday.ToString("yyyy-MM-dd");
                txtIdentityCard.Text = userModel.IdentityCard;
                txtMobile.Text = userModel.Mobile;
                txtTruename.Text = userModel.TrueName;
                ddlGender.SelectedValue = userModel.Gender;
                ddlNation.SelectedValue = userModel.Nation;
            }
        }

        //保存基本信息一
        protected void btnSaveStepOne_ServerClick(object sender, EventArgs e)
        {
            UsersEntityEx userModel = base.GetUserModel();
            //step1个人基本信息字段                  
            string truename = txtTruename.Text.Trim().HtmlEncode();
            string identityCard = txtIdentityCard.Text.Trim().HtmlEncode();
            string mobile = txtMobile.Text.Trim().HtmlEncode();
            string gender = ddlGender.SelectedValue;
            string nation = ddlNation.SelectedValue;
            string birthday = txtBirthday.Text.Trim().HtmlEncode();

            //step1个人基本信息验证
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
            userModel.Birthday = Convert.ToDateTime(birthday);
            userModel.Remark = "point=true";
            userModel.Point = 10;

            bool result = new UsersBLL().Update(userModel);

            if (result)
            {
                userModel = new UsersBLL().GetModel(userModel.UserId);
                //写入Cookies
                this.WriteCookie("SLRememberName", userModel.UserName, 14400);
                this.WriteCookie("UserName", "StudentLoan", userModel.UserName);
                this.WriteCookie("UserPwd", "StudentLoan", userModel.Password);
                Response.Redirect("/IvoryTower.aspx");

                this.artDialog("提示", "保存成功！请继续填写其他信息");
                this.txtTruename.Attributes.Add("ReadOnly", "true");
                this.txtIdentityCard.Attributes.Add("ReadOnly", "true");
            }
            else
            {
                this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
            }
        }

        //保存学校信息
        protected void btnSaveStepTwo_ServerClick(object sender, EventArgs e)
        {
            UsersEntityEx userModel = base.GetUserModel();
            UserSchoolEntityEx userschoolModel = new UserSchoolEntityEx();
            //step2学校信息
            string xuexinusername = txtXuexin.Text.Trim().HtmlEncode();
            string xuexinpass = txtXuexin_Password.Text.Trim().HtmlEncode();
            string schoolname = txtSchoolName.Text.Trim().HtmlEncode();
            string schooladd = txtSchoolAdd.Text.Trim().HtmlEncode();
            string yearofadmission = txtYearOfAdmission.Text.Trim().HtmlEncode();
            int schoolsystem = Convert.ToInt32(ddlSchoolSystem.SelectedValue);
            int education = Convert.ToInt32(ddlEducation.SelectedValue);
            string major = txtMajor.Text.Trim().HtmlEncode();

            //step3学校信息验证
            if (string.IsNullOrEmpty(xuexinusername))
            {
                this.artDialog("错误", "学信网账号不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(xuexinpass))
            {
                this.artDialog("错误", "学信网密码不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(schoolname))
            {
                this.artDialog("错误", "学校名称不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(schooladd))
            {
                this.artDialog("错误", "学校地址不能为空，请重新填写");
                return;
            }
            if (string.IsNullOrEmpty(yearofadmission))
            {
                this.artDialog("错误", "请选择入学日期");
                return;
            }
            if (schoolsystem == 0)
            {
                this.artDialog("错误", "请选择学制");
                return;
            }
            if (education == 0)
            {
                this.artDialog("错误", "请选择学历");
                return;
            }
            if (string.IsNullOrEmpty(major))
            {
                this.artDialog("错误", "专业(系)不能为空，请重新填写");
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


            userschoolModel.UserId = userModel.UserId;
            userschoolModel.XuexinUsername = xuexinusername;
            userschoolModel.XuexinPassword = xuexinpass;
            userschoolModel.SchoolAddress = schooladd;
            userschoolModel.YearOfAdmission = Convert.ToDateTime(yearofadmission);
            userschoolModel.SchoolSystem = schoolsystem;
            userschoolModel.Education = education;
            userschoolModel.Major = major;
            userschoolModel.SchoolName = schoolname;
            userschoolModel.CreateTime = DateTime.Now;
            userschoolModel.Point = 10;

            //判断用户的学校信息是否存在
            bool result = new UserSchoolBLL().Exists(userModel.UserId);

            if (result)
            {
                result = new UserSchoolBLL().Update(userschoolModel);
                if (result)
                {

                    this.artDialog("提示", "保存成功！请继续填写其他信息");
                }
                else
                {
                    this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
                }
            }
            else
            {
                result = new UserSchoolBLL().Insert(userschoolModel);

                if (result)
                {
                    this.artDialog("提示", "保存成功！请继续填写其他信息");
                }
                else
                {
                    this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
                }
            }
        }

        //保存联系人信息
        protected void btnSaveStepFinal_ServerClick(object sender, EventArgs e)
        {
            UsersEntityEx userModel = base.GetUserModel();
            UserRelationshipEntityEx userrelationshipmodel = new UserRelationshipEntityEx();
            //step3 联系人信息字段
            string relativename = txtRelativeName.Text.Trim().HtmlEncode();
            string relativeprofession = txtRelativeProfession.Text.Trim().HtmlEncode();
            string relativetype = txtRelationtype.Text.Trim().HtmlEncode();
            string relativemobile = txtRelativeMobile.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(relativename) || string.IsNullOrEmpty(relativeprofession) || string.IsNullOrEmpty(relativetype) || string.IsNullOrEmpty(relativemobile))
            {
                this.artDialog("提示", "请将亲属信息填写完整");
                return;
            }

            string matename = txtMateName.Text.Trim().HtmlEncode();
            string matemobile = txtMateMobile.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(matename) || string.IsNullOrEmpty(matename))
            {
                this.artDialog("提示", "请将同学(同室)信息填写完整");
                return;
            }

            string friendname = txtFriendName.Text.Trim().HtmlEncode();
            string friendmobile = txtFriendMobile.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(friendname) || string.IsNullOrEmpty(friendmobile))
            {
                this.artDialog("提示", "请将朋友信息填写完整");
                return;
            }
            //亲属
            userrelationshipmodel.UserId = userModel.UserId;
            userrelationshipmodel.Name = relativename;
            userrelationshipmodel.Profession = relativeprofession;
            userrelationshipmodel.Relationship = relativetype;
            userrelationshipmodel.Mobile = relativemobile;
            userrelationshipmodel.Type = 1;
            userrelationshipmodel.CreateTime = DateTime.Now;
            userrelationshipmodel.Point = 4;

            bool result = new UserRelationshipBLL().Exists(userModel.UserId, 1);

            if (result)
            {
                result = new UserRelationshipBLL().Update(userrelationshipmodel);
                if (result)
                {
                    this.artDialog("提示", "保存成功！");
                }
                else
                {
                    this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
                }
            }
            else
            {
                result = new UserRelationshipBLL().Insert(userrelationshipmodel);

                if (result)
                {
                    this.artDialog("提示", "保存成功！");
                }
                else
                {
                    this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
                }
            }

            //同学
            UserRelationshipEntityEx userrelationshipmodel2 = new UserRelationshipEntityEx();
            userrelationshipmodel2.UserId = userModel.UserId;
            userrelationshipmodel2.Name = matename;
            userrelationshipmodel2.Mobile = matemobile;
            userrelationshipmodel2.Relationship = "同学(同室)";
            userrelationshipmodel2.Type = 2;
            userrelationshipmodel2.CreateTime = DateTime.Now;
            userrelationshipmodel2.Point = 3;

            bool result2 = new UserRelationshipBLL().Exists(userModel.UserId, 2);

            if (result2)
            {
                result = new UserRelationshipBLL().Update(userrelationshipmodel2);
                if (result)
                {
                    this.artDialog("提示", "保存成功！");
                }
                else
                {
                    this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
                }
            }
            else
            {
                result = new UserRelationshipBLL().Insert(userrelationshipmodel2);
                if (result)
                {
                    this.artDialog("提示", "保存成功！");
                }
                else
                {
                    this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
                }
            }


            //朋友
            UserRelationshipEntityEx userrelationshipmodel3 = new UserRelationshipEntityEx();
            userrelationshipmodel3.UserId = userModel.UserId;
            userrelationshipmodel3.Name = friendname;
            userrelationshipmodel3.Mobile = friendmobile;
            userrelationshipmodel3.Relationship = "朋友";
            userrelationshipmodel3.Type = 3;
            userrelationshipmodel3.CreateTime = DateTime.Now;
            userrelationshipmodel3.Point = 3;

            bool result3 = new UserRelationshipBLL().Exists(userModel.UserId, 3);

            if (result3)
            {
                result = new UserRelationshipBLL().Update(userrelationshipmodel3);
                if (result)
                {
                    this.artDialog("提示", "保存成功！");
                }
                else
                {
                    this.artDialog("提示", "保存失败，请检查填写的信息是否正确");
                }
            }
            else
            {
                result = new UserRelationshipBLL().Insert(userrelationshipmodel3);
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

        /// <summary>
        /// 设置学校列表
        /// </summary>
        public void SetSchoolList()
        {
            List<BaseSchoolEntityEx> schoolList = new BaseSchoolBLL().GetList(" 1=1 and Status = 1");

            StringBuilder objSB = new StringBuilder();

            objSB.Append("[");

            foreach (BaseSchoolEntityEx item in schoolList)
            {
                objSB.AppendFormat("\"{0}\",", item.SchoolName);
            }
            this.txtSchoolName.Attributes.Add("data-source", objSB.ToString().TrimEnd(',') + "]");
        }

        /// <summary>
        /// 绑定学校信息
        /// </summary>
        public void BindUserSchool()
        {
            this.txtYearOfAdmission.Attributes.Add("ReadOnly", "true");

            UserSchoolEntityEx model = new UserSchoolBLL().GetModel(base.GetUserModel().UserId);

            if (model != null)
            {
                this.txtXuexin.Text = model.XuexinUsername;
                this.txtXuexin_Password.Text = model.XuexinPassword;
                this.txtSchoolName.Text = model.SchoolName;
                this.txtSchoolAdd.Text = model.SchoolAddress;
                this.txtYearOfAdmission.Text = model.YearOfAdmission.ToString("yyyy-MM-dd");
                this.ddlSchoolSystem.SelectedValue = model.SchoolSystem.ToString();
                this.ddlEducation.SelectedValue = model.Education.ToString();
                this.txtMajor.Text = model.Major;

            }
        }

        /// <summary>
        /// 绑定联系人
        /// </summary>
        public void BindUserRelationship()
        {
            List<UserRelationshipEntityEx> list = new UserRelationshipBLL().GetList(string.Format(" 1=1 and UserId = {0}", base.GetUserModel().UserId));

            if (list != null && list.Count > 0)
            {
                UserRelationshipEntityEx familyModel = list.FirstOrDefault(s => s.Type == 1);
                UserRelationshipEntityEx studentModel = list.FirstOrDefault(s => s.Type == 2);
                UserRelationshipEntityEx friendModel = list.FirstOrDefault(s => s.Type == 3);

                if (familyModel != null)
                {
                    this.txtRelativeName.Text = familyModel.Name;
                    this.txtRelationtype.Text = familyModel.Relationship;
                    this.txtRelativeMobile.Text = familyModel.Mobile;
                    this.txtRelativeProfession.Text = familyModel.Profession;
                }

                if (studentModel != null)
                {
                    this.txtMateName.Text = studentModel.Name;
                    this.txtMateMobile.Text = studentModel.Mobile;
                }

                if (friendModel != null)
                {
                    this.txtFriendName.Text = friendModel.Name;
                    this.txtFriendMobile.Text = friendModel.Mobile;
                }
            }
        }
    }
}