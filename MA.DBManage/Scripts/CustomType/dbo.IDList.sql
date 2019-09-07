CREATE TYPE dbo.IDList
AS TABLE
(
  ID INT
);
GO

 --Exec sp_addtype IDList, int, 'Not Null'

 -- Exec sp_droptype 'IDList'