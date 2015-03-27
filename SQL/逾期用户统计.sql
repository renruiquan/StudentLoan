SELECT  b.TrueName AS '姓名' ,
        b.Mobile AS '手机号' ,
        a.CurrentAmortization AS '当前期数' ,
        a.Interest '服务费' ,
        a.RepaymentMoney AS '本期应还本金' ,
		c.LoanMoney AS '本金',
        a.RepaymentTime AS '账单日期' ,
        CASE a.Status
          WHEN 0 THEN '未还款'
        END AS '状态' ,
        DATEDIFF(DAY, RepaymentTime, GETDATE()) AS '逾期天数'
FROM    dbo.sl_user_repayment a ,
        sl_users b,
		sl_user_loan c
WHERE   a.Status = 0
        AND DATEDIFF(DAY, RepaymentTime, GETDATE()) > 5
        AND a.UserId = b.UserId
		AND a.LoanId = c.LoanId
		AND c.Status=1


