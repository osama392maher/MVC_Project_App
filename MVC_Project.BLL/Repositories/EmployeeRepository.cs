using Microsoft.EntityFrameworkCore;
using MVC_Project.BLL.Interfaces;
using MVC_Project.DAL.Data.Context;
using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(MainContext dbContext) : base(dbContext)
        {
        }

        public new IEnumerable<Employee> GetAll()
        {
            return dbContext.Employees.AsNoTracking().Include(E => E.Department).ToList();
        }


        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return dbContext.Employees
                .Where(e => e.Address.ToLower() == address.ToLower());

        }

        public IQueryable<Employee> SearchByName(string name)
        {
            return dbContext.Employees
                .Where(e => e.Name.ToLower().Contains(name.ToLower())).AsNoTracking().Include(E => E.Department);
        }
    }
}
