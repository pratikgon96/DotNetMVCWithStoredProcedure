USE [project]
GO
/****** Object:  StoredProcedure [dbo].[ManageRolesDetails]    Script Date: 02-09-2021 10:57:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Alter PROCEDURE [dbo].[ManageRolesDetails]
@mode nvarchar(max),
@Id int=null,
@FirstName varchar(50)=null,
@LastName varchar(50)=null,
@DOB date=null,
@Contact bigint=null,
@RoleId int=null,
@Name varchar(50) = null
AS
BEGIN
SET NOCOUNT ON;
if(@mode='GetRole')
begin
select
e.Id,
e.FirstName,
e.LastName,
e.DOB,
e.Contact,
e.RoleId,
r.Name
from [dbo].[Employee] as e inner join Role as r on (e.RoleId = r.Id)
end

if(@mode='ManageRole')
begin
update [dbo].[Employee]
set
RoleId=@RoleId where Id=@Id
end
END