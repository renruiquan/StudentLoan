using StudentLoan.BLL;
using StudentLoan.Common;
using StudentLoan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentLoan.Web
{
    public partial class IvoryTower : BasePage
    {
        private string _stepBackground;
        /// <summary>
        /// 获取第N步的背景图片
        /// </summary>
        public string StepBackground
        {
            get
            {
                if (string.IsNullOrEmpty(_stepBackground))
                {
                    return "step-one";
                }
                else
                {
                    return _stepBackground;
                }
            }
            set { _stepBackground = value; }
        }


        /// <summary>
        /// 获取总借款人数
        /// </summary>
        public long GetLoanTotalCount { get { return new UserLoanBLL().GetLoanTotalCount(); } }

        /// <summary>
        /// 配置的借款用户人数
        /// </summary>
        public int TotalUserLoan { get { return ConfigHelper.AppSettings<int>("TotalUserLoan", 0); } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();

             //   this.artDialog("放假公告", "为欢度新春佳节，学子易贷平台将于2015年2月15日-2月25日放假，关于2月份申请贷款的用户将于年后审核，特此公告！ ");
            }
        }

        protected void BindData()
        {
            UsersEntityEx userModel = new UsersBLL().GetModel(base.GetUserModel().UserId);



            this.lblTotalLoanUsers.Text = (this.GetLoanTotalCount + this.TotalUserLoan).ToString();

            this.lblPoint.Text = string.Format("{0}分  {1}", userModel.Point, this.GetLevel(userModel.Point));

            if (userModel.Point <= 30)
            {
                this.StepBackground = "step-one";
            }
            if (userModel.Point >= 31 && userModel.Point <= 60)
            {
                this.StepBackground = "step-two";
            } if (userModel.Point >= 61 && userModel.Point <= 70)
            {
                this.StepBackground = "step-three";
            } if (userModel.Point >= 71)
            {
                this.StepBackground = "step-four";
            }

            var result = new UserRepaymentBLL().GetListByPage(string.Format(" a.UserId={0} and T.Status = 0", base.GetUserModel().UserId), "RepaymentTime ", 1, 1).FirstOrDefault();

            if (result != null)
            {
                this.lblRepaymentTime.Text = result.RepaymentTime.ToString("yyyy-MM-dd");
                this.lblRepaymentMoney.Text = (result.RepaymentMoney + result.Interest).ToString();
                this.lblAmortization.Text = string.Format("{0}/{1}", result.AlreadyAmortization, result.TotalAmortization);
            }

            this.objRepeater.DataSource = new UserLoanBLL().GetLoanAnnouncement();
            this.objRepeater.DataBind();
        }

        protected string GetLevel(int point)
        {
            string result = string.Empty;

            if (point > 0 && point <= 30)
            {
                result = "E级";
            }
            if (point > 31 && point <= 60)
            {
                result = "D级";
            }
            if (point > 61 && point <= 70)
            {
                result = "C级";
            }
            if (point > 71 && point <= 80)
            {
                result = "B级";
            }
            if (point > 81)
            {
                result = "A级";
            }

            return result;
        }
    }
}