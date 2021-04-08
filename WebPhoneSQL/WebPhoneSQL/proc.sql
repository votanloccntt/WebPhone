USE [Db_Shop_Online]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[Sp_Account_Login]
@UserName varchar(50),
@Password varchar(32)
as
begin
declare @count int
declare @res bit
select @count = count(*) from Account where UserName = @UserName and Password = @Password
if @count > 0
set @res = 1
else
set @res = 0
select @res
end