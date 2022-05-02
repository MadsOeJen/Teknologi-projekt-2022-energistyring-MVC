CREATE PROCEDURE [dbo].[spMeterData_Delete]
	@Id int
AS
begin
	delete
	from dbo.[MeterData]
	where Id = @Id;
end
