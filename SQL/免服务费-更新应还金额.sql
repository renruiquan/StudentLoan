

SELECT * from  sl_user_loan where userID in (
SELECT userid from sl_users where TrueName in (
'钱河明'
)
)
and Status=1




DECLARE @day int;
set @day = 14;
UPDATE sl_user_loan SET ShouldRepayMoney = ShouldRepayMoney-LoanMoney*AnnualFee/30*@day where LoanId in (


SELECT LoanId from  sl_user_loan where userID in (
SELECT userid from sl_users where TrueName in (
'钱河明'


)
)
and Status=1

)
and Status =1

