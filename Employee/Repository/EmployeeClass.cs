using Employee.Models;
using Employee.RequestDto;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Employee.Repository
{
    public class EmployeeClass:IEmployeeInterface
    {
        private readonly sdirectdbContext sdirectdbContext = new sdirectdbContext();

        public ResponseModel GetEmployees()
        {
            ResponseModel response = new ResponseModel();
            var data = (from emp in sdirectdbContext.EmployeeJuly3s
                        where emp.IsDeleted==false
                        select new GetEmployeeDto 
                       
                        {
                            EmpId = emp.EmpId,
                            EmpName = emp.EmpName,
                            EmpEmail = emp.EmpEmail,
                            Dob= emp.Dob,
                            EmpPhone = emp.EmpPhone,
                            IsActive = emp.IsActive,
                            City = emp.City,
                            CreatedBy = emp.CreatedBy,
                            CreatedOn = emp.CreatedOn,
                        }).ToList();
            response.ResponseMessage = "Data Fetched Successfully";
            response.StatusCode= 200;
            response.dataList= data;
            return response;
        }
        public ResponseModel AddEmployeeData(AddEmplyeeDto addEmplyeeDto)
        {
            ResponseModel response = new ResponseModel();
            var data = sdirectdbContext.EmployeeJuly3s.FirstOrDefault(i => i.EmpEmail == addEmplyeeDto.EmpEmail && i.EmpPhone == addEmplyeeDto.EmpPhone);
               
                if(data!=null)
            {
                response.StatusCode = 400;
                response.ResponseMessage = "Enter Unique Details";
                return response;
            }
            else
            {
                var builder = WebApplication.CreateBuilder();
                String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
                SqlConnection  conn = new SqlConnection(ConnecStr);
                if(conn.State ==  ConnectionState.Closed) {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand("PostEmployeeJuly", conn);
                cmd.CommandType= CommandType.StoredProcedure;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = addEmplyeeDto.EmpName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = addEmplyeeDto.EmpEmail;
                cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = addEmplyeeDto.Dob;
                cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = addEmplyeeDto.EmpPhone;
                cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = addEmplyeeDto.City;

                int iReturn = cmd.ExecuteNonQuery();
                if(iReturn>0)
                {
                    response.StatusCode = 200;
                    response.ResponseMessage = "Employee Added Successfuly";
                    return response;
                }
                else
                {
                    response.StatusCode = 400;
                    response.ResponseMessage = "Employee not added";
                    return response;
                }



            }

        }

        public ResponseModel UpdateEmployee(UpdateEmployeeDto update)
        {
            ResponseModel response = new ResponseModel();

            var builder = WebApplication.CreateBuilder();
            String ConnecStr = builder.Configuration.GetConnectionString("AppConn");
            SqlConnection conn = new SqlConnection(ConnecStr);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            SqlCommand cmd = new SqlCommand("UpdateEmployeeJuly", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Id", SqlDbType.Int).Value = update.EmpId;
            cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = update.EmpName;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = update.EmpEmail;
            cmd.Parameters.Add("@Dob", SqlDbType.VarChar).Value = update.Dob;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = update.EmpPhone;
            cmd.Parameters.Add("@city", SqlDbType.VarChar).Value = update.City;

            int iReturn = cmd.ExecuteNonQuery();
            if (iReturn > 0)
            {
                response.StatusCode = 200;
                response.ResponseMessage = "Employee Updated Successfuly";
                return response;
            }
            else
            {
                response.StatusCode = 400;
                response.ResponseMessage = "Employee not Updated";
                return response;
            }
        }

        public ResponseModel2 GetEmployeeDataByid(int empId) 
        {
            ResponseModel2 response = new ResponseModel2();
            var data= (from e in sdirectdbContext.EmployeeJuly3s
                       where e.EmpId==empId 
                       select new GetEmployeeDto
                       {

                          EmpId= e.EmpId,
                          EmpEmail= e.EmpEmail,
                          EmpName= e.EmpName,
                          
                          Dob =e.Dob,
                          EmpPhone= e.EmpPhone,
                          City   = e.City,
                          IsActive= e.IsActive,
                          CreatedBy= e.CreatedBy,
                          CreatedOn =e.CreatedOn

                       }).FirstOrDefault();
            response.ResponseMessage = "Data of Employee Fetched";
            response.StatusCode = 200;
            response.data = data;
           return response;
        }


       public ResponseModel DeleteEmployee(int id)
        {
            ResponseModel response = new ResponseModel();
            var data = sdirectdbContext.EmployeeJuly3s.FirstOrDefault(i => i.EmpId == id);
            if (data != null) 
            { 
                data.IsDeleted= true;
                sdirectdbContext.Update(data);
                sdirectdbContext.SaveChanges();
                response.ResponseMessage = "Data Deleted Successfully";
                response.StatusCode= 200;
                return response;
            }
            return response;
        }
    }
}
