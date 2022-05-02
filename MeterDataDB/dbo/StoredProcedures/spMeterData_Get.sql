CREATE PROCEDURE [dbo].[spMeterData_Get]
	@Id int
AS
begin
	select *
	from dbo.[MeterData]
	where Id = @Id;
end
