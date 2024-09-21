CREATE OR ALTER PROCEDURE [dbo].[stp_GetCountryList]
(
	@Id				UNIQUEIDENTIFIER = NULL,
	@Search			NVARCHAR = NULL,
	@SortBy			NVARCHAR = NULL,
	@PageSize		INT = 10,
	@PageNo			INT = 0
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
		C.Name AS name,
		C.Code AS code,
		C.MobileCode AS MobileCode,
		C.FlagUrl AS FlagUrl
	FROM [dbo].[Countries] C WITH(NOLOCK)
	WHERE 
		C.IsDeleted=0
		AND (@Id IS NULL OR C.Id = @Id)
	ORDER BY 
		C.Name
	OFFSET @PageNo*@PageSize ROWS FETCH NEXT @PageSize ROWS ONLY

END
