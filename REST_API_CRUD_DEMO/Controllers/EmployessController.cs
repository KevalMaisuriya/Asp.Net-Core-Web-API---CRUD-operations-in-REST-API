using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API_CRUD_DEMO.EmployeeData;
using REST_API_CRUD_DEMO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_CRUD_DEMO.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployessController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployessController(IEmployeeData employeeData)
        {
            _employeeData = employeeData; 
        }


        #region Get EMployeee
        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetEmployee()
        {
            return Ok(_employeeData.GetEmployees());
        }
        #endregion Get EMployeee

        #region Get Employee by Id
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);

            if(employee != null)
            {
                return Ok(employee);
            }

            return NotFound($"Employee with Id: {id} was not found");
        }
        #endregion Get Employee by Id

        #region Add Employee
        [HttpPost]
        [Route("api/[controller]")]
        public ActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path
                + "/" + employee.Id, employee);
        }
        #endregion Add Employee

        #region Delete Employee
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult DeletEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            
            if(employee != null)
            {
                _employeeData.DeletEmployee(employee);
                return Ok();
            }

            return NotFound($"Employee with Id: {id} was not found");
        }
        #endregion Delete Employee

        #region Edit Employee
        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public ActionResult EditEmployee(Guid id, Employee employee)
        {
            var existingemployee = _employeeData.GetEmployee(id);

            if (existingemployee != null)
            {
                employee.Id = existingemployee.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
        #endregion Edit Employee

    }
}
