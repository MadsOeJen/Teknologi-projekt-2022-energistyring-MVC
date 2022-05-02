CREATE PROCEDURE [dbo].[spMeterData_GetAllMeters]

AS
begin
	select distinct MeterId
	from dbo.[MeterData];
end
