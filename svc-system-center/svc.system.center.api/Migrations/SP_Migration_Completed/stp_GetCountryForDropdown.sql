CREATE OR ALTER PROCEDURE [dbo].[stp_GetCountryForDropdown]
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
		C.Id as id,
		C.Name AS name,
		C.Code AS code
	FROM [dbo].[Countries] C WITH(NOLOCK)
	WHERE 
		C.IsDeleted=0
	ORDER BY 
		C.Name
END
