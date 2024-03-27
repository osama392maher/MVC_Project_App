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
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly MainContext context;

        public DepartmentRepository(MainContext mainContext)
        {
            this.context = mainContext;
        }

        public int Add(Department department)
        {
            context.Departments.Add(department);
            return context.SaveChanges();
        }

        public int Update(Department department)
        {
            throw new NotImplementedException();
        }

        public int Delete(Department department)
        {
            context.Departments.Remove(department);
            return context.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return context.Departments.AsNoTracking().ToList();
        }

        public Department GetById(int id)
        {
            //var department = context.Departments.Local.Where(d => d.Id == id).FirstOrDefault();
            //if (department == null)
            //	department = context.Departments.Where(d => d.Id == id).FirstOrDefault();
            //return department;
            return context.Departments.Find(id);
        }
    }
}
