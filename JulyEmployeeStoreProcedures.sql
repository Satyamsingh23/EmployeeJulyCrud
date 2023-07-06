create procedure PostEmployeeJuly
(@EmployeeName varchar(30),
@Email varchar(30),
@Dob date,
@phone varchar(12),
@city varchar(30))

as
begin
insert into EmployeeJuly3
(
 EmpName,
 EmpEmail,
 DOB,
 EmpPhone,
 City,
 IsActive,
 IsDeleted,
 CreatedBy,
 CreatedOn
 )
 values(@EmployeeName ,@Email,@Dob, @phone, @city, 1,0,'admin', GETDATE())
 end

 ------------------------------------------------------------------------


 create procedure UpdateEmployeeJuly
 (
 @Id int,
 @EmployeeName varchar(30),
@Email varchar(30),
@Dob date,
@phone varchar(12),
@city varchar(30)
)

as
begin
update EmployeeJuly3 set EmpName= @EmployeeName , EmpEmail=@Email, DOB= @Dob, EmpPhone=@phone ,City=@city
where
EmpId= @Id

end