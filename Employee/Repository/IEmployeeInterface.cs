using Employee.RequestDto;

namespace Employee.Repository
{
    public interface IEmployeeInterface
    {
        public ResponseModel    GetEmployees();

        public ResponseModel AddEmployeeData(AddEmplyeeDto employee);

        public ResponseModel UpdateEmployee(UpdateEmployeeDto update);

        public ResponseModel DeleteEmployee(int id);

        public ResponseModel2 GetEmployeeDataByid(int id);
    }
}
