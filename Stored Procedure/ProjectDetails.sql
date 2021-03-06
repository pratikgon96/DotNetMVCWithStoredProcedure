USE [project]
GO
/****** Object:  StoredProcedure [dbo].[ProjectDetails]    Script Date: 02-09-2021 11:44:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[ProjectDetails]  
(  
   @mode nvarchar(max),
   @Id int=null,
   @Name varchar (max)=null,  
   @StartDate Date=null,
   @EndDate Date=null,
   @Budget decimal=null,
   @Manager varchar(50)=null
)  
AS
BEGIN
SET NOCOUNT ON;
if(@mode='GetProject')
begin
select
Id,
Name,
StartDate,
EndDate,
Budget,
Manager from [dbo].[Project]
end

if(@mode='AddProject')
begin
insert into Project(
Name,
StartDate,
EndDate,
Budget,
Manager
)values(
@Name,
@StartDate,
@EndDate,
@Budget,
@Manager
)
end

if(@mode='GetProjectById')
begin
select
Id,
Name,
StartDate,
EndDate,
Budget,
Manager from [dbo].[Project] where Id=@Id;
end
if(@mode='UpdateProject')
begin
update [dbo].[Project]
set
Name=@Name,
StartDate=@StartDate,
EndDate=@EndDate,
Budget=@Budget,
Manager=@Manager where Id=@Id
end

END