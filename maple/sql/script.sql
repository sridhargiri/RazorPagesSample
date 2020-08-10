create database Maple

create table employee(empid int,empname varchar(50),managerid int,deptid int,salary int,DOB datetime)

create table CoveragePlan(PlanId INT IDENTITY(1,1) PRIMARY KEY,
PlanName varchar(10),DateFrom datetime,DateTo datetime, Country varchar(10))

insert into CoveragePlan (PlanName,DateFrom,DateTo,Country)
values
('Gold', '1/1/2009', '1/1/2021','USA'),
('Platinum', '1/1/2005', '1/1/2023','CAN'),
('Silver', '1/1/2001', '1/1/2026','Any')

select * from CoveragePlan

Create table RatePlan (PlanId int foreign key references CoveragePlan(Planid),Gender CHAR(1),CustomerMinAge INT,CustomerMaxAge INT,NetPrice INT)
ALTER TABLE  RatePlan ALTER COLUMN  CustomerMinAge INT NOT NULL;
ALTER TABLE  RatePlan ALTER COLUMN  CustomerMaxAge INT NOT NULL;
ALTER TABLE  RatePlan ALTER COLUMN  NetPrice INT NOT NULL;


select * from rateplan
insert into rateplan values 

(1,'M',0,40,1000),
 (1,'M',41,100,2000), 
 (1,'F',0,40,1200),
 (1,'F',41,100,2500),

 (2,'M',0,40,1500),
 (2,'M',41,100,2600),
 (2,'F',0,40,1900), 
 (2,'F',41,100,2800),

 (3,'M',0,40,1900),
 (3,'M',41,100,2900),
 (3,'F',0,40,2100),
 (3,'F',41,100,3200)

 create table Contracts
 (ContractId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
 CustomerName varchar(50),
 CustomerAddress varchar(50),
 CustomerGender CHAR(1),
 CustomerCountry varchar(50),
 CustomerDOB DATETIME NOT NULL,
 SaleDate datetime NOT NULL,
 CoveragePlan varchar(50),
 NetPrice INT NOT NULL)


 create procedure sp_createcontract 
 @CustomerName nvarchar(50),
 @CustomerAddress nvarchar(50),
 @CustomerGender char(1),
 @CustomerCountry varchar(50),
 @CustomerDOB datetime,
 @SaleDate datetime
 as
 declare @plan varchar(50)
 declare @planid int
 SELECT @plan= PlanName,@planid=planid
FROM  CoveragePlan
WHERE  @saledate between DateFrom and dateto
declare @age int
declare @price int
select @age=CONVERT(int,ROUND(DATEDIFF(hour,@CustomerDOB,GETDATE())/8766.0,0))
select @price=NetPrice from rateplan 
where gender=@CustomerGender 
and @age between CustomerMinAge 
and CustomerMaxAge 
and planid=@planid
 insert into Contracts
 (CustomerName,CustomerAddress,CustomerGender,CustomerCountry,CustomerDOB,SaleDate,CoveragePlan,NetPrice)
 values
 (@CustomerName,@CustomerAddress,@CustomerGender,@CustomerCountry,@CustomerDOB,@saledate,@Plan,@price)
