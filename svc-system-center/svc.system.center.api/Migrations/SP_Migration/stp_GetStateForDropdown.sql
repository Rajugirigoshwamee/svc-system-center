CREATE OR ALTER PROCEDURE [dbo].[stp_GetStateForDropdown]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
		S.Id as id,
		S.Name AS name,
		S.Code AS code
	FROM [dbo].[States] S WITH(NOLOCK)
	WHERE 
		S.IsDeleted=0
	ORDER BY 
		S.Name
END
