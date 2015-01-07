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

                    this.BindMobilePictureCert();

                    this.BindBankPictureCert();

                    this.BindAlipayPictureCert();

                    this.txtRefuse.Text = string.IsNullOrEmpty(this.UserLoanModel.Description) == true ? string.Format(@"尊敬的用户:{0}，您于{1}提交的贷款认证资料未通过审核，请根据申请提示完善资料后再提交审核。如有疑问，请咨询：0527-88802678", this.UserLoanModel.UserName, UserLoanModel.CreateTime) : this.UserLoanModel.Description;
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
                var identityCard3 = sourceList.FirstOrDefault(s => s.Type == 17);
                var studentId1 = sourceList.FirstOrDefault(s => s.Type == 2);
                var studentId2 = sourceList.FirstOrDefault(s => s.Type == 3);
                var studentId3 = sourceList.FirstOrDefault(s => s.Type == 18);

                if (identityCard1 != null)
                {
                    this.imgIdentityCard1.ImageUrl = identityCard1.Images;
                    this.imgIdentityCard1.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", identityCard1.Images));

                }
                if (identityCard2 != null)
                {
                    this.imgIdentityCard2.ImageUrl = identityCard2.Images;
                    this.imgIdentityCard2.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", identityCard2.Images));

                    this.mainImgIdentityCard.ImageUrl = identityCard2.Images;
                    this.mainImgIdentityCard.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", identityCard2.Images));

                }

                if (identityCard3 != null)
                {
                    this.imgIdentityCard3.ImageUrl = identityCard3.Images;
                    this.imgIdentityCard3.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", identityCard3.Images));
                }

                if (studentId1 != null)
                {
                    this.imgStudentId1.ImageUrl = studentId1.Images;
                    this.imgStudentId1.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", studentId1.Images));
                }
                if (studentId2 != null)
                {
                    this.imgStudentId2.ImageUrl = studentId2.Images;
                    this.imgStudentId2.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", studentId2.Images));

                    this.mainImgStudent2.ImageUrl = studentId2.Images;
                    this.mainImgStudent2.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", studentId2.Images));

                }

                if (studentId3 != null)
                {
                    this.imgStudentId3.ImageUrl = studentId3.Images;
                    this.imgStudentId3.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", studentId3.Images));
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
                //var Bank = sourceList.FirstOrDefault(s => s.Type == 5);
                //var Alipay = sourceList.FirstOrDefault(s => s.Type == 6);
                //var Mobile = sourceList.FirstOrDefault(s => s.Type == 7);
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
                    this.imgXueXin.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", XueXin.Images));

                }
                //if (Bank != null)
                //{
                //    this.imgBank.ImageUrl = Bank.Images;
                //    this.imgBank.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Bank.Images));
                //}
                //if (Alipay != null)
                //{
                //    this.imgAlipay.ImageUrl = Alipay.Images;
                //    this.imgAlipay.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Alipay.Images));
                //}
                //if (Mobile != null)
                //{
                //    this.imgMobile.ImageUrl = Mobile.Images;
                //    this.imgMobile.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Mobile.Images));
                //}
                if (Parents1 != null)
                {
                    this.imgParents1.ImageUrl = Parents1.Images;
                    this.imgParents1.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Parents1.Images));
                }
                if (Parents2 != null)
                {
                    this.imgParents2.ImageUrl = Parents2.Images;
                    this.imgParents2.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Parents2.Images));
                }
                if (Roommate1 != null)
                {
                    this.imgRoommateIdentityCard1.ImageUrl = Roommate1.Images;
                    this.imgRoommateIdentityCard1.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Roommate1.Images));
                }
                if (Roommate2 != null)
                {
                    this.imgRoommateIdentityCard2.ImageUrl = Roommate2.Images;
                    this.imgRoommateIdentityCard2.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Roommate2.Images));
                }
                if (StudentId1 != null)
                {
                    this.imgRoommateStudentId1.ImageUrl = StudentId1.Images;
                    this.imgRoommateStudentId1.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", StudentId1.Images));
                }
                if (StudentId2 != null)
                {
                    this.imgRoommateStudentId2.ImageUrl = StudentId2.Images;
                    this.imgRoommateStudentId2.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", StudentId2.Images));

                }
                if (Residencebooklet != null)
                {
                    this.imgResidencebooklet.ImageUrl = Residencebooklet.Images;
                    this.imgResidencebooklet.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Residencebooklet.Images));
                }
                if (DriversLicense != null)
                {
                    this.imgDriversLicense.ImageUrl = DriversLicense.Images;
                    this.imgDriversLicense.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", DriversLicense.Images));
                }
                if (Awards != null)
                {
                    this.imgAwards.ImageUrl = Awards.Images;
                    this.imgAwards.Attributes.Add("onclick", string.Format("return window.open('/Admin/ShowImages.aspx?picurl={0}')", Awards.Images));
                }
            }
        }

        public void BindMobilePictureCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" UserId={0} and type=7 ", this.UserLoanModel.UserId));

            if (sourceList == null || sourceList.Count == 0)
            {
                litMobile.Text = "<div class=\"active item\"><img id=\"imgMobile_0\" style='width:350px;height:250px;' src=\"../css/img/admin/card.jpg\" /></div>";
            }
            else
            {
                StringBuilder objSB = new StringBuilder();
                StringBuilder objSB2 = new StringBuilder();

                for (int i = 0; i < sourceList.Count; i++)
                {
                    if (i == 0)
                    {
                        objSB.AppendFormat("<div class=\"active item\"><a target='_blank' href=\"/Admin/ShowImages.aspx?picurl={0}\"><img id=\"imgMobile_0\"  style='width:350px;height:250px;' src=\"{1}\" /></a></div>", sourceList[i].Images, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel\" data-slide-to=\"{0}\" class=\"active\"></li>", i);
                    }
                    else
                    {
                        objSB.AppendFormat("<div class=\"item\"><a  target='_blank' href=\"/Admin/ShowImages.aspx?picurl={0}\"><img id=\"imgMobile_{1}\"  style='width:350px;height:250px;' src=\"{2}\" /></a></div>", sourceList[i].Images, i, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel\" data-slide-to=\"{0}\"></li>", i);
                    }

                }

                litMobile.Text = objSB.ToString();
                litMobileIndex.Text = objSB2.ToString();

            }
        }

        public void BindBankPictureCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" UserId={0} and type=5 ", this.UserLoanModel.UserId));

            if (sourceList == null || sourceList.Count == 0)
            {
                litBank.Text = "<div class=\"active item\"><img id=\"imgBank_0\" style='width:350px;height:250px;' src=\"../css/img/admin/card.jpg\" /></div>";
            }
            else
            {
                StringBuilder objSB = new StringBuilder();
                StringBuilder objSB2 = new StringBuilder();

                for (int i = 0; i < sourceList.Count; i++)
                {
                    if (i == 0)
                    {
                        objSB.AppendFormat("<div class=\"active item\"><a target='_blank' href=\"/Admin/ShowImages.aspx?picurl={0}\"><img id=\"imgBank_0\" style='width:350px;height:250px;' src=\"{1}\" /></a></div>", sourceList[i].Images, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel2\" data-slide-to=\"{0}\" class=\"active\"></li>", i);
                    }
                    else
                    {
                        objSB.AppendFormat("<div class=\"item\"><a target='_blank' href=\"/Admin/ShowImages.aspx?picurl={0}\"><img id=\"imgBank_{1}\"  style='width:350px;height:250px;' src=\"{2}\" /></a></div>", sourceList[i].Images, i, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel2\" data-slide-to=\"{0}\"></li>", i);
                    }

                }

                litBank.Text = objSB.ToString();
                litBankIndex.Text = objSB2.ToString();

            }
        }

        public void BindAlipayPictureCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" UserId={0} and type=6 ", this.UserLoanModel.UserId));

            if (sourceList == null || sourceList.Count == 0)
            {
                litAlipay.Text = "<div class=\"active item\"><img id=\"imgAlipay_0\" style='width:350px;height:250px;' src=\"../css/img/admin/card.jpg\" /></div>";
            }
            else
            {
                StringBuilder objSB = new StringBuilder();
                StringBuilder objSB2 = new StringBuilder();

                for (int i = 0; i < sourceList.Count; i++)
                {
                    if (i == 0)
                    {
                        objSB.AppendFormat("<div class=\"active item\"><a target='_blank' href=\"/Admin/ShowImages.aspx?picurl={0}\"><img id=\"imgAlipay_0\" style='width:350px;height:250px;' src=\"{1}\" /></a></div>", sourceList[i].Images, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel3\" data-slide-to=\"{0}\" class=\"active\"></li>", i);
                    }
                    else
                    {
                        objSB.AppendFormat("<div class=\"item\"><a target='_blank' href=\"/Admin/ShowImages.aspx?picurl={0}\"><img id=\"imgAlipay_{1}\"  style='width:350px;height:250px;' src=\"{2}\" /></a></div>", sourceList[i].Images, i, sourceList[i].Images);
                        objSB2.AppendFormat("<li data-target=\"#myCarousel3\" data-slide-to=\"{0}\"></li>", i);
                    }

                }

                litAlipay.Text = objSB.ToString();
                litAlipayIndex.Text = objSB2.ToString();

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
                Content = string.Format("尊敬的用户:{0}，您于{1}提交的贷款申请已经通过审核，申请金额为：{2}元，【学子易贷】已将款打入您的账号中。", userLoanModel.UserName, userLoanModel.CreateTime.ToString("yyyy-MM-dd"), userLoanModel.LoanMoney),
                Type = 0,
                AcceptUserName = new UsersBLL().GetModel(userLoanModel.UserId).UserName
            });

            StudentLoan.API.Message.Send(new UsersBLL().GetModel(userLoanModel.UserId).Mobile, string.Format("您所申请的“点豆成金”业务已通过审核，您所申领的U豆数量为{0}，将在1个工作日内将U豆送到您的小金库。【学子易贷】", userLoanModel.LoanMoney));

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
                 ProductId = userLoanModel.ProductId,
                 Description = this.txtRefuse.Text.Trim(),
                 CanModify = 1
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

            StudentLoan.API.Message.Send(new UsersBLL().GetModel(userLoanModel.UserId).Mobile, "您所申请的“点豆成金”业务因资料不全而未通过审核，具体请登录网站个人中心查看。【学子易贷】");


            this.Alert(string.Format("操作{0}", result == true ? "成功" : "失败"), "UserLoanApplyList.aspx");
        }

        public void EnabledUserInfo()
        {
            int userId = this.UserLoanModel.UserId;

            //是否可以更新用户资料
            UsersEntityEx model = new Model.UsersEntityEx()
            {
                UserId = userId,
                CanModify = 0
            };

            bool result = new UsersBLL().UpdateCanModifyValue(model);


            //是否可以更新用户认证信息
            UserCertificationEntityEx certModel = new UserCertificationEntityEx()
            {
                UserId = userId,
                CanModify = 0
            };

            result = new UserCertificationBLL().UpdateByAdmin(certModel);

            //是否可以更新学校信息
            UserSchoolEntityEx schoolModel = new UserSchoolEntityEx()
            {
                UserId = userId,
                Status = 0
            };


            result = new UserSchoolBLL().UpdateByAdmin(schoolModel);


            //是否可以更新联系人信息
            UserRelationshipEntityEx relateionshipModel = new UserRelationshipEntityEx()
            {
                UserId = userId,
                Status = 0
            };

            result = new UserRelationshipBLL().UpdateByAdmin(relateionshipModel);
        }
    }
}