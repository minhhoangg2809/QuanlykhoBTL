--use [master]
--go 

--create database QuanlyKhoDoanhNghiep
--go

use [QuanlyKhoDoanhNghiep]
go

create table DONVITINH
(
  ma_donvi varchar(255) not null primary key,
  ten_donvi nvarchar(255) not null,
  mota nvarchar(255) null
) 
go

create table NHACUNGCAP
(
  ma_nhacungcap varchar(255) not null primary key,
  ten_nhacungcap nvarchar(255) not null,
  sodienthoai nvarchar(20)  null,
  diachi nvarchar(255) not null
) 
go

create table LOAIHANG
(
  ma_loaihang varchar(255) not null primary key,
  ten_loaihang nvarchar(255) not null,
  mota nvarchar(255) null
) 
go

create table MATHANG
(
  ma_mathang varchar(255) not null primary key,
  ten_mathang nvarchar(255) not null,
  hang nvarchar(255)  null,
  dong nvarchar(255) not null,
  mota nvarchar(255) null,
  
  ma_loaihang varchar(255)  null,
  ma_nhacungcap varchar(255)  null,
  ma_donvi varchar(255)  null
) 
go


create table KHACHHANG
(
	ma_khachhang varchar(255) not null primary key,
	ten_khachhang nvarchar(255) not null,
	sodienthoai nvarchar(20) null,
	diachi nvarchar(255) not null
)
go

create table QUYEN
(
	ma_quyen int identity(1,1) not null primary key,
	ten_quyen nvarchar(255) not null,
	mota nvarchar(255)  null
)
go

create table NHANVIEN
(
	ma_nhanvien varchar(255) not null primary key,
	ten_nhanvien nvarchar(255) not null,
	ngaysinh nvarchar(20) not null,
	sodienthoai nvarchar(20) null,
	diachi nvarchar(255) not null,
	
	ma_quyen int null
)
go

create table TAIKHOAN
(
	ma_taikhoan varchar(255) not null primary key,
	ten_taikhoan nvarchar(255) not null,
	matkhau nvarchar(255) not null,
	email nvarchar(255)not null,
	ma_nhanvien varchar(255)  null,
	IsDeleted bit null
)
go

alter table MATHANG
add constraint  fk_MATHANG_ma_loai
foreign key (ma_loaihang) references LOAIHANG(ma_loaihang)
on delete SET NULL on update cascade
go

alter table MATHANG
add constraint  fk_MATHANG_ma_dv
foreign key (ma_donvi) references DONVITINH(ma_donvi)
on delete SET NULL on update cascade
go

alter table MATHANG
add constraint  fk_MATHANG_ma_nhacugcap
foreign key (ma_nhacungcap) references NHACUNGCAP(ma_nhacungcap)
on delete SET NULL on update cascade
go


create table PHIEUNHAP
(
  ma_phieunhap nvarchar(255) not null primary key,
  ngaynhap nvarchar(20) not null
)
go

create table CHITIETPHIEUNHAP
(
  ma_ctphieunhap nvarchar(255) not null primary key,
  
  soluongnhap int not null,
  soluongthuc int not null,
  soluongton int not null,
  
  gianhap float  null,
  giaxuat float  null,
  
  ghichu nvarchar(MAX) null,
  
  ma_phieunhap nvarchar(255) null,
  IsDeleted bit null
)
go

create table PHIEUXUAT
(
  ma_phieuxuat nvarchar(255) not null primary key,
  ngayxuat nvarchar(20) not null
)
go


create table CHITIETPHIEUXUAT
(
  ma_ctphieuxuat nvarchar(255) not null primary key,
  
  ma_ctphieunhap nvarchar(255)  null,
  ma_khachhang varchar(255)  null,
  ma_phieuxuat nvarchar(255) null,
  
  soluongxuat int not null,
  soluongthucxuat int not null,

  ghichu nvarchar(MAX) null,
  
  nguoitao nvarchar(50) null,
  IsDeleted bit null
)
go

alter table CHITIETPHIEUXUAT
add constraint fk_CT_maphieuxuat
foreign key (ma_phieuxuat) references PHIEUXUAT(ma_phieuxuat)
go

alter table CHITIETPHIEUXUAT
add constraint fk_Ma_khachhang
foreign key (ma_khachhang) references KHACHHANG(ma_khachhang)
on delete set null on update cascade
go

alter table CHITIETPHIEUXUAT
add constraint fk_Ma_ctnhap
foreign key (ma_ctphieunhap) references CHITIETPHIEUNHAP(ma_ctphieunhap)
on delete set null on update cascade
go


alter table CHITIETPHIEUNHAP
add constraint fk_CT_ma_phieuxuat
foreign key (ma_phieunhap) references PHIEUNHAP(ma_phieunhap)
on delete set null on update cascade
go



--alter table CHITIETPHIEUNHAP add ma_mathang varchar(255) references MATHANG(ma_mathang) null
--go

alter table CHITIETPHIEUNHAP
add constraint fk_CHITIETPHIEUNHAP_ma_mathang
foreign key (ma_mathang) references MATHANG(ma_mathang)
on delete SET NULL on update cascade
go

alter table NHANVIEN
add constraint fk_NHANVIEN_quyen
foreign key (ma_quyen) references QUYEN(ma_quyen)
on delete SET NULL on update cascade
go


alter table TAIKHOAN
add constraint fk_TAIKHOAN_nhanvien
foreign key (ma_nhanvien) references NHANVIEN(ma_nhanvien)
on delete cascade on update cascade
go

