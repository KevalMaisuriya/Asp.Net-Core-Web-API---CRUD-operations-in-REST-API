using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REST_API_CRUD_DEMO.Models;

namespace REST_API_CRUD_DEMO.EmployeeData
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetEmployee(Guid id);

        Employee AddEmployee(Employee employee);

        void DeletEmployee(Employee employee);

        Employee EditEmployee(Employee employee);
    }
}
