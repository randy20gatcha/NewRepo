using AppUtility.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppUtility.DataLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataBaseDbContext context;
        public EmployeeRepository(DataBaseDbContext context)
        {
            this.context = context;
        }
        
        public IQueryable<Employee> Employees { get; set; }

        public Employee Add(Employee newEmployee)
        {
            context.Database.ExecuteSqlRaw("spInsertEmployee {0}, {1}, {2}",
                                           newEmployee.FirstName,
                                           newEmployee.LastName,
                                           newEmployee.EmailAddress);

            return newEmployee;
        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);

            if (employee != null)
            {   
                context.Database.ExecuteSqlRaw("spDeleteEmployee {0}", employee.Id);
            }
            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return context.Employees
                    .FromSqlRaw<Employee>("spGetEmployeeById {0}", id)
                    .ToList()
                    .FirstOrDefault();
        }

        public IQueryable<Employee> PagingList()
        {
            string searchValue = null;
            int pageNo = 0;
            int pageSize = 10;
            int sortColumn = 0;
            string sortDirection = "asc";
            return (IQueryable<Employee>)context.Employees.
                    FromSqlRaw("Execute spPagingEmployees @SearchValue,  @PageNo, @PageSize, @SortColumn, @SortDirection",
                                                                    searchValue,
                                                                    pageNo,
                                                                    pageSize,
                                                                    sortColumn,
                                                                    sortDirection).ToList();
        }

        public Employee Update(Employee updatedEmployee)
        {
            
            context.Database.ExecuteSqlRaw("spUpdateEmployee {0}, {1}, {2}, {3}",
                                            updatedEmployee.Id,
                                            updatedEmployee.FirstName,
                                            updatedEmployee.LastName,
                                            updatedEmployee.EmailAddress
                                            );     
            return updatedEmployee;
        }
    }
}
