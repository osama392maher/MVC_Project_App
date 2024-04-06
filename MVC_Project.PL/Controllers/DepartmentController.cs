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

        [NonAction]
        public IActionResult ViewWithDepartment(int? id, string viewName)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var department = departmentRepository.GetById(id.Value);
            if (department is null)
            {
                return NotFound();
            }
            return View(viewName, department);
        }


        public IActionResult Details(int? id)
        {
            return ViewWithDepartment(id, "Details");
        }

        public IActionResult Edit(int? id)
        {
            return ViewWithDepartment(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                var count = departmentRepository.Update(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            return ViewWithDepartment(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            departmentRepository.Delete(department);
			return RedirectToAction(nameof(Index));
		}
    }
}
