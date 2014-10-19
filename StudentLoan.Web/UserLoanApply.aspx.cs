using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudentLoan.Model;
using StudentLoan.BLL;
using StudentLoan.Common;

namespace StudentLoan.Web
{
    public partial class UserLoanApply : BasePage
    {
        private int ProductId { get { return this.Request<int>("productId", 1); } }

        private ProductEntityEx ProductModel { get { return new ProductBLL().GetModel(this.ProductId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindDropDownList();
            }
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            UsersEntityEx userModel = userModel = base.GetUserModel();

            if (userModel == null)
            {
                this.artDialog("提示", "登录超时，请重新登录", "login.aspx");
                return;
            }

            decimal shouldRepayMoney = 0;
            int loanTypeId = this.ddlLoanTypeId.SelectedValue.Convert<int>(this.ProductId);
            string loanTitle = this.txtLoanTitle.Text.Trim().HtmlEncode();
            decimal loanMoney = Math.Abs(this.ddlLoanMoney.SelectedValue.Convert<decimal>(0));
            int loanCategory = this.ddlLoanCategory.SelectedValue.Convert<int>(1);
            int totalAmortization = this.ddlTotalAmortization.SelectedValue.Convert<int>(1);
            string loanDescription = this.txtLoanDescription.Text.Trim().HtmlEncode();

            if (string.IsNullOrEmpty(loanTitle))
            {
                this.artDialog("贷款标题不能为空");
                return;
            }
            if (loanMoney < ProductModel.ProductMinMoney || loanMoney > ProductModel.ProductMaxMoney)
            {
                this.artDialog("贷款金额不正确");
                return;
            }

            //计算应用金额
            shouldRepayMoney = loanMoney * ProductModel.BaseAnnualFee * totalAmortization + loanMoney;


            UserLoanEntityEx userLoanModel = new UserLoanEntityEx();

            userLoanModel.LoanNo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            userLoanModel.UserId = userModel.UserId;
            userLoanModel.ProductId = ProductModel.ProductId;
            userLoanModel.LoanTitle = loanTitle;
            userLoanModel.LoanMoney = loanMoney;
            userLoanModel.LoanTypeId = loanTypeId;
            userLoanModel.LoanCategory = loanCategory;
            userLoanModel.ShouldRepayMoney = shouldRepayMoney;
            userLoanModel.TotalAmortization = totalAmortization;
            userLoanModel.LoanDescription = loanDescription;

            UserLoanBLL bll = new UserLoanBLL();

            bool result = bll.Insert(userLoanModel);


            this.artDialog(string.Format("提交申请{0}", result == true ? "成功，请等待管理员审核！" : "失败"));

        }


        /// <summary>
        /// 绑定借款金额
        /// </summary>
        private void BindDropDownList()
        {
            if (this.ProductId == 0)
            {
                this.artDialog("参数不正确");
                return;
            }

            ProductEntityEx productModel = new ProductBLL().GetModel(this.ProductId);

            this.ddlLoanMoney.Items.Clear();
            this.ddlTotalAmortization.Items.Clear();

            if (this.ProductId == 1)
            {
                //一般贷款
                this.ValidateUserInfo();
                this.ValidateUserSchool();
                this.ValidateUserRelationship();

                this.ddlLoanMoney.Items.Add(new ListItem("1000元", "1000"));
                this.ddlLoanMoney.Items.Add(new ListItem("2000元", "2000"));
                this.ddlLoanMoney.Items.Add(new ListItem("3000元", "3000"));
                this.ddlLoanMoney.Items.Add(new ListItem("4000元", "4000"));
                this.ddlLoanMoney.Items.Add(new ListItem("5000元", "5000"));

                this.ddlTotalAmortization.Items.Add(new ListItem("1个月", "1"));
                this.ddlTotalAmortization.Items.Add(new ListItem("2个月", "2"));
                this.ddlTotalAmortization.Items.Add(new ListItem("3个月", "3"));
                this.ddlTotalAmortization.Items.Add(new ListItem("4个月", "4"));
            }
            else if (this.ProductId == 2)
            {
                //高额贷款
                this.ValidateUserInfo();
                this.ValidateOtherCert();

                this.ddlLoanMoney.Items.Add(new ListItem("6000元", "6000"));
                this.ddlLoanMoney.Items.Add(new ListItem("7000元", "7000"));
                this.ddlLoanMoney.Items.Add(new ListItem("8000元", "8000"));
                this.ddlLoanMoney.Items.Add(new ListItem("9000元", "9000"));
                this.ddlLoanMoney.Items.Add(new ListItem("10000元", "10000"));

                this.ddlTotalAmortization.Items.Add(new ListItem("1个月", "1"));
                this.ddlTotalAmortization.Items.Add(new ListItem("2个月", "2"));
                this.ddlTotalAmortization.Items.Add(new ListItem("3个月", "3"));
                this.ddlTotalAmortization.Items.Add(new ListItem("4个月", "4"));
                this.ddlTotalAmortization.Items.Add(new ListItem("5个月", "5"));
            }
            else if (this.ProductId == 3)
            {
                //随时贷款
                this.ValidateUserInfo();
                this.ValidateOtherCert();

                this.ddlLoanMoney.Items.Add(new ListItem("1000元", "1000"));
                this.ddlLoanMoney.Items.Add(new ListItem("2000元", "2000"));
                this.ddlLoanMoney.Items.Add(new ListItem("3000元", "3000"));
                this.ddlLoanMoney.Items.Add(new ListItem("4000元", "4000"));
                this.ddlLoanMoney.Items.Add(new ListItem("5000元", "5000"));
                this.ddlLoanMoney.Items.Add(new ListItem("6000元", "6000"));
                this.ddlLoanMoney.Items.Add(new ListItem("7000元", "7000"));
                this.ddlLoanMoney.Items.Add(new ListItem("8000元", "8000"));
                this.ddlLoanMoney.Items.Add(new ListItem("9000元", "9000"));
                this.ddlLoanMoney.Items.Add(new ListItem("10000元", "10000"));

                this.ddlTotalAmortization.Items.Add(new ListItem("最多可借90天", "90"));
            }
        }

        /// <summary>
        /// 验证用户基本信息
        /// </summary>
        private void ValidateUserInfo()
        {
            UsersEntityEx userModel = base.GetUserModel();

            //为了防止用户更新资料后，Session没有更新
            userModel = new UsersBLL().GetModel(userModel.UserId);

            if (string.IsNullOrEmpty(userModel.TrueName) || string.IsNullOrEmpty(userModel.IdentityCard) || string.IsNullOrEmpty(userModel.Mobile) || string.IsNullOrEmpty(userModel.Gender) || string.IsNullOrEmpty(userModel.Nation) || userModel.Birthday == null || string.IsNullOrEmpty(userModel.Province) || string.IsNullOrEmpty(userModel.City))
            {
                this.artDialog("提示", "您的基本用户资料不完整，请完善后再试！", "DetailInfo.aspx?userId=" + userModel.UserId);
                return;
            }
        }

        /// <summary>
        /// 验证用户学校信息
        /// </summary>
        private void ValidateUserSchool()
        {
            UsersEntityEx userModel = base.GetUserModel();

            //为了防止用户更新资料后，Session没有更新
            userModel = new UsersBLL().GetModel(userModel.UserId);


            UserSchoolEntityEx userSchoolModel = new UserSchoolBLL().GetModel(userModel.UserId);

            if (userSchoolModel == null)
            {
                this.artDialog("提示", "您还没有填写学校信息，请完善后再试！", "DetailInfo.aspx");
                return;
            }

            if (userSchoolModel.SchoolId == 0 || string.IsNullOrEmpty(userSchoolModel.SchoolAddress) || userSchoolModel.YearOfAdmission == 0 || userSchoolModel.SchoolSystem == 0 || string.IsNullOrEmpty(userSchoolModel.Major) || string.IsNullOrEmpty(userSchoolModel.Class)
            || string.IsNullOrEmpty(userSchoolModel.Dormitory))
            {
                this.artDialog("提示", "您学校信息不完整，请完善后再试！", "DetailInfo.aspx");
                return;
            }
        }

        /// <summary>
        /// 验证与用户相关的联系人
        /// </summary>
        private void ValidateUserRelationship()
        {

            UsersEntityEx userModel = base.GetUserModel();

            //为了防止用户更新资料后，Session没有更新
            userModel = new UsersBLL().GetModel(userModel.UserId);

            List<UserRelationshipEntityEx> list = new UserRelationshipBLL().GetList(string.Format(" UserId =  {0} ", userModel.UserId));

            if (list == null)
            {
                this.artDialog("提示", "您还没有填写紧急联系人信息，请完善后再试！", "DetailInfo.aspx");
                return;
            }


            //关系类型 0=直系亲属，1=其他亲属，2=同班同学，3=同寝同学，4=朋友1，5=朋友2，6=学生证，7=学信网认证，8=银行卡流水，
            //9=支付宝流水，10=手机通话记录，11=家长身份证，12=室友身份证，13=户口簿，14=驾驶证，15=在校获奖证明

            UserRelationshipEntityEx urType_1 = list.Where(s => s.Type == 0) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_2 = list.Where(s => s.Type == 1) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_3 = list.Where(s => s.Type == 2) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_4 = list.Where(s => s.Type == 3) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_5 = list.Where(s => s.Type == 4) as UserRelationshipEntityEx;

            if (urType_1 == null || urType_3 == null || urType_4 == null || urType_5 == null)
            {
                this.artDialog("提示", "您的紧急联系人信息还不完整，请完善后再试！", "DetailInfo.aspx");
                return;
            }
        }

        private void ValidateOtherCert()
        {
            UsersEntityEx userModel = base.GetUserModel();

            //为了防止用户更新资料后，Session没有更新
            userModel = new UsersBLL().GetModel(userModel.UserId);

            List<UserRelationshipEntityEx> list = new UserRelationshipBLL().GetList(string.Format(" Where UserId =  {0} ", userModel.UserId));

            if (list == null)
            {
                this.artDialog("提示", "您还没有填写紧急联系人信息，请完善后再试！", "DetailInfo.aspx");
                return;
            }

            UserRelationshipEntityEx urType_6 = list.Where(s => s.Type == 5) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_7 = list.Where(s => s.Type == 6) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_8 = list.Where(s => s.Type == 7) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_9 = list.Where(s => s.Type == 8) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_10 = list.Where(s => s.Type == 9) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_11 = list.Where(s => s.Type == 10) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_12 = list.Where(s => s.Type == 11) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_13 = list.Where(s => s.Type == 12) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_14 = list.Where(s => s.Type == 13) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_15 = list.Where(s => s.Type == 14) as UserRelationshipEntityEx;
            UserRelationshipEntityEx urType_16 = list.Where(s => s.Type == 15) as UserRelationshipEntityEx;


            if (urType_6 == null)
            {
                this.artDialog("提示", "您还没有上传学生证截图，请上传后再试", "DetailInfo.aspx");
                return;
            }

            //用于验证用户上传资料数
            int validateCount = 0;

            if (urType_6 != null) { validateCount += 1; }
            if (urType_7 != null) { validateCount += 1; }
            if (urType_8 != null) { validateCount += 1; }
            if (urType_9 != null) { validateCount += 1; }
            if (urType_10 != null) { validateCount += 1; }
            if (urType_11 != null) { validateCount += 1; }
            if (urType_12 != null) { validateCount += 1; }
            if (urType_13 != null) { validateCount += 1; }
            if (urType_14 != null) { validateCount += 1; }
            if (urType_15 != null) { validateCount += 1; }
            if (urType_16 != null) { validateCount += 1; }

            if (validateCount < 7)
            {
                this.artDialog("提示", "您的资料还有些不完整，请上传后再试", "DetailInfo.aspx");
                return;
            }
        }


    }
}