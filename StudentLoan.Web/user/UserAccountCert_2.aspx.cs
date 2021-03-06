﻿using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.user
{
    public partial class UserAccountCert_2 : BasePage
    {
        Regex mobileRegex = new Regex(@"^\d{11}$");

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
            UsersEntityEx userModel = base.GetUserModel();

            userModel = new UsersBLL().GetModel(userModel.UserId);

            if (string.IsNullOrEmpty(userModel.IdentityCard))
            {
                this.txtIdentityCard.Attributes.Add("ajaxurl", "/tools/validate_user_identitycard.ashx");
            }
           

            if (userModel.CanModify == 0)
            {
                this.txtTruename.Attributes.Add("disabled", "disabled");
                this.txtMobile.Attributes.Add("disabled", "disabled");
                this.txtValidatecode.Attributes.Add("disabled", "disabled");
                this.btnSendMessage.Attributes.Add("disabled", "disabled");
                this.ddlGender.Attributes.Add("disabled", "disabled");
                this.ddlNation.Attributes.Add("disabled", "disabled");
                this.txtBirthday.Attributes.Add("disabled", "disabled");
                this.txtIdentityCard.Attributes.Add("disabled", "disabled");
                this.btnSaveStepOne.Visible = false;
            }
            else
            {
                this.txtBirthday.Attributes.Add("readonly", "true");
            }

            txtTruename.Text = userModel.TrueName;
            txtIdentityCard.Text = userModel.IdentityCard;
            txtMobile.Text = userModel.Mobile;
            ddlGender.SelectedValue = userModel.Gender;
            ddlNation.SelectedValue = userModel.Nation;
            txtBirthday.Text = userModel.Birthday.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : userModel.Birthday.ToString("yyyy-MM-dd");

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
            string validateCode = this.txtValidatecode.Text.Trim();
            string mobileCode = Session["MobileCode"] == null ? string.Empty : Session["MobileCode"].ToString();

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

            Regex identityCardRegex = new Regex(@"^\d{14,17}[a-zA-Z\d]$");

            if (!identityCardRegex.IsMatch(identityCard))
            {
                this.artDialog("错误", "请输入有效的身份证号码！");
                return;
            }

            DateTime Id_birthday = default(DateTime);

            if (identityCard.Length == 15)
            {
                int year = string.Format("19{0}", identityCard.Substring(6, 2)).Convert<int>();
                int month = identityCard.Substring(8, 2).Convert<int>();
                int day = identityCard.Substring(10, 2).Convert<int>();

                Id_birthday = new DateTime(year, month, day);
            }
            if (identityCard.Length == 18)
            {
                int year = identityCard.Substring(6, 4).Convert<int>();
                int month = identityCard.Substring(10, 2).Convert<int>();
                int day = identityCard.Substring(12, 2).Convert<int>();

                Id_birthday = new DateTime(year, month, day);
            }

            if (Id_birthday.ToString("yyyy-MM-dd") != birthday)
            {
                this.artDialog("错误", "您填写的出生日期与身份证不符，请检查后重写！");
                return;
            }

            if (string.IsNullOrEmpty(mobile))
            {
                this.artDialog("错误", "电话号码不能为空，请重新填写");
                return;
            }

            if (!mobileRegex.IsMatch(mobile))
            {
                this.artDialog("错误", "请输入正确的11位手机号码，如：15900001111");
                return;
            }
            if (string.IsNullOrEmpty(mobileCode))
            {
                this.artDialog("验证码已过期,请重新获取！");
                return;
            }

            if (validateCode != mobileCode)
            {
                this.artDialog("手机验证码不正确！");
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

            //请除使用过的短信验证码
            Session["MobileCode"] = null;

            userModel.TrueName = truename;
            userModel.Mobile = mobile;
            userModel.IdentityCard = identityCard;
            userModel.Gender = gender;
            userModel.Nation = nation;
            userModel.Birthday = Convert.ToDateTime(birthday);

            bool result = new UsersBLL().Update(userModel);

            if (result)
            {
                userModel = new UsersBLL().GetModel(userModel.UserId);

                if (string.IsNullOrEmpty(userModel.Remark))
                {
                    new UsersBLL().UpdatePoint(userModel.UserId, 10);
                }

                userModel = new UsersBLL().GetModel(userModel.UserId);
                //写入Cookies
                this.WriteCookie("SLRememberName", userModel.UserName, 14400);
                this.WriteCookie("UserName", "StudentLoan", userModel.UserName);
                this.WriteCookie("UserPwd", "StudentLoan", userModel.Password);

                this.artDialog("提示", "保存成功！请继续填写其他信息");
               
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
            //   string xuexinusername = txtXuexin.Text.Trim().HtmlEncode();
            //  string xuexinpass = txtXuexin_Password.Text.Trim().HtmlEncode();
            string schoolname = txtSchoolName.Text.Trim().HtmlEncode();
            string schooladd = txtSchoolAdd.Text.Trim().HtmlEncode();
            string yearofadmission = txtYearOfAdmission.Text.Trim().HtmlEncode();
            int schoolsystem = Convert.ToInt32(ddlSchoolSystem.SelectedValue);
            int education = Convert.ToInt32(ddlEducation.SelectedValue);
            string major = txtMajor.Text.Trim().HtmlEncode();

           
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
            userschoolModel.XuexinUsername = string.Empty;  // xuexinusername;
            userschoolModel.XuexinPassword = string.Empty;//xuexinpass;
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
            // string relativeprofession = txtRelativeProfession.Text.Trim().HtmlEncode();
            string relativetype = txtRelationtype.Text.Trim().HtmlEncode();
            string relativemobile = txtRelativeMobile.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(relativename) || string.IsNullOrEmpty(relativetype) || string.IsNullOrEmpty(relativemobile))
            {
                this.artDialog("提示", "请将亲属信息填写完整");
                return;
            }

            if (!mobileRegex.IsMatch(relativemobile))
            {
                this.artDialog("错误", "请输入正确的11位手机号码，如：15900001111");
                return;
            }

            string matename = txtMateName.Text.Trim().HtmlEncode();
            string matemobile = txtMateMobile.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(matename) || string.IsNullOrEmpty(matemobile))
            {
                this.artDialog("提示", "请将同学(同室)信息填写完整");
                return;
            }

            if (!mobileRegex.IsMatch(matemobile))
            {
                this.artDialog("错误", "请输入正确的11位手机号码，如：15900001111");
                return;
            }

            string friendname = txtFriendName.Text.Trim().HtmlEncode();
            string friendmobile = txtFriendMobile.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(friendname) || string.IsNullOrEmpty(friendmobile))
            {
                this.artDialog("提示", "请将朋友信息填写完整");
                return;
            }
            if (!mobileRegex.IsMatch(friendmobile))
            {
                this.artDialog("错误", "请输入正确的11位手机号码，如：15900001111");
                return;
            }


            if (txtRelativeMobile.Text.Trim() == txtFriendMobile.Text.Trim() || txtRelativeMobile.Text.Trim() == txtMateMobile.Text.Trim())
            {
                this.artDialog("错误", "联系人的手机号码不能相同！");
                return;
            }
            if (txtFriendMobile.Text.Trim() == txtMateMobile.Text.Trim())
            {
                this.artDialog("错误", "联系人的手机号码不能相同！");
                return;
            }

            //亲属
            userrelationshipmodel.UserId = userModel.UserId;
            userrelationshipmodel.Name = relativename;
            userrelationshipmodel.Profession = string.Empty; //relativeprofession;
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
            this.txtYearOfAdmission.Attributes.Add("readonly", "true");

            UserSchoolEntityEx model = new UserSchoolBLL().GetModel(base.GetUserModel().UserId);

            UsersEntityEx userModel = base.GetUserModel();

            userModel = new UsersBLL().GetModel(userModel.UserId);

            if (model != null)
            {
                // this.txtXuexin.Text = model.XuexinUsername;
                //  this.txtXuexin_Password.Text = model.XuexinPassword;
                this.txtSchoolName.Text = model.SchoolName;
                this.txtSchoolAdd.Text = model.SchoolAddress;
                this.txtYearOfAdmission.Text = model.YearOfAdmission.ToString("yyyy-MM-dd") == "0001-01-01" ? "" : model.YearOfAdmission.ToString("yyyy-MM-dd");
                this.ddlSchoolSystem.SelectedValue = model.SchoolSystem.ToString();
                this.ddlEducation.SelectedValue = model.Education.ToString();
                this.txtMajor.Text = model.Major;

                if (userModel.CanModify == 0)
                {
                    this.txtSchoolName.Attributes.Add("disabled", "disabled");
                    this.txtSchoolAdd.Attributes.Add("disabled", "disabled");
                    this.txtYearOfAdmission.Attributes.Add("disabled", "disabled");
                    this.ddlSchoolSystem.Attributes.Add("disabled", "disabled");
                    this.ddlEducation.Attributes.Add("disabled", "disabled");
                    this.txtMajor.Attributes.Add("disabled", "disabled");

                    this.btnSaveStepTwo.Visible = false;
                }


            }
        }

        /// <summary>
        /// 绑定联系人
        /// </summary>
        public void BindUserRelationship()
        {
            List<UserRelationshipEntityEx> list = new UserRelationshipBLL().GetList(string.Format(" 1=1 and UserId = {0}", base.GetUserModel().UserId));

            UsersEntityEx userModel = base.GetUserModel();

            userModel = new UsersBLL().GetModel(userModel.UserId);

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
                    // this.txtRelativeProfession.Text = familyModel.Profession;

                    if (userModel.CanModify == 0)
                    {
                        this.txtRelativeName.Attributes.Add("disabled", "disabled");
                        this.txtRelationtype.Attributes.Add("disabled", "disabled");
                        this.txtRelativeMobile.Attributes.Add("disabled", "disabled");

                        this.btnSaveStepFinal.Visible = false;
                    }
                }

                if (studentModel != null)
                {
                    this.txtMateName.Text = studentModel.Name;
                    this.txtMateMobile.Text = studentModel.Mobile;

                    if (userModel.CanModify == 0)
                    {
                        this.txtMateName.Attributes.Add("disabled", "disabled");
                        this.txtMateMobile.Attributes.Add("disabled", "disabled");
                        this.btnSaveStepFinal.Visible = false;
                    }

                }

                if (friendModel != null)
                {
                    this.txtFriendName.Text = friendModel.Name;
                    this.txtFriendMobile.Text = friendModel.Mobile;

                    if (userModel.CanModify == 0)
                    {
                        this.txtFriendName.Attributes.Add("disabled", "disabled");
                        this.txtFriendMobile.Attributes.Add("disabled", "disabled");
                        this.btnSaveStepFinal.Attributes.Add("disabled", "disabled");
                    }
                }
            }
        }
    }
}