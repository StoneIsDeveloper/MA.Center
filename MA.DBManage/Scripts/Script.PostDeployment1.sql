/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
 :r .\Table\dbo.WorkLog.sql
 GO
 :r .\Table\dbo.WorkLogProcess.sql
Go
 :r .\Table\Serilogs.sql
Go

--Create SP
--GO
-- -- :r .\StoreProcedure\InsertLog.proc.sql
-- GO
-- :r .\StoreProcedure\InsertWorkLogProcess.proc.sql
-- GO