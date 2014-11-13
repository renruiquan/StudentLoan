using StudentLoan.BLL;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Common;
using System.Text;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using StudentLoan.Common.Logging;

namespace StudentLoan.Web.Admin
{
    public partial class CheckUserInfo : AdminBasePage
    {
        public int LoanId { get { return this.Request<int>("loanid"); } }

        public UserLoanEntityEx UserLoanModel { get { return new UserLoanBLL().GetModel(this.LoanId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (this.LoanId > 0)
                {
                    this.BindBaseCert();

                    this.BindUserSchool();

                    this.BindUserRelationship();

                    this.BindUserMustCert();

                    this.BindUserOptionalCert();
                }
                else
                {
                    this.Alert("参数不正确", "UserLoanApplyList.aspx");
                }
            }
        }


        /// <summary>
        /// 绑定个人资料数据
        /// </summary>
        protected void BindBaseCert()
        {
            UsersEntityEx userModel = new UsersBLL().GetModel(this.UserLoanModel.UserId);

            if (userModel != null)
            {
                this.lblTrueName.Text = userModel.TrueName;
                this.lblIdentityCard.Text = userModel.IdentityCard;
                this.lblUserMobile.Text = userModel.Mobile;
                this.lblGender.Text = userModel.Gender;
                this.lblNation.Text = userModel.Nation;
                this.lblBirthday.Text = userModel.Birthday.ToString("yyyy-MM-dd");
            }
        }

        /// <summary>
        /// 绑定学校信息
        /// </summary>
        protected void BindUserSchool()
        {
            UserSchoolEntityEx model = new UserSchoolBLL().GetModel(this.UserLoanModel.UserId);

            if (model != null)
            {
                this.lblXueXinUserName.Text = model.XuexinUsername;
                this.lblXueXinPassword.Text = model.XuexinPassword;
                this.lblSchoolName.Text = model.SchoolName;
                this.lblSchoolAddress.Text = model.SchoolAddress;
                this.lblYearOfAdmission.Text = model.YearOfAdmission.ToString("yyyy-MM-dd");
                this.lblSchoolSystem.Text = model.SchoolSystem.ToString();
                this.lblEducation.Text = this.GetEducationName(model.Education);
                this.lblMajor.Text = model.Major;

            }
        }

        /// <summary>
        /// 绑定用户联系人认证信息
        /// </summary>
        public void BindUserRelationship()
        {
            List<UserRelationshipEntityEx> list = new UserRelationshipBLL().GetList(string.Format(" 1=1 and UserId = {0}", this.UserLoanModel.UserId));

            if (list != null && list.Count > 0)
            {
                UserRelationshipEntityEx familyModel = list.FirstOrDefault(s => s.Type == 1);
                UserRelationshipEntityEx studentModel = list.FirstOrDefault(s => s.Type == 2);
                UserRelationshipEntityEx friendModel = list.FirstOrDefault(s => s.Type == 3);

                if (familyModel != null)
                {
                    this.lblFamilyName.Text = familyModel.Name;
                    this.lblRelationship.Text = familyModel.Relationship;
                    this.lblFamilyMobile.Text = familyModel.Mobile;
                    this.lblProfession.Text = familyModel.Profession;
                }

                if (studentModel != null)
                {
                    this.lblStudentName.Text = studentModel.Name;
                    this.lblStudentMobile.Text = studentModel.Mobile;
                }

                if (friendModel != null)
                {
                    this.lblFriendName.Text = friendModel.Name;
                    this.lblFriendMobile.Text = friendModel.Mobile;
                }
            }
        }

        /// <summary>
        /// 绑定用户必要认证信息
        /// </summary>
        public void BindUserMustCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0}", this.UserLoanModel.UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                var identityCard1 = sourceList.FirstOrDefault(s => s.Type == 0);
                var identityCard2 = sourceList.FirstOrDefault(s => s.Type == 1);
                var studentId1 = sourceList.FirstOrDefault(s => s.Type == 2);
                var studentId2 = sourceList.FirstOrDefault(s => s.Type == 3);

