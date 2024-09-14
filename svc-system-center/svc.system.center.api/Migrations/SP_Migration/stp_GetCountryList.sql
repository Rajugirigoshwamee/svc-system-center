SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		RAJUGIRI
-- Create date: 
-- Description:	
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[stp_GetCountryList]
(
	@PageSize		INT = 10,
	@PageNo			INT=0
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT 
		* 
	FROM [dbo].[Countries] WITH(NOLOCK)

END
