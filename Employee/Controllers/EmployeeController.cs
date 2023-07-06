using Employee.Repository;
using Employee.RequestDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;

        public EmployeeController(IEmployeeInterface employeeInterface) 
        { 
            _employeeInterface = employeeInterface;
        }

        [HttpGet]
        [Route("GetAllEmployeeDetails")]

        public IActionResult GetAll()

        {
            var data = _employeeInterface.GetEmployees();
            return Ok(data);

        }
        [HttpPost]
        [Route("SaveEmployeeDetails")]

        public IActionResult SaveEmployee(AddEmplyeeDto addEmplyeeDto)
        {
            var data = _employeeInterface.AddEmployeeData(addEmplyeeDto);
            return Ok(data);
        }

        [HttpPut]
        [Route("UpdateEmployeeDetails")]

        public IActionResult UpdateEmployee(UpdateEmployeeDto update) 
        {
            var data = _employeeInterface.UpdateEmployee(update);
            return Ok(data);
        }
        [HttpDelete]
        [Route("DeleteEmplyee/id")]

        public IActionResult DeleteEmployee(int id) 
        {
            var data = _employeeInterface.DeleteEmployee(id);
            return Ok(data);    
        }
        [HttpGet]
        [Route("GetEmployeeDetails/id")]
        public IActionResult GetEmployee(int id) 
        {
             var data= _employeeInterface.GetEmployeeDataByid(id);
            return Ok(data);
        }
    }
}
