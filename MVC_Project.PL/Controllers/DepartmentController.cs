 using Microsoft.AspNetCore.Mvc;
using MVC_Project.BLL.Interfaces;
using MVC_Project.BLL.Repositories;
using MVC_Project.DAL.Models;

namespace MVC_Project.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        
        public IActionResult Index()
        {
            var departments = departmentRepository.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var count = departmentRepository.Add(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
                return View(department);
            }           
            return View(department);
        }
    }
}
