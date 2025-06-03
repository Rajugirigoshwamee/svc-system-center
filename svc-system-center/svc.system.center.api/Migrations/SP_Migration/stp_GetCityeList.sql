CREATE OR ALTER PROCEDURE [dbo].[stp_GetCityeList]
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
		SELECT @PageSize=COUNT(C.Id) FROM [dbo].[Cities] C WITH(NOLOCK);
	END

	IF(@PageSize IS NULL)
	BEGIN 
		SET @PageNo=0;
	END
	 
	DECLARE @Offset INT = (@PageNo * @PageSize);

    SELECT 
		CI.Id as id,
		CI.Name as name,
		S.Id as stateId,
		S.Name AS stateName,
		C.Name AS countryName,
		C.Id AS countryId,
		S.Code AS code,
		COUNT(C.Id) OVER() AS Total
	FROM [dbo].[Cities] CI WITH(NOLOCK)
	INNER JOIN [dbo].[States] S WITH(NOLOCK) ON S.Id = CI.StateId
	INNER JOIN [dbo].[Countries] C WITH(NOLOCK) ON S.CountryId = CI.CountryId
	WHERE 
		CI.IsDeleted=0
		AND (@Id IS NULL OR S.Id = @Id)
	ORDER BY 
		CI.Name
	OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY

END
