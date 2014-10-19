using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentLoan.Model.Base
{
    public class DrawMoneyEntity
    {

        private int _drawId;

        /// <summary>
        /// 提款ID
        /// </summary>
        public int DrawId
        {
            get { return _drawId; }
            set { _drawId = value; }
        }

        private int _userId;

        /// <summary>
        /// 用户Id
        /// </summary>
        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private int _bindBankId;

        /// <summary>
        /// 绑定的提款银行卡ID
        /// </summary>
        public int BindBankId
        {
            get { return _bindBankId; }
            set { _bindBankId = value; }
        }

        private decimal _drawMoney;

        /// <summary>
        /// 提款金额
        /// </summary>
        public decimal DrawMoney
        {
            get { return _drawMoney; }
            set { _drawMoney = value; }
        }

        private decimal _fee;

        /// <summary>
        /// 手续费
        /// </summary>
        public decimal Fee
        {
            get { return _fee; }
            set { _fee = value; }
        }

        private decimal _lockMoney;

        /// <summary>
        /// 提款锁定金额
        /// </summary>
        public decimal LockMoney
        {
            get { return _lockMoney; }
            set { _lockMoney = value; }
        }

        private decimal _confirmMoney;

        /// <summary>
        /// 到账金额（确认金额）
        /// </summary>
        public decimal ConfirmMoney
        {
            get { return _confirmMoney; }
            set { _confirmMoney = value; }
        }

        private System.DateTime _applyTime;

        /// <summary>
        /// 申请提款日期
        /// </summary>
        public System.DateTime ApplyTime
        {
            get { return _applyTime; }
            set { _applyTime = value; }
        }

        private System.DateTime _passTime;

        /// <summary>
        /// 审核通过时间
        /// </summary>
        public System.DateTime PassTime
        {
            get { return _passTime; }
            set { _passTime = value; }
        }

        private int _adminId;

        /// <summary>
        /// 审核管理员ID
        /// </summary>
        public int AdminId
        {
            get { return _adminId; }
            set { _adminId = value; }
        }

        private byte _status;

        /// <summary>
        /// 状态 0=审核中，1=提款失败，2=提款成功 
        /// </summary>
        public byte Status
        {
            get { return _status; }
            set { _status = value; }
        }

    }
}
