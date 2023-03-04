create database Hocphan;

use Hocphan;

create table MonHoc(
id int identity(1,1) primary key,
tenmon nvarchar(200),
idkhoahoc int,
)
go

create table KhoaHoc(
id int identity(1,1) primary key,
tenmon nvarchar(200),
)
go

alter table Monhoc
add constraint Fk_Monhoc_khoahoc
FOREIGN KEY (idkhoahoc)		
REFERENCES KhoaHoc(id)