using AppUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.DataLayer.Repositories
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int id);
        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);
        Employee Delete(int id);
        IQueryable<Employee> Employees { get; set; }
    }
}
