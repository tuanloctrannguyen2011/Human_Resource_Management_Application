use master
CREATE DATABASE HumanResource_V4
--ON PRIMARY(
--	name = 'HRM',
--	filename = 'D:\Mics\db\HRM.mdf'
--)
--LOG ON(
--	name = 'HRM_log',
--	filename = 'D:\Mics\db\HRM_log.ldf'
--)
GO
USE HumanResource_V4
GO

CREATE TABLE Staff
(
	staff_id char(10) not null unique,
	staff_name nvarchar(50) not null,
	staff_gender char(6) not null default('male') check(staff_gender='male' or staff_gender='female'),
	staff_birthdate date not null,
	staff_phoneNo char(11) not null,
	staff_mail char(50) not null,
	staff_address char(200) not null,
	staff_status bit not null
)

CREATE TABLE Account
(
	acc_id char(10) not null unique,
	password char(20) not null,
	role_name char(10) not null check(role_name = 'admin' OR role_name = 'hrstaff' OR role_name = 'staff' OR role_name = 'manager')
)

CREATE TABLE Contract
(
	contract_id char(10) not null unique,
	contract_name nvarchar(30) not null,
	shift_id char(10) not null,
	job_id char(10) not null,
	dept_id char(10) not null,
	salary int not null,
	begin_date date not null,
	end_date date null
)


CREATE TABLE Staff_Contract
(
	staff_id char(10) not null unique,
	contract_id char(10) not null unique
)

CREATE TABLE JobTitle
(
	job_id char(10) not null unique,
	job_name char(20) not null unique,
	job_desc nvarchar(500)
)

CREATE TABLE Department
(
	dept_id char(10) not null unique,
	dept_name nvarchar(30) not null
)

CREATE TABLE Shift
(
	shift_id char(10) not null unique,
	shift_time char(20) not null check(shift_time = 'ca sang' or shift_time = 'ca chieu' or shift_time = 'ca ngay')
)

CREATE TABLE Evaluation
(
	eva_id char(10) not null unique,
	eva_type char(10) check(eva_type = 'good' or eva_type = 'bad'),
	eva_desc nvarchar(100),
	staff_id char(10) not null,
	eva_date date not null
)

CREATE TABLE Notification
(
	noti_id char(10) not null unique,
	noti_desc nvarchar(1000) not null
)

GO

--Insert values

INSERT into dbo.JobTitle
values
	('0000000001', 'CEO', null),
	('0000000002', 'Project manager', null),
	('0000000003', 'HR staff', null),
	('0000000004', 'IT staff', null),
	('0000000005', 'Finance staff', null),
	('0000000006', 'Sanitor', null),
	('0000000007', 'Admin', null)

INSERT into dbo.Shift
values
	('0000000001', 'ca ngay'),
	('0000000002', 'ca sang'),
	('0000000003', 'ca chieu')

INSERT into dbo.Department
values
	('0000000001', 'IT developer'),
	('0000000002', 'Human Resource Management'),
	('0000000003', 'Finance Management'),
	('0000000004', 'Head Office'),
	('0000000005', 'Office Maintainment')

INSERT into dbo.Contract
values
	('0000000001', N'Hợp đồng nhân sự', '0000000002', '0000000001', '0000000004', 5000, '2018-12-30', null),
	('0000000002', N'Hợp đồng nhân sự', '0000000001', '0000000004', '0000000001', 2000, '2018-12-30', null),
	('0000000003', N'Hợp đồng nhân sự', '0000000001', '0000000004', '0000000001', 1300, '2018-12-30', null),
	('0000000004', N'Hợp đồng nhân sự', '0000000001', '0000000002', '0000000001', 1200, '2018-12-30', null),
	('0000000005', N'Hợp đồng nhân sự', '0000000003', '0000000006', '0000000005', 1400, '2018-12-30', null),
	('0000000006', N'Hợp đồng nhân sự', '0000000003', '0000000006', '0000000005', 2100, '2018-12-30', null),
	('0000000007', N'Hợp đồng nhân sự', '0000000003', '0000000006', '0000000005', 1700, '2018-12-30', null),
	('0000000008', N'Hợp đồng nhân sự', '0000000001', '0000000004', '0000000001', 1300, '2018-12-30', null),
	('0000000009', N'Hợp đồng nhân sự', '0000000001', '0000000003', '0000000002', 1300, '2018-12-30', null),
	('0000000010', N'Hợp đồng nhân sự', '0000000001', '0000000004', '0000000001', 1500, '2018-12-30', null),
	('0000000011', N'Hợp đồng nhân sự', '0000000001', '0000000003', '0000000002', 1600, '2018-12-30', null),
	('0000000012', N'Hợp đồng nhân sự', '0000000001', '0000000005', '0000000003', 2000, '2018-12-30', null),
	('0000000013', N'Hợp đồng nhân sự', '0000000001', '0000000005', '0000000003', 2300, '2018-12-30', null),
	('0000000014', N'Hợp đồng nhân sự', '0000000001', '0000000005', '0000000003', 1900, '2018-12-30', null),
	('0000000015', N'Hợp đồng nhân sự', '0000000001', '0000000007', '0000000004', 1500, '2018-12-30', null)


