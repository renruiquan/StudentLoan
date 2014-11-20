using StudentLoan.BLL;
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
    public partial class UserAccountCert : BasePage
    {
        #region 公共属性

        public int TotalPoint { get; set; }

        /// <summary>
        /// 基本验证信用积分
        /// </summary>
        public int BasePoint { get; set; }

        /// <summary>
        /// 必选验证信用积分
        /// </summary>
        public int MustPoint { get; set; }

        /// <summary>
        /// 可选验证信用积分
        /// </summary>
        public int OptionalPoint { get; set; }

        /// <summary>
        /// 正常还款积分
        /// </summary>
        public int UserLoanPoint
        {
            get
            {
                UserLoanEntityEx model = new UserLoanBLL().GetStatNormalUserLoan(this.GetUserModel().UserId);

                if (model == null)
                {
                    return 0;
                }
                else
                {
                    return model.NormalLoanCount;
                }
            }
        }

        /// <summary>
        /// 严重逾期次数
        /// </summary>
        public int BreakContractUserLoan
        {
            get
            {
                UserLoanEntityEx model = new UserLoanBLL().GetStatBreakContractUserLoan(this.GetUserModel().UserId);
                if (model == null)
                {
                    return 0;
                }
                else
                {
                    return -model.TotalBreakCount;
                }
            }
        }

        /// <summary>
        /// 用户信息
        /// </summary>
        public UsersEntityEx UserModel { get { return new UsersBLL().GetModel(base.GetUserModel().UserId); } }

        /// <summary>
        /// 学校信息
        /// </summary>
        public UserSchoolEntityEx UserSchoolModel { get { return new UserSchoolBLL().GetModel(base.GetUserModel().UserId); } }

        /// <summary>
        /// 家庭信息
        /// </summary>
        public UserRelationshipEntityEx FamilyModel { get; set; }
        /// <summary>
        /// 同学信息
        /// </summary>
        public UserRelationshipEntityEx StudentModel { get; set; }

        /// <summary>
        /// 朋友信息
        /// </summary>
        public UserRelationshipEntityEx FriendModel { get; set; }

        /// <summary>
        /// 手持身份证照片信息
        /// </summary>
        public UserCertificationEntityEx IdentityCard_1 { get; set; }
        /// <summary>
        /// 身份证正面信息
        /// </summary>
        public UserCertificationEntityEx IdentityCard_2 { get; set; }

        /// <summary>
        /// 学信网信息
        /// </summary>
        public UserCertificationEntityEx XueXin { get; set; }

        /// <summary>
        /// 银行流水信息
        /// </summary>
        public UserCertificationEntityEx Bank { get; set; }

        /// <summary>
        /// 支付宝流水信息
        /// </summary>
        public UserCertificationEntityEx Alipay { get; set; }

        /// <summary>
        /// 手机通话详单信息
        /// </summary>
        public UserCertificationEntityEx Mobile { get; set; }

        /// <summary>
        /// 父母身份证正面
        /// </summary>
        public UserCertificationEntityEx Parents1 { get; set; }

        /// <summary>
        /// 父母身份证反面
        /// </summary>
        public UserCertificationEntityEx Parents2 { get; set; }

        /// <summary>
        /// 室友手持身份证信息
        /// </summary>
        public UserCertificationEntityEx RoommateIdentityCard1 { get; set; }

        /// <summary>
        /// 室友身份证正面信息
        /// </summary>
        public UserCertificationEntityEx RoommateIdentityCard2 { get; set; }

        /// <summary>
        /// 学生证正面
        /// </summary>
        public UserCertificationEntityEx StudentId1 { get; set; }

        /// <summary>
        /// 学生证内容
        /// </summary>
        public UserCertificationEntityEx StudentId2 { get; set; }

        /// <summary>
        /// 室友学生证正面
        /// </summary>
        public UserCertificationEntityEx RoommateStudentId1 { get; set; }

        /// <summary>
        /// 室友学生证内容
        /// </summary>
        public UserCertificationEntityEx RoommateStudentId2 { get; set; }

        /// <summary>
        /// 户口本信息
        /// </summary>
        public UserCertificationEntityEx Residencebooklet { get; set; }

        /// <summary>
        /// 驾照信息
        /// </summary>
        public UserCertificationEntityEx DriversLicense { get; set; }

        /// <summary>
        /// 在校获奖信息
        /// </summary>
        public UserCertificationEntityEx Awards { get; set; }

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                #region 设置导航样式

                string id = MethodBase.GetCurrentMethod().DeclaringType.Name;

                Control objControl = Master.FindControl(id);

                if (objControl != null)
                {
                    HtmlAnchor objAnchor = objControl as HtmlAnchor;

                    objAnchor.Attributes.Add("class", "active");
                }

                #endregion

                this.BindData();

                this.BindUserRelationship();

                this.BindUserBasePoint();

                this.BindUserMustPoint();

                this.BindUserOptionalPoint();

                this.BindTotalPoint();
            }
        }

        public void BindData()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0}", base.GetUserModel().UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                this.IdentityCard_1 = sourceList.FirstOrDefault(s => s.Type == 0);
                this.IdentityCard_2 = sourceList.FirstOrDefault(s => s.Type == 1);
                this.StudentId1 = sourceList.FirstOrDefault(s => s.Type == 2);
                this.StudentId2 = sourceList.FirstOrDefault(s => s.Type == 3);
                this.XueXin = sourceList.FirstOrDefault(s => s.Type == 4);
                this.Bank = sourceList.FirstOrDefault(s => s.Type == 5);
                this.Alipay = sourceList.FirstOrDefault(s => s.Type == 6);
                this.Mobile = sourceList.FirstOrDefault(s => s.Type == 7);
                this.Parents1 = sourceList.FirstOrDefault(s => s.Type == 8);
                this.Parents2 = sourceList.FirstOrDefault(s => s.Type == 9);
                this.RoommateIdentityCard1 = sourceList.FirstOrDefault(s => s.Type == 10);
                this.RoommateIdentityCard2 = sourceList.FirstOrDefault(s => s.Type == 11);
                this.RoommateStudentId1 = sourceList.FirstOrDefault(s => s.Type == 12);
                this.RoommateStudentId2 = sourceList.FirstOrDefault(s => s.Type == 13);
                this.Residencebooklet = sourceList.FirstOrDefault(s => s.Type == 14);
                this.DriversLicense = sourceList.FirstOrDefault(s => s.Type == 15);
                this.Awards = sourceList.FirstOrDefault(s => s.Type == 16);
            }
        }

        public void BindUserRelationship()
        {
            List<UserRelationshipEntityEx> list = new UserRelationshipBLL().GetList(string.Format(" 1=1 and UserId = {0}", base.GetUserModel().UserId));
            if (list != null && list.Count > 0)
            {
                FamilyModel = list.FirstOrDefault(s => s.Type == 1);
                StudentModel = list.FirstOrDefault(s => s.Type == 2);
                FriendModel = list.FirstOrDefault(s => s.Type == 3);
            }
        }

        /// <summary>
        /// 绑定基础认证积分
        /// </summary>
        public void BindUserBasePoint()
        {
            if (this.UserModel != null)
            {
                if (!string.IsNullOrEmpty(this.UserModel.TrueName) && !string.IsNullOrEmpty(this.UserModel.IdentityCard) && !string.IsNullOrEmpty(this.UserModel.Mobile)
                                                && !string.IsNullOrEmpty(this.UserModel.Gender) && !string.IsNullOrEmpty(this.UserModel.Nation) && (this.UserModel.Birthday != null && this.UserModel.Birthday != default(DateTime)))
                {
                    this.BasePoint += 10;
                }
            }

            if (this.UserSchoolModel != null)
            {
                if (!string.IsNullOrEmpty(this.UserSchoolModel.SchoolName) && !string.IsNullOrEmpty(this.UserSchoolModel.SchoolAddress) && (this.UserSchoolModel.YearOfAdmission != null && this.UserSchoolModel.YearOfAdmission != default(DateTime))
                                                 && this.UserSchoolModel.SchoolSystem > 0 && this.UserSchoolModel.Education > 0 && !string.IsNullOrEmpty(this.UserSchoolModel.Major))
                {
                    this.BasePoint += 10;
                }
            }

            if (this.FamilyModel != null)
            {
                if (!string.IsNullOrEmpty(this.FamilyModel.Name) && !string.IsNullOrEmpty(this.FamilyModel.Relationship) &&
                                                     !string.IsNullOrEmpty(this.FamilyModel.Mobile) &&
                                                     !string.IsNullOrEmpty(this.StudentModel.Name) && !string.IsNullOrEmpty(this.StudentModel.Mobile) &&
                                                     !string.IsNullOrEmpty(this.FriendModel.Name) && !string.IsNullOrEmpty(this.FriendModel.Mobile))
                {
                    this.BasePoint += 10;
                }
            }
        }

        /// <summary>
        /// 绑定必选验证积分
        /// </summary>
        public void BindUserMustPoint()
        {
            if (this.IdentityCard_2 != null)
            {
                this.MustPoint += this.IdentityCard_2.Point;
            }

            if (this.StudentId2 != null)
            {
                this.MustPoint += this.StudentId2.Point;
            }
        }

        /// <summary>
        /// 绑定可选验证积分
        /// </summary>
        public void BindUserOptionalPoint()
        {
            if (this.XueXin != null)
            {
                this.OptionalPoint += this.XueXin.Point;
            }

            if (this.Bank != null)
            {
                this.OptionalPoint += this.Bank.Point;
            }

            if (this.Alipay != null)
            {
                this.OptionalPoint += this.Alipay.Point;
            }
            if (this.Mobile != null)
            {
                this.OptionalPoint += this.Mobile.Point;
            }
            if (this.Parents1 != null)
            {
                this.OptionalPoint += this.Parents1.Point;
            }
            if (this.Parents2 != null)
            {
                this.OptionalPoint += this.Parents2.Point;
            }

            if (this.RoommateStudentId2 != null)
            {
                this.OptionalPoint += this.RoommateStudentId2.Point;
            }
            if (this.RoommateIdentityCard2 != null)
            {
                this.OptionalPoint += this.RoommateIdentityCard2.Point;
            }
            if (this.Residencebooklet != null)
            {
                this.OptionalPoint += this.Residencebooklet.Point;
            }
            if (this.DriversLicense != null)
            {
                this.OptionalPoint += this.DriversLicense.Point;
            }
            if (this.Awards != null)
            {
                this.OptionalPoint += this.Awards.Point;
            }
        }

        /// <summary>
        /// 绑定总积分
        /// </summary>
        public void BindTotalPoint()
        {
            this.TotalPoint += this.BasePoint;
            this.TotalPoint += this.MustPoint;
            this.TotalPoint += this.OptionalPoint;
            this.TotalPoint += this.UserLoanPoint;
            this.TotalPoint += this.BreakContractUserLoan;
        }
    }
}