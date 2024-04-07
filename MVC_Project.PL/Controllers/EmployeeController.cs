using Microsoft.AspNetCore.Mvc;
using MVC_Project.BLL.Interfaces;
using MVC_Project.DAL.Models;

namespace MVC_Project.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public IActionResult Index()
        {
            var employees = employeeRepository.GetAll();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var count = employeeRepository.Add(employee);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
                return View(employee);
            }
            return View(employee);
        }

        [NonAction]
        public IActionResult ViewWithEmployee(int? id, string viewName)
        {
            if (id is null)
            {
                return BadRequest();
            }

            var employee = employeeRepository.GetById(id.Value);
            if (employee is null)
            {
                return NotFound();
            }
            return View(viewName, employee);
        }

        public IActionResult Details(int? id)
        {
            return ViewWithEmployee(id, "Details");
        }

        public IActionResult Edit(int? id)
        {
            return ViewWithEmployee(id, "Edit");
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var count = employeeRepository.Update(employee);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
                return View(employee);
            }
            return View(employee);
        }

        public IActionResult Delete(int? id)
        {
            return ViewWithEmployee(id, "Delete");
        }

        [HttpPost]
        public IActionResult Delete(Employee employee)
        {
            var count = employeeRepository.Delete(employee);
            if (count > 0)
                return RedirectToAction(nameof(Index));
            return View(employee);
        }


    }
}
