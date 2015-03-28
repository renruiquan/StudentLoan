SELECT  b.TrueName AS '����' ,
        b.Mobile AS '�ֻ���' ,
        a.CurrentAmortization AS '��ǰ����' ,
        a.Interest '�����' ,
        a.RepaymentMoney AS '����Ӧ������' ,
		c.LoanMoney AS '����',
        a.RepaymentTime AS '�˵�����' ,
        CASE a.Status
          WHEN 0 THEN 'δ����'
        END AS '״̬' ,
        DATEDIFF(DAY, RepaymentTime, GETDATE()) AS '��������'
FROM    dbo.sl_user_repayment a ,
        sl_users b,
		sl_user_loan c
WHERE   a.Status = 0
        AND DATEDIFF(DAY, RepaymentTime, GETDATE()) > 5
        AND a.UserId = b.UserId
		AND a.LoanId = c.LoanId
		AND c.Status=1


