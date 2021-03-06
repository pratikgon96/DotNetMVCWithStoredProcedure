USE [project]
GO
/****** Object:  StoredProcedure [dbo].[EmployeeDetails]    Script Date: 02-09-2021 10:57:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[EmployeeDetails]
@mode nvarchar(max),
@Id int=null,
@FirstName varchar(50)=null,
@LastName varchar(50)=null,
@DOB date=null,
@Contact bigint=null,
@RoleId int=null
AS
BEGIN
SET NOCOUNT ON;
if(@mode='GetEmployee')
begin
select
Id,
FirstName,
LastName,
DOB,
Contact,
RoleId from [dbo].[Employee]
end

if(@mode='AddEmployee')
begin
insert into Employee(
Id,
FirstName,
LastName,
DOB,
Contact,
RoleId
)values(
@Id,
@FirstName,
@LastName,
@DOB,
@Contact,
@RoleId
)
end

if(@mode='GetEmpById')
begin
select
Id,
FirstName,
LastName,
DOB,
Contact,
RoleId from [dbo].[Employee] where Id=@Id;
end

if(@mode='UpdateEmp')
begin
update [dbo].[Employee]
set
RoleId=@RoleId where Id=@Id
end
END
