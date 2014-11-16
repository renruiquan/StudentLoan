using StudentLoan.BLL;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.BindData();
            }
        }

        protected void BindData()
        {
            UsersEntityEx userModel = new UsersBLL().GetModel(base.GetUserModel().UserId);

            this.lblPoint.Text = userModel.Point.ToString();

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

            var result = new UserRepaymentBLL().GetListByPage(string.Format(" a.UserId={0}", base.GetUserModel().UserId), "RepaymentTime Desc", 1, 1).FirstOrDefault();

            if (result != null)
            {
                this.lblRepaymentTime.Text = result.RepaymentTime.ToString("yyyy-MM-dd");
                this.lblRepaymentMoney.Text = (result.RepaymentMoney + result.Interest).ToString();
                this.lblAmortization.Text = string.Format("{0}/{1}", result.AlreadyAmortization, result.TotalAmortization);
            }

            this.objRepeater.DataSource = new UserLoanBLL().GetLoanAnnouncement();
            this.objRepeater.DataBind();
        }
    }
}