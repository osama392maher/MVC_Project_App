﻿using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.BLL.Interfaces
{
    public interface IDepartmentRepository
    {
        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);

        IEnumerable<Department> GetAll();

        Department GetById(int id);
    }
}
