CREATE PROCEDURE [dbo].[spMeterData_Insert]
	@TimeStart datetime,
	@TimeEnd datetime,
	@Unit nvarchar(50),
	@Measurement float,
	@EnergyType nvarchar(50),
	@MeterId nvarchar(50)
AS
begin
	insert into dbo.[MeterData] (TimeStart, TimeEnd, Unit, Measurement, EnergyType, MeterId)
	values (@TimeStart, @TimeEnd, @Unit, @Measurement, @EnergyType, @MeterId)
end
