﻿using MVC_Project.BLL.Interfaces;
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

        public IQueryable<Employee> GetEmployeesByAddress(string address)
        {
            return dbContext.Employees
                .Where(e => e.Address.ToLower() == address.ToLower());

        }
    }
}