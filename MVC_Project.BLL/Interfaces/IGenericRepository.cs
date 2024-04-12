using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.BLL.Interfaces
{
    public interface IGenericRepository<T> where T : ModelBase
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T department);
        int Update(T department);
        int Delete(T department);
    }
}
