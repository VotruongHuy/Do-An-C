create database Chitieu
go
use Chitieu
go
create table Expenditure(
id int identity(1,1) primary key,
Ngày Datetime null,
SốTiền int null,
GhiChú nvarchar (max) null
)