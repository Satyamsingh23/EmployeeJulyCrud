create table EmployeeJuly3
(
EmpId int primary key identity(1,1),
EmpName varchar(30) not null, 
EmpEmail varchar(30) not null,
DOB date,
EmpPhone int null,
City varchar(30),
IsActive bit default 1,
IsDeleted bit default 0,
CreatedBy varchar(20),
CreatedOn date)

insert into EmployeeJuly3
values('Kuamr', 'kumar@gmail.com', '2008-11-11', 111111, 'Dehradun', 1, 0, 'user','2023-07-03')

select * from EmployeeJuly3