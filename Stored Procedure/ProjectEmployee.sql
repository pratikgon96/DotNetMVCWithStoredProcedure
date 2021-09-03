USE [project]
GO
/****** Object:  StoredProcedure [dbo].[ProjectEmployeeDetails]    Script Date: 03-09-2021 09:05:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter procedure [dbo].[ProjectEmployeeDetails]  
(  
   @mode nvarchar(max),
   @ProjectId int=null,
   @EmployeeId int=null
)  
AS
BEGIN
SET NOCOUNT ON;
if(@mode='GetProjectEmployee')
begin
select
ProjectId,
EmployeeId from [dbo].[ProjectEmployeeMapping]
end

if(@mode='AddProjectEmployee')
begin
insert into ProjectEmployeeMapping(
ProjectId,
EmployeeId
)values(
@ProjectId,
@EmployeeId
)
end
END