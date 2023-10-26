using Microsoft.AspNetCore.Mvc;
using WebApiDemo.Models;
using WebApiDemo.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService services;
        public EmployeeController(IEmployeeService services)
        {
                this.services = services;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult Get()
        {
            try
            {
                var model = services.GetEmployees();
                return new ObjectResult(model);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status204NoContent);
            }
        }

        // GET api/<EmployeeController>/5
        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = services.GetEmployeeById(id);
                if (model != null)
                    return new ObjectResult(model);
                else
                    return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult Post([FromBody] Employee employee)//from body of http
        {
            try
            {
                int result = services.AddEmployee(employee);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult Put([FromBody] Employee employee)
        {
            try
            {
                int result = services.UpdateEmployee(employee);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // DELETE api/<EmployeeController>/5
       
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {

                int result = services.DeleteEmployee(id);
                if (result >= 1)
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
