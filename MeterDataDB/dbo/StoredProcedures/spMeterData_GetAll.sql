CREATE PROCEDURE [dbo].[spMeterData_GetAll]

AS
begin
	select *
	from dbo.[MeterData];
end