INSERT into dbo.Staff
values
	('0000000001', N'Trần Văn Kim Anh', 'female', '1995-12-30', '0908123456', 'tranvankima@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000002', N'Nguyễn Văn Bảo', 'male', '1995-12-30', '0908123457', 'nguyenvanb@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000003', N'Quách Thị Cung', 'female', '1995-12-30', '0908123458', 'quachthic@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000004', N'Trần Dung', 'male', '1995-12-30', '0908123459', 'trand@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000005', N'Nguyễn Thị Minh Em', 'female', '1995-12-30', '0908123410', 'nguyenthiminhe@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000006', N'Dương Quốc Phú', 'male', '1995-12-30', '0908123411', 'duongquocf@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000007', N'Mai Đặng Giang', 'male', '1995-12-30', '0908123412', 'maidangg@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000008', N'Từ Quốc Hưng', 'male', '1995-12-30', '0908123413', 'tuquoch@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000009', N'Trần Nguyễn Tuấn Liễu', 'male', '1995-12-30', '0908123414', 'trannguyentuani@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000010', N'Nguyễn Nhật Linh', 'male', '1995-12-30', '0908123415', 'nguyennhatj@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000011', N'Trần Thùy Kim', 'female', '1995-12-30', '0908123416', 'tranthuyk@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000012', N'Trần Quốc Lộc', 'male', '1995-12-30', '0908123417', 'tranquocl@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000013', N'Phạm Ban Mai', 'female', '1995-12-30', '0908123418', 'phambangm@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000014', N'Lưu Dược Phi', 'female', '1995-12-30', '0908123419', 'luuduocn@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1),
	('0000000015', N'Ngô Quyền', 'male', '1995-12-30', '0908123420', 'ngoo@gmail.com', N'17A-Bình Thới-P.11-Q.11', 1)

INSERT into dbo.Staff_Contract
values
	('0000000001', '0000000001'),
	('0000000002', '0000000002'),
	('0000000003', '0000000003'),
	('0000000004', '0000000004'),
	('0000000005', '0000000005'),
	('0000000006', '0000000006'),
	('0000000007', '0000000007'),
	('0000000008', '0000000008'),
	('0000000009', '0000000009'),
	('0000000010', '0000000010'),
	('0000000011', '0000000011'),
	('0000000012', '0000000012'),
	('0000000013', '0000000013'),
	('0000000014', '0000000014'),
	('0000000015', '0000000015')

INSERT into dbo.Account
values
	('0000000001', 'qwerty', 'manager'),
	('0000000002', 'qwerty', 'staff'),
	('0000000003', 'qwerty', 'staff'),
	('0000000004', 'qwerty', 'manager'),
	('0000000005', 'qwerty', 'staff'),
	('0000000006', 'qwerty', 'staff'),
	('0000000007', 'qwerty', 'staff'),
	('0000000008', 'qwerty', 'staff'),
	('0000000009', 'qwerty', 'hrstaff'),
	('0000000010', 'qwerty', 'staff'),
	('0000000011', 'qwerty', 'hrstaff'),
	('0000000012', 'qwerty', 'staff'),
	('0000000013', 'qwerty', 'staff'),
	('0000000014', 'qwerty', 'staff'),
	('0000000015', 'qwerty', 'admin')

INSERT into dbo.Evaluation
values
	('0000000001', 'good', N'Đã hoàn thành tốt công việc', '0000000004', '2019-1-1'),
	('0000000002', 'good', N'Đã hoàn thành tốt công việc', '0000000009', '2019-1-2'),
	('0000000003', 'bad', N'Không hoàn thành tốt công việc', '0000000003', '2019-1-3'),
	('0000000004', 'bad', N'Vắng mặt trong buổi họp', '0000000002', '2019-1-4')

INSERT into dbo.Notification
values
	('0000000001', N'Chào mừng đến với công ty')
GO
--Create constraints

ALTER TABLE Account ADD 
	CONSTRAINT pk_acc PRIMARY KEY(acc_id),
	CONSTRAINT fk_acc_staff FOREIGN KEY(acc_id) REFERENCES Staff(staff_id)

ALTER TABLE Staff ADD
	CONSTRAINT pk_staff PRIMARY KEY(staff_id)

ALTER TABLE Contract ADD
	CONSTRAINT pk_contract PRIMARY KEY(contract_id),
	CONSTRAINT fk_contract_dept FOREIGN KEY(dept_id) REFERENCES Department(dept_id),
	CONSTRAINT fk_contract_shift FOREIGN KEY(shift_id) REFERENCES Shift(shift_id),
	CONSTRAINT fk_contract_job FOREIGN KEY(job_id) REFERENCES JobTitle(job_id)

ALTER TABLE Department ADD
	CONSTRAINT pk_department PRIMARY KEY(dept_id)

ALTER TABLE Shift ADD
	CONSTRAINT pk_shift PRIMARY KEY(shift_id)

ALTER TABLE JobTitle ADD
	CONSTRAINT pk_job PRIMARY KEY(job_id)

ALTER TABLE Staff_Contract ADD
	CONSTRAINT pk_s_c PRIMARY KEY(staff_id,contract_id),
	CONSTRAINT fk_c FOREIGN KEY(contract_id) REFERENCES Contract(contract_id),
	CONSTRAINT fk_s FOREIGN KEY(staff_id) REFERENCES Staff(staff_id)

ALTER TABLE Evaluation ADD
	CONSTRAINT pk_eva PRIMARY KEY(eva_id),
	CONSTRAINT fk_eva_staff FOREIGN KEY(staff_id) REFERENCES Staff(staff_id)

ALTER TABLE Notification ADD
	CONSTRAINT pk_noti PRIMARY KEY(noti_id)

GO

-------
--BCrypt password
ALTER TABLE [dbo].[Account]
 ALTER COLUMN [password] char(300) not null;
update [dbo].[Account]	
set [password]= '$2a$12$KRifz6rfNoX3IKjBpzUjFOxG42jwFHthcBpzDV4uKEirYHjanL.Uu' 
----
