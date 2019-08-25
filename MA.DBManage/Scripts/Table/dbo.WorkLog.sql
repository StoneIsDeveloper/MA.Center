GO

/****** Object:  Table [dbo].[WorkLog]    Script Date: 2019/8/25 11:05:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[WorkLog](
	[LogID] [bigint] IDENTITY(1,1) NOT NULL,
	[TypeID] [int] NOT NULL,
	[InsertDate] [datetime2](7) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[UserName] [nvarchar](250) NULL,
	[StatusId] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