                if (identityCard1 != null)
                {
                    this.imgIdentityCard1.ImageUrl = identityCard1.Images;
                    this.imgIdentityCard1.Attributes.Add("onclick", string.Format("return window.open('{0}')", identityCard1.Images));
                }
                if (identityCard2 != null)
                {
                    this.imgIdentityCard2.ImageUrl = identityCard2.Images;
                    this.imgIdentityCard2.Attributes.Add("onclick", string.Format("return window.open('{0}')", identityCard2.Images));
                }
                if (studentId1 != null)
                {
                    this.imgStudentId1.ImageUrl = studentId1.Images;
                    this.imgStudentId1.Attributes.Add("onclick", string.Format("return window.open('{0}')", studentId1.Images));
                }
                if (studentId2 != null)
                {
                    this.imgStudentId2.ImageUrl = studentId2.Images;
                    this.imgStudentId2.Attributes.Add("onclick", string.Format("return window.open('{0}')", studentId2.Images));
                }
            }
        }

        /// <summary>
        /// 绑定用户可选认证信息
        /// </summary>
        public void BindUserOptionalCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0}", this.UserLoanModel.UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                var XueXin = sourceList.FirstOrDefault(s => s.Type == 4);
                var Bank = sourceList.FirstOrDefault(s => s.Type == 5);
                var Alipay = sourceList.FirstOrDefault(s => s.Type == 6);
                var Mobile = sourceList.FirstOrDefault(s => s.Type == 7);
                var Parents1 = sourceList.FirstOrDefault(s => s.Type == 8);
                var Parents2 = sourceList.FirstOrDefault(s => s.Type == 9);
                var Roommate1 = sourceList.FirstOrDefault(s => s.Type == 10);
                var Roommate2 = sourceList.FirstOrDefault(s => s.Type == 11);
                var StudentId1 = sourceList.FirstOrDefault(s => s.Type == 12);
                var StudentId2 = sourceList.FirstOrDefault(s => s.Type == 13);
                var Residencebooklet = sourceList.FirstOrDefault(s => s.Type == 14);
                var DriversLicense = sourceList.FirstOrDefault(s => s.Type == 15);
                var Awards = sourceList.FirstOrDefault(s => s.Type == 16);

                if (XueXin != null)
                {
                    this.imgXueXin.ImageUrl = XueXin.Images;
                    this.imgXueXin.Attributes.Add("onclick", string.Format("return window.open('{0}')", XueXin.Images));
                }
                if (Bank != null)
                {
                    this.imgBank.ImageUrl = Bank.Images;
                    this.imgBank.Attributes.Add("onclick", string.Format("return window.open('{0}')", Bank.Images));
                }
                if (Alipay != null)
                {
                    this.imgAlipay.ImageUrl = Alipay.Images;
                    this.imgAlipay.Attributes.Add("onclick", string.Format("return window.open('{0}')", Alipay.Images));
                }
                if (Mobile != null)
                {
                    this.imgMobile.ImageUrl = Mobile.Images;
                    this.imgMobile.Attributes.Add("onclick", string.Format("return window.open('{0}')", Mobile.Images));
                }
                if (Parents1 != null)
                {
                    this.imgParents1.ImageUrl = Parents1.Images;
                    this.imgParents1.Attributes.Add("onclick", string.Format("return window.open('{0}')", Parents1.Images));
                }
                if (Parents2 != null)
                {
                    this.imgParents2.ImageUrl = Parents2.Images;
                    this.imgParents2.Attributes.Add("onclick", string.Format("return window.open('{0}')", Parents2.Images));
                }
                if (Roommate1 != null)
                {
                    this.imgRoommateIdentityCard1.ImageUrl = Roommate1.Images;
                    this.imgRoommateIdentityCard1.Attributes.Add("onclick", string.Format("return window.open('{0}')", Roommate1.Images));
                }
                if (Roommate2 != null)
                {
                    this.imgRoommateIdentityCard2.ImageUrl = Roommate2.Images;
                    this.imgRoommateIdentityCard2.Attributes.Add("onclick", string.Format("return window.open('{0}')", Roommate2.Images));
                }
                if (StudentId1 != null)
                {
                    this.imgRoommateStudentId1.ImageUrl = StudentId1.Images;
                    this.imgRoommateStudentId1.Attributes.Add("onclick", string.Format("return window.open('{0}')", StudentId1.Images));
                }
                if (StudentId2 != null)
                {
                    this.imgRoommateStudentId2.ImageUrl = StudentId2.Images;
                    this.imgRoommateStudentId2.Attributes.Add("onclick", string.Format("return window.open('{0}')", StudentId2.Images));
                }
                if (Residencebooklet != null)
                {
                    this.imgResidencebooklet.ImageUrl = Residencebooklet.Images;
                    this.imgResidencebooklet.Attributes.Add("onclick", string.Format("return window.open('{0}')", Residencebooklet.Images));
                }
                if (DriversLicense != null)
                {
                    this.imgDriversLicense.ImageUrl = DriversLicense.Images;
                    this.imgDriversLicense.Attributes.Add("onclick", string.Format("return window.open('{0}')", DriversLicense.Images));
                }
                if (Awards != null)
                {
                    this.imgAwards.ImageUrl = Awards.Images;
                    this.imgAwards.Attributes.Add("onclick", string.Format("return window.open('{0}')", Awards.Images));
                }
            }
        }

        /// <summary>
        /// 获取分类名称
        /// </summary>
        /// <param name="loanCategory"></param>
        /// <returns></returns>
        public string GetEducationName(int id)
        {
            string result = string.Empty;

            switch (id)
            {
                case 1:
                    result = "专科";
                    break;
                case 2:
                    result = "本科";
                    break;
                case 3:
                    result = "硕士（研究生）";
                    break;
                case 4:
                    result = "博士";
                    break;
                case 5:
                    result = "博士后";
                    break;
                case 6:
                    result = "其他";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取状态名称
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public string GetStatusName(int status)
        {
            string result = string.Empty;

            switch (status)
            {
                case 0:
                    result = "<span>审核中</span>";
                    break;
                case 1:
                    result = "<span style='color:Green'>已放款</span>";
                    break;
                case 2:
                    result = "<span style='color:#ff0000'>已拒绝</span>";
                    break;
            }

            return result;
        }

        /// <summary>
        /// 获取管理员名称
        /// </summary>
        /// <param name="adminId"></param>
        /// <returns></returns>
        public string GetAdminName(int adminId)
        {
            string result = string.Empty;

            if (adminId == 0)
            {
                return string.Empty;
            }

            Dictionary<int, string> adminDictionary = new AdminBLL().GetAdminDictionary(" isLock = 1");

            return adminDictionary[adminId];
        }

        protected void btnPass_ServerClick(object sender, EventArgs e)
        {
            AdminEntityEx adminModel = Session[StudentLoanKeys.SESSION_ADMIN_INFO] as AdminEntityEx;

            UserLoanEntityEx userLoanModel = new UserLoanBLL().GetModel(this.LoanId);

            bool result = new UserLoanBLL().UpdateByAdmin(new UserLoanEntityEx()
              {
                  LoanId = this.LoanId,
                  Status = 1,
                  AdminId = adminModel.AdminId,
                  LoanMoney = userLoanModel.LoanMoney,
                  UserId = userLoanModel.UserId,
                  TotalAmortization = userLoanModel.TotalAmortization,
                  AnnualFee = userLoanModel.AnnualFee,
                  ProductId = userLoanModel.ProductId
              });

            //发短消息
            new UserMessageBLL().Insert(new UserMessageEntityEx()
            {
                PostUserName = "系统",
                Title = "材料通过",
                Content = "恭喜，您申请的借款通过审核。",
                Type = 0,
                AcceptUserName = new UsersBLL().GetModel(userLoanModel.UserId).UserName
            });

            this.Alert(string.Format("操作{0}", result == true ? "成功" : "失败"), "UserLoanApplyList.aspx");
        }

        protected void btnRefuse_ServerClick(object sender, EventArgs e)
        {
            AdminEntityEx adminModel = Session[StudentLoanKeys.SESSION_ADMIN_INFO] as AdminEntityEx;

            UserLoanEntityEx userLoanModel = new UserLoanBLL().GetModel(this.LoanId);

            if (string.IsNullOrEmpty(this.txtRefuse.Text.Trim()))
            {
                this.Alert("请填写驳回原因！");
                return;
            }
            bool result = new UserLoanBLL().UpdateByAdmin(new UserLoanEntityEx()
             {
                 LoanId = this.LoanId,
                 Status = 2,
                 AdminId = adminModel.AdminId,
                 LoanMoney = 0,
                 UserId = userLoanModel.UserId,
                 TotalAmortization = userLoanModel.TotalAmortization,
                 AnnualFee = userLoanModel.AnnualFee,
                 ProductId = userLoanModel.ProductId
             });

            //发短消息
            new UserMessageBLL().Insert(new UserMessageEntityEx()
            {
                PostUserName = "系统",
                Title = "材料驳回",
                Content = this.txtRefuse.Text.Trim(),
                Type = 0,
                AcceptUserName = new UsersBLL().GetModel(userLoanModel.UserId).UserName
            });

            this.Alert(string.Format("操作{0}", result == true ? "成功" : "失败"), "UserLoanApplyList.aspx");
        }
    }
}