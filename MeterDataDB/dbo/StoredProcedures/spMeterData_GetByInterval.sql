CREATE PROCEDURE [dbo].[spMeterData_GetByInterval]
	@TimeStart DateTime,
	@TimeEnd DateTime
AS
begin
	select *
	from dbo.[MeterData]
	WHERE TimeStart BETWEEN @TimeStart AND @TimeEnd OR TimeEnd BETWEEN @TimeStart AND @TimeEnd;
end
