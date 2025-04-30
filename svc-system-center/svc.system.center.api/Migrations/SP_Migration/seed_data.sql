IF NOT EXISTS(SELECT * FROM [dbo].[Users] WITH(NOLOCK) WHERE Email = 'ADMIN@GMAIL.COM')
BEGIN
	INSERT INTO [dbo].[Users]
    (
         [Id]
        ,[Name]
        ,[MobileNo]
        ,[Surname]
        ,[Username]
        ,[Password]
        ,[Email]
        ,[IsDeleted]
        ,[CreateDate]
    )
    VALUES
    (
         NEWID()
        ,'Admin'
        ,'1234567890'
        ,'admin'
        ,'admin@gmail.com'
        ,'y15eyYXIehOQbh1eLbJvPQ=='
        ,'admin@gmail.com'
        ,0
        ,getdate()
    )
END