create proc dbo.InsertLog
   @TypeID INT ,
   @Description nvarchar(max),
   @UserName nvarchar(250)
   AS
  Begin
    
     INSERT INTO [dbo].[WorkLog]
           ( [TypeID]
           ,[InsertDate]
           ,[Description]
           ,[UserName])
     VALUES
           (
           @TypeID
           , GETDATE()
           , @Description
           ,@UserName )
  END
