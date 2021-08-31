USE [project]
GO
/****** Object:  StoredProcedure [dbo].[RoleDetails]    Script Date: 30-08-2021 15:53:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[RoleDetails]
@mode nvarchar(max),
@Id int=null,
@Name varchar(50)=null
AS
BEGIN
SET NOCOUNT ON;
if(@mode='GetRole')
begin
select
Id,
Name from [dbo].[Role]
end
END