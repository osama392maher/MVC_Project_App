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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        public DepartmentRepository(MainContext dbContext) : base(dbContext)
        {
        }


        public int Add(Department department)
        {
            dbContext.Add(department);
            return dbContext.SaveChanges();
        }

        public int Update(Department department)
        {
            dbContext.Update(department);
            return dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            dbContext.Remove(department);
            return dbContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return dbContext.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            //var department = context.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            //if (department == null)
            //	department = context.Departments.Where(d => d.Id == id).FirstOrDefault();
            //return department;
            return dbContext.Departments.Find(id);
        }
    }
}
