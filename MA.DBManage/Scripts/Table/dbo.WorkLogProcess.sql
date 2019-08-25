GO

/****** Object:  Table [dbo].[WorkLogProcess]    Script Date: 2019/8/25 11:07:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkLogProcess](
	[WorkLogProcessId] [bigint] IDENTITY(1,1) NOT NULL,
	[WorkLogId] [bigint] NOT NULL,
	[ProcessTypeId] [int] NOT NULL,
	[ProcessTypeName] [nvarchar](500) NULL,
	[StageId] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[UserName] [nvarchar](250) NULL
) ON [PRIMARY]

GO


