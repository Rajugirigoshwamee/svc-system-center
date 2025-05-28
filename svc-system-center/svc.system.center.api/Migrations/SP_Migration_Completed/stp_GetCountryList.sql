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

	IF(@PageSize IS NULL)
	BEGIN 
		SELECT @PageSize=COUNT(C.Id) FROM [dbo].[Countries] C WITH(NOLOCK);
	END

	IF(@PageSize IS NULL)
	BEGIN 
		SET @PageNo=0;
	END
	 
	DECLARE @Offset INT = (@PageNo * @PageSize);

    SELECT 
		C.Id as id,
		C.Name AS name,
		C.Code AS code,
		C.MobileCode AS mobileCode,
		C.FlagUrl AS flagUrl,
		COUNT(C.Id) OVER() AS Total
	FROM [dbo].[Countries] C WITH(NOLOCK)
	WHERE 
		C.IsDeleted=0
		AND (@Id IS NULL OR C.Id = @Id)
	ORDER BY 
		C.Name
	OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY

END
