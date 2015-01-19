DECLARE @Interest int
set @Interest = 144




UPDATE sl_user_repayment SET Interest = @Interest where  LoanId in (	

SELECT LoanId from sl_user_repayment where loanid  in (
SELECT LoanId from sl_user_loan where UserId in 
(
SELECT UserId from sl_users where TrueName in (
'Ç®ºÓÃ÷'
)
AND sl_user_loan.status = 1)) and CurrentAmortization =1


) and CurrentAmortization =1