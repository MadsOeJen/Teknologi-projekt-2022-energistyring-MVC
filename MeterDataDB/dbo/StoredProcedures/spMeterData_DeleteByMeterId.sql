CREATE PROCEDURE [dbo].[spMeterData_DeleteByMeterId]
	@MeterId nvarchar(50)
AS
begin
	delete
	from dbo.[MeterData]
	where MeterId = @MeterId;
end
