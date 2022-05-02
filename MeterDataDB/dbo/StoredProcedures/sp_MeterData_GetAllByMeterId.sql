CREATE PROCEDURE [dbo].[sp_MeterData_GetAllByMeterId]
	@MeterId nvarchar(50)
AS
begin
	select *
	from dbo.[MeterData]
	where MeterId = @MeterId;
end
