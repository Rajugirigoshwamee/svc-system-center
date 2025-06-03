CREATE OR ALTER PROCEDURE [dbo].[stp_ValidateLogin]
(
	@UserName			NVARCHAR(MAX) = NULL,
	@Password			NVARCHAR(MAX) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		U.Id as id,
		U.Name AS name,
		U.Email AS email,
		U.Surname AS surname,
		U.MobileNo
	FROM [dbo].[Users] U WITH(NOLOCK)
	WHERE 
		U.IsDeleted=0
		AND U.Email = @UserName                                   
		AND U.[Password]  = @Password

END
