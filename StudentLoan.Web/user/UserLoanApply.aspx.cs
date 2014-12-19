using StudentLoan.BLL;
using StudentLoan.Model;
using StudentLoan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web.user
{
    public partial class UserLoanApply : BasePage
    {

        private int ProductId { get { return this.Request<int>("productId", 1); } }

        private ProductEntityEx ProductModel { get { return new ProductBLL().GetModel(this.ProductId); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UsersEntityEx userModel = base.GetUserModel();

                bool isExist = new UserLoanBLL().Exists(userModel.UserId);

                if (isExist)
                {
                    this.artDialog("提示", "对不起，您还有借款未通过审核，暂时无法再次申请借款！", "/user/UserLoanList.aspx");
                    Response.Redirect("/user/UserLoanList.aspx");
                    return;
                }

                this.BindDropDownList();
            }
        }

        /// <summary>
        /// 绑定借款金额
        /// </summary>
        private void BindDropDownList()
        {
            if (this.ProductId == 0)
            {
                this.artDialog("提示", "参数不正确", "/LoanList.aspx");
                return;
            }

            ProductEntityEx productModel = new ProductBLL().GetModel(this.ProductId);

            this.ddlLoanMoney.Items.Clear();
            this.ddlTotalAmortization.Items.Clear();

            if (this.ProductId == 1)
            {
                //一般贷款

                this.ValidateBaseCert();
                this.ValidateIdentityCardCert();
                this.ValidateStudentIdCert();
                this.ValidateMobileCallLog();

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
                bool EnabledGED = ConfigHelper.AppSettings<bool>("EnabledGED", false);

                if (!EnabledGED)
                {
                    this.artDialog("提示", "对不起，高额贷正在开发，暂时无法申请，你可以先申请一般贷！", "/LoanList.aspx");
                    return;
                }

                //高额贷款
                this.ValiUserPoint();
                this.ValidateBaseCert();
                this.ValidateIdentityCardCert();
                this.ValidateStudentIdCert();
                this.ValidateOptionalCert();
                this.ValidateAliPayAndBankCert();
                this.ValidateMobileCallLog();

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
                this.ddlTotalAmortization.Items.Add(new ListItem("6个月", "6"));
            }
            else if (this.ProductId == 3)
            {
                bool EnabledSSD = ConfigHelper.AppSettings<bool>("EnabledSSD", false);

                if (!EnabledSSD)
                {
                    this.artDialog("提示", "对不起，随时贷正在开发，暂时无法申请，你可以先申请一般贷！", "/LoanList.aspx");
                    return;
                }

                //随时贷款
                this.ValidateBaseCert();
                this.ValidateIdentityCardCert();
                this.ValidateStudentIdCert();
                this.ValidateMobileCallLog();

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

                this.lblAmortizationMsg.Text = "不得多于90天";
                this.ddlTotalAmortization.Visible = false;
                this.txtTotalAmortization.Visible = true;
                this.divRepayMoney.Visible = false;
            }
        }

        protected void btnApply_ServerClick(object sender, EventArgs e)
        {
            UsersEntityEx userModel = userModel = base.GetUserModel();

            if (userModel == null)
            {
                this.artDialog("提示", "登录超时，请重新登录", "/login.aspx");
                return;
            }

            decimal shouldRepayMoney = 0;
            int loanTypeId = 0; //没有用到此字段
            decimal loanMoney = Math.Abs(this.ddlLoanMoney.SelectedValue.Convert<decimal>(0));
            int loanCategory = this.ddlLoanCategory.SelectedValue.Convert<int>(1);
            string loanDescription = this.txtLoanDescription.Text.Trim().HtmlEncode();
            int totalAmortization = 0;

            if (this.ProductId == 3)
            {
                totalAmortization = this.txtTotalAmortization.Text.Trim().Convert<int>(1);

                if (loanMoney >= 6000)
                {
                    this.ValiUserPoint();
                    this.ValidateBaseCert();
                    this.ValidateIdentityCardCert();
                    this.ValidateStudentIdCert();
                    this.ValidateOptionalCert();
                    this.ValidateAliPayAndBankCert();
                }

            }
            else
            {
                totalAmortization = this.ddlTotalAmortization.SelectedValue.Convert<int>(1);
            }

            if (loanMoney < ProductModel.ProductMinMoney || loanMoney > ProductModel.ProductMaxMoney)
            {
                this.artDialog("贷款金额不正确");
                return;
            }

            if (txtTotalAmortization.Text.Trim().Convert<int>() > 90)
            {
                this.artDialog("还款期限不得多于90天");
                return;
            }

            //计算应用金额
            shouldRepayMoney = loanMoney * ProductModel.BaseAnnualFee * totalAmortization + loanMoney;


            UserLoanEntityEx userLoanModel = new UserLoanEntityEx();

            userLoanModel.LoanNo = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            userLoanModel.UserId = userModel.UserId;
            userLoanModel.ProductId = ProductModel.ProductId;
            userLoanModel.LoanTitle = string.Empty;
            userLoanModel.LoanMoney = loanMoney;
            userLoanModel.LoanTypeId = loanTypeId;
            userLoanModel.LoanCategory = loanCategory;
            userLoanModel.ShouldRepayMoney = shouldRepayMoney;
            userLoanModel.TotalAmortization = totalAmortization;
            userLoanModel.LoanDescription = loanDescription;
            userLoanModel.AnnualFee = ProductModel.BaseAnnualFee;
            UserLoanBLL bll = new UserLoanBLL();

            bool result = bll.Insert(userLoanModel);


            this.artDialog("提示", string.Format("提交申请{0}", result == true ? "成功，请等待管理员审核！" : "失败"), "UserLoanList.aspx");
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        private UsersEntityEx GetUserInfo()
        {
            UsersEntityEx model = base.GetUserModel();

            if (model == null)
            {
                this.artDialog("提示", "用户不存在，无法完成校验,请重新登录后重试！", "/login.aspx");

                Session[StudentLoanKeys.SESSION_USER_INFO] = null;
                this.WriteCookie("UserName", "StudentLoan", -14400);
                this.WriteCookie("UserPwd", "StudentLoan", -14400);
                Response.Redirect("/login.aspx");
                return null;
            }
            else
            {
                return model;
            }
        }

        /// <summary>
        /// 校验基本认证信息
        /// </summary>
        protected void ValidateBaseCert()
        {
            UsersEntityEx model = this.GetUserInfo();

            #region 校验用户学校信息

            UserSchoolEntityEx schoolModel = new UserSchoolBLL().GetModel(model.UserId);

            if (schoolModel == null)
            {
                this.artDialog("提示", "对不起，你还没有填写学校信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                return;
            }

            if ((DateTime.Now - schoolModel.YearOfAdmission).Days > 365 * schoolModel.SchoolSystem)
            {
                this.artDialog("提示", "对不起，您不是在校学生，无法申请借款，如果您继续进修，请先更新学制以及学历等相关信息！", "/user/UserAccountCert_2.aspx");
                return;
            }


            if (string.IsNullOrEmpty(schoolModel.SchoolName))
            {
                this.artDialog("提示", "对不起，您还没有填写就读学校，请完善后重试！", "/user/UserAccountCert_2.aspx");
                return;
            }
            if (string.IsNullOrEmpty(schoolModel.SchoolName))
            {
                this.artDialog("提示", "对不起，您还没有填写就读学校地址，请完善后重试！", "/user/UserAccountCert_2.aspx");
                return;
            }
            if (string.IsNullOrEmpty(schoolModel.YearOfAdmission.ToString()) || schoolModel.YearOfAdmission == default(DateTime))
            {
                this.artDialog("提示", "对不起，您还没有填写入学日期，请完善后重试！", "/user/UserAccountCert_2.aspx");
                return;
            }
            if (schoolModel.SchoolSystem == 0)
            {
                this.artDialog("提示", "对不起，您还没有填写学制，请完善后重试！", "/user/UserAccountCert_2.aspx");
                return;
            }
            if (schoolModel.Education == 0)
            {
                this.artDialog("提示", "对不起，您还没有填写学历，请完善后重试！", "/user/UserAccountCert_2.aspx");
                return;
            } if (string.IsNullOrEmpty(schoolModel.Major))
            {
                this.artDialog("提示", "对不起，您还没有填写专业信息，请完善后重试！", "/user/UserAccountCert_2.aspx");
                return;
            }

            #endregion

            #region 校验用户基本信息

            if (model != null)
            {
                if (string.IsNullOrEmpty(model.TrueName))
                {
                    this.artDialog("提示", "对不起，您还没有填写真实姓名，请完善后重试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(model.IdentityCard))
                {
                    this.artDialog("提示", "对不起，您还没有填写身份证号码，请完善后重试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(model.Mobile))
                {
                    this.artDialog("提示", "对不起，您还没有绑定手机号码，请完善后重试！", "/user/BindMobile.aspx");
                    return;
                }
                if (string.IsNullOrEmpty(model.Birthday.ToString()) || model.Birthday == default(DateTime))
                {
                    this.artDialog("提示", "对不起，您还没有填写出生日期，请完善后重试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                if ((DateTime.Now - model.Birthday).Days < 365 * 18)
                {
                    this.artDialog("提示", "对不起，您还没满18周岁，无法申请借款！", "/user/UserAccount.aspx");
                    return;
                }
            }
            else
            {
                this.artDialog("提示", "用户不存在，无法完成校验,请重新登录后重试！", "/login.aspx");
                Session[StudentLoanKeys.SESSION_USER_INFO] = null;
                this.WriteCookie("UserName", "StudentLoan", -14400);
                this.WriteCookie("UserPwd", "StudentLoan", -14400);
                Response.Redirect("/login.aspx");
                return;
            }

            #endregion

            #region 校验用户联系人信息

            List<UserRelationshipEntityEx> list = new UserRelationshipBLL().GetList(string.Format(" 1=1 and UserId = {0}", model.UserId));

            if (list == null || list.Count == 0)
            {
                this.artDialog("提示", "对不起，你还没有填写联系人信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                return;
            }

            if (list != null && list.Count > 0)
            {
                var FamilyModel = list.FirstOrDefault(s => s.Type == 1);
                var StudentModel = list.FirstOrDefault(s => s.Type == 2);
                var FriendModel = list.FirstOrDefault(s => s.Type == 3);

                if (FamilyModel == null)
                {
                    this.artDialog("提示", "对不起，你还没有填写直接亲属联系人信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(FamilyModel.Name))
                    {
                        this.artDialog("提示", "对不起，你还没有填写直接亲属联系人的姓名信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                        return;
                    }
                    if (string.IsNullOrEmpty(FamilyModel.Relationship))
                    {
                        this.artDialog("提示", "对不起，你还没有填写直接亲属联系人的关系信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                        return;
                    }
                    if (string.IsNullOrEmpty(FamilyModel.Mobile))
                    {
                        this.artDialog("提示", "对不起，你还没有填写直接亲属联系人的手机号码信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                        return;
                    }
                }

                if (StudentModel == null)
                {
                    this.artDialog("提示", "对不起，你还没有填写同学（同室）信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(StudentModel.Name))
                    {
                        this.artDialog("提示", "对不起，你还没有填写直同学（同室）的姓名信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                        return;
                    }
                    if (string.IsNullOrEmpty(StudentModel.Mobile))
                    {
                        this.artDialog("提示", "对不起，你还没有填写直同学（同室）的手机号码信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                        return;
                    }
                }

                if (FriendModel == null)
                {
                    this.artDialog("提示", "对不起，你还没有填写朋友信息（必须不是同学），无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                    return;
                }
                else
                {
                    if (string.IsNullOrEmpty(FriendModel.Name))
                    {
                        this.artDialog("提示", "对不起，你还没有填写朋友的姓名信息（必须不是同学），无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                        return;
                    }
                    if (string.IsNullOrEmpty(FriendModel.Mobile))
                    {
                        this.artDialog("提示", "对不起，你还没有填写朋友的手机号码信息（必须不是同学），无法申请借款，请完善资料后再试！", "/user/UserAccountCert_2.aspx");
                        return;
                    }
                }
            }

            #endregion

        }

        /// <summary>
        /// 校验学生证信息
        /// </summary>
        protected void ValidateStudentIdCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0} and Type in (2,3,18)", base.GetUserModel().UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                var StudentId1 = sourceList.FirstOrDefault(s => s.Type == 2);
                var StudentId2 = sourceList.FirstOrDefault(s => s.Type == 3);
                var StudentId3 = sourceList.FirstOrDefault(s => s.Type == 18);

                if (StudentId1 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传学生证正面截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }
                if (StudentId2 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传学生证内容页1截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }
                if (StudentId3 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传学生证内容页2截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }

            }
            else
            {
                this.artDialog("提示", "对不起，你还没有上传学生证截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                return;
            }
        }

        /// <summary>
        /// 校验用户身份证信息
        /// </summary>
        protected void ValidateIdentityCardCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0} and Type <=1", base.GetUserModel().UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                var IdentityCard1 = sourceList.FirstOrDefault(s => s.Type == 0);
                var IdentityCard2 = sourceList.FirstOrDefault(s => s.Type == 1);

                if (IdentityCard1 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传手持身份证照片信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }
                if (IdentityCard2 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传身份证正面截图信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }

            }
            else
            {
                this.artDialog("提示", "对不起，你还没有上传身份证截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                return;
            }
        }

        /// <summary>
        /// 校验用户可选认证信息
        /// </summary>
        protected void ValidateOptionalCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0} and Type> = 4", base.GetUserModel().UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                var XueXin = sourceList.FirstOrDefault(s => s.Type == 4);
                //var Bank = sourceList.FirstOrDefault(s => s.Type == 5);
                //var Alipay = sourceList.FirstOrDefault(s => s.Type == 6);
                var Parents1 = sourceList.FirstOrDefault(s => s.Type == 8);
                var Parents2 = sourceList.FirstOrDefault(s => s.Type == 9);
                var RoommateIdentityCard1 = sourceList.FirstOrDefault(s => s.Type == 10);
                var RoommateIdentityCard2 = sourceList.FirstOrDefault(s => s.Type == 11);
                var RoommateStudentId1 = sourceList.FirstOrDefault(s => s.Type == 12);
                var RoommateStudentId2 = sourceList.FirstOrDefault(s => s.Type == 13);
                var Residencebooklet = sourceList.FirstOrDefault(s => s.Type == 14);
                var DriversLicense = sourceList.FirstOrDefault(s => s.Type == 15);
                var Awards = sourceList.FirstOrDefault(s => s.Type == 16);

                if (XueXin == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传学信网截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
                //if (Bank == null)
                //{
                //    this.artDialog("提示", "对不起，你还没有上传近期银行卡流水截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                //    return;
                //}
                //考虑到部分用户没使用过支付宝，暂不验证
                //if (Alipay == null)
                //{
                //    this.artDialog("提示", "对不起，你还没有上传支付宝近期流水截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                //    return;
                //}

                if (Parents1 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传家长身份证正面截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
                if (Parents2 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传家长身份证背面截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
                if (RoommateIdentityCard1 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传室友手持身份证截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
                if (RoommateIdentityCard2 == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传室友身份证正面截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
                if (DriversLicense == null)
                {
                    this.artDialog("提示", "对不起，你还没有上传驾驶证截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
                if (Residencebooklet == null)
                {
                    this.artDialog("提示", "对不起，你还没有上户口内容页截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
            }
            else
            {
                this.artDialog("提示", "对不起，你还没有上传学银行流水截图，手机通讯详单等信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                return;
            }
        }

        protected void ValidateAliPayAndBankCert()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0} and Type> = 4", base.GetUserModel().UserId));

            if (sourceList != null && sourceList.Count > 0)
            {

                var Bank = sourceList.Where(s => s.Type == 5);
                var Alipay = sourceList.Where(s => s.Type == 6);

                if (Bank == null || Bank.Count() == 0)
                {
                    this.artDialog("提示", "对不起，你还没有上传近期银行卡流水截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
                else if (Bank.Count() < 6)
                {
                    this.artDialog("提示", "对不起，最少上传6张近期银行卡流水截图，申请借款失败，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }

                if (Alipay == null || Alipay.Count() == 0)
                {
                    this.artDialog("提示", "对不起，你还没有上传近期支付宝流水截图，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }
                else if (Alipay.Count() < 6)
                {
                    this.artDialog("提示", "对不起，最少上传6张近期支付宝流水截图，申请借款失败，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                    return;
                }
            }
            else
            {
                this.artDialog("提示", "对不起，你还没有上传学银行流水截图，手机通讯详单等信息，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_4.aspx");
                return;
            }
        }

        /// <summary>
        /// 验证手机通话记录
        /// </summary>
        protected void ValidateMobileCallLog()
        {
            List<UserCertificationEntityEx> sourceList = new UserCertificationBLL().GetList(string.Format(" 1=1 and UserId = {0} and Type> = 4", base.GetUserModel().UserId));

            if (sourceList != null && sourceList.Count > 0)
            {
                var Mobile = sourceList.Where(s => s.Type == 7);

                if (Mobile == null || Mobile.Count() == 0)
                {
                    this.artDialog("提示", "对不起，你还没有上传近期通话记录详单，无法申请借款，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }
                else if (Mobile.Count() < 6)
                {
                    this.artDialog("提示", "对不起，最少上传6张近期通话记录详单，申请借款失败，请完善资料后再试！", "/user/UserAccountCert_3.aspx");
                    return;
                }
            }
        }

        /// <summary>
        /// 验证用户积分是否可以高额借款
        /// </summary>
        protected void ValiUserPoint()
        {
            UsersEntityEx userModel = base.GetUserModel();

            userModel = new UsersBLL().GetModel(userModel.UserId);

            if (userModel.Point < 70)
            {
                this.artDialog("提示", "对不起，你当前信用等级无法进行高额贷款，请验证“可选认证资料”完成70信用积分即可申请高额贷款！", "/user/UserAccountCert_4.aspx");
                return;
            }
        }

    }
}