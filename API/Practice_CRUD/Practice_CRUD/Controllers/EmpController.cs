using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice_CRUD.Models;

namespace Practice_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {

        List<Employee> employees = new List<Employee>()
        {
            new Employee{id=22,EName="Sai",Gender="Male",EDesig="Student",joindate="2022/8/22" }
        };

        [HttpGet]
        public async Task<IActionResult> Get()
        {


            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Employee e)
        {
            employees.Add(e);

            return Ok(employees);
        }

    }
}
