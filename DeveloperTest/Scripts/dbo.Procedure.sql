CREATE PROCEDURE [dbo].[AddUserData]
	@Email varchar(50),
	@Password varchar(50)
AS
begin
	Insert into UserData values(@Email,@Password)
end
RETURN 0