--sum(soluongnhap) as Tongnhap,sum(soluongthuc) as Tongthunhap,
--sum(soluongxuat) as Tongxuat,sum(soluongthucxuat) as Tongthucxuat,ngaynhap,ngayxuat

select MATHANG.ma_mathang ,MATHANG.ten_mathang,
(select sum(soluongnhap)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang) as Tongnhap,
(select sum(soluongthuc)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang)  as Tongnhapthuc
--(select sum(soluongxuat) from dbo.CHITIETPHIEUXUAT) as Tongxuat,
--(select sum(soluongthucxuat) from dbo.CHITIETPHIEUXUAT)  as Tongthucxuat 
from dbo.MATHANG as mathang  

left  outer join dbo.CHITIETPHIEUNHAP as ctphieunhap 
on  mathang.ma_mathang=ctphieunhap.ma_mathang 

left outer join dbo.PHIEUNHAP as phieunhap 
on ctphieunhap.ma_phieunhap=phieunhap.ma_phieunhap

left outer join dbo.CHITIETPHIEUXUAT as ctphieuxuat 
on  ctphieunhap.ma_ctphieunhap=ctphieuxuat.ma_ctphieunhap

left outer join dbo.PHIEUXUAT as phieuxuat 
on ctphieuxuat.ma_phieuxuat=phieuxuat.ma_phieuxuat

where mathang.IsDeleted=0 and ctphieunhap.IsDeleted=0 and ctphieuxuat.IsDeleted=0
go



select MATHANG.ma_mathang,ten_mathang,ngaynhap,ngayxuat,
(select sum(soluongnhap)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang) as Tongnhap,
(select sum(soluongthuc)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang)  as Tongnhapthuc,
(select sum(soluongxuat) from dbo.CHITIETPHIEUXUAT where CHITIETPHIEUXUAT.ma_ctphieunhap = ctphieunhap.ma_ctphieunhap) as Tongxuat,
(select sum(soluongthucxuat) from dbo.CHITIETPHIEUXUAT where CHITIETPHIEUXUAT.ma_ctphieunhap = ctphieunhap.ma_ctphieunhap)  as Tongthucxuat,
(select sum(soluongton)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang)  as Tonkho
from dbo.CHITIETPHIEUXUAT as ctphieuxuat

inner  join dbo.PHIEUXUAT as px on ctphieuxuat.ma_phieuxuat=px.ma_phieuxuat

inner join dbo.CHITIETPHIEUNHAP as ctphieunhap on ctphieuxuat.ma_ctphieunhap=ctphieunhap.ma_ctphieunhap

inner join dbo.PHIEUNHAP as pn on ctphieunhap.ma_phieunhap=pn.ma_phieunhap

inner join dbo.MATHANG as mathang on ctphieunhap.ma_mathang=mathang.ma_mathang
where MATHANG.ma_mathang = '1528578327'
go


declare @tongnhap int


select MATHANG.ma_mathang,ten_mathang,
 (select sum(soluongnhap)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang) as Tongnhap,
 (select sum(soluongthuc)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang)   as Tongnhapthuc
from dbo.MATHANG

--inner join CHITIETPHIEUNHAP  on mathang.ma_mathang=CHITIETPHIEUNHAP.ma_mathang

--where MATHANG.ma_mathang = '1528578327' 
go

select MATHANG.ma_mathang,ten_mathang,
 (select sum(soluongxuat)  from dbo.CHITIETPHIEUXUAT where CHITIETPHIEUXUAT.ma_ctphieunhap = CHITIETPHIEUNHAP.ma_ctphieunhap) as Tongxuat,
 (select sum(soluongthucxuat)  from dbo.CHITIETPHIEUXUAT where CHITIETPHIEUXUAT.ma_ctphieunhap = CHITIETPHIEUNHAP.ma_ctphieunhap)   as Tongxuatthuc
from dbo.CHITIETPHIEUNHAP,dbo.MATHANG

--inner join CHITIETPHIEUNHAP  on mathang.ma_mathang=CHITIETPHIEUNHAP.ma_mathang

where MATHANG.ma_mathang = CHITIETPHIEUNHAP.ma_mathang
go


create view view_thongkenhap as
select MATHANG.ma_mathang,ten_mathang,
 (select sum(soluongnhap)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang) as Tongnhap,
 (select sum(soluongthuc)  from dbo.CHITIETPHIEUNHAP where CHITIETPHIEUNHAP.ma_mathang = MATHANG.ma_mathang)   as Tongnhapthuc
from dbo.MATHANG 

go

create view view_thongkexuat as
select MATHANG.ma_mathang,ten_mathang,
 (select sum(soluongxuat)  from dbo.CHITIETPHIEUXUAT where CHITIETPHIEUXUAT.ma_ctphieunhap = CHITIETPHIEUNHAP.ma_ctphieunhap) as Tongxuat,
 (select sum(soluongthucxuat)  from dbo.CHITIETPHIEUXUAT where CHITIETPHIEUXUAT.ma_ctphieunhap = CHITIETPHIEUNHAP.ma_ctphieunhap)   as Tongxuatthuc
from dbo.CHITIETPHIEUNHAP,dbo.MATHANG

--inner join CHITIETPHIEUNHAP  on mathang.ma_mathang=CHITIETPHIEUNHAP.ma_mathang

where MATHANG.ma_mathang = CHITIETPHIEUNHAP.ma_mathang
go


drop view view_thongkenhap
go

drop view view_thongkexuat
go