CREATE TABLE [dbo].[Serilogs](
    [Id] [int] IDENTITY(1,1) NOT NULL Primary Key,
    [Message] [nvarchar](max) NULL,
    [MessageTemplate] [nvarchar](max) NULL,
    [Level] [nvarchar](128) NULL,
    [TimeStamp] [datetime] NULL,
    [Exception] [nvarchar](max) NULL,
    [Properties] [xml] NULL)