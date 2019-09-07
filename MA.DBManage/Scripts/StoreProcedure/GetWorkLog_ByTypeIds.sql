-- =============================================
-- Author:		<stone,li>
-- Create date: <2019/9/7>
-- Description:	<add cutom type for array int>
-- =============================================
create procedure dbo.GetWorkLog_ByTypeIds
     @TypeIds as dbo.IDList READONLY
as
begin
    SELECT *
     FROM [macenterdev].[dbo].[WorkLog] 
	 where TypeID in ( select ID from @TypeIds )
end


 -- Exec sp_droptype 'IdList'