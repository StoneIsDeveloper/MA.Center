create proc dbo.InsertLogProcess
   @WorkLogId  bigint ,
   @ProcessTypeId nvarchar(max),
   @ProcessTypeName nvarchar(250),
   @StageId int,
   @StatusId int,
   @UserName nvarchar(250)
   AS
  Begin
    
     INSERT INTO dbo.WorkLogProcess
           ( WorkLogId
		  ,ProcessTypeId
		  ,ProcessTypeName
		  ,StageId
		  ,StatusId
		  ,InsertDate
		  ,UserName
		  )
     VALUES
          ( @WorkLogId
		   ,@ProcessTypeId
		   ,@ProcessTypeName
		   ,@StageId
		   ,@StatusId
           ,GETDATE()
           ,@UserName )
  END
