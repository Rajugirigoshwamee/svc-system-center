CREATE OR ALTER PROCEDURE [dbo].[stp_GetStateList]
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

	IF(@PageSize IS NULL)
	BEGIN 
		SELECT @PageSize=COUNT(C.Id) FROM [dbo].[States] C WITH(NOLOCK);
	END

	IF(@PageSize IS NULL)
	BEGIN 
		SET @PageNo=0;
	END
	 
	DECLARE @Offset INT = (@PageNo * @PageSize);

    SELECT 
		S.Id as id,
		S.Name AS name,
		C.Name AS countryName,
		C.Id AS countryId,
		S.Code AS code,
		COUNT(C.Id) OVER() AS Total
	FROM [dbo].[States] S WITH(NOLOCK)
	INNER JOIN [dbo].[Countries] C WITH(NOLOCK) ON S.CountryId = C.Id
	WHERE 
		S.IsDeleted=0
		AND (@Id IS NULL OR S.Id = @Id)
	ORDER BY 
		C.Name
	OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY

END
