using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVC_Project.BLL.Interfaces;
using MVC_Project.DAL.Models;
using MVC_Project.PL.Helpers;
using MVC_Project.PL.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Project.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IMapper mapper, IEmployeeRepository employeeRepository)
        {
            this.mapper = mapper;
            this.employeeRepository = employeeRepository;
        }

        public IActionResult Index(string searchInput)
        {

            var employees = Enumerable.Empty<Employee>();

            if (!string.IsNullOrEmpty(searchInput))
            {
                employees = employeeRepository.SearchByName(searchInput);
            }
            else
            {
                employees = employeeRepository.GetAll();
            }

            var employeeVm = mapper.Map<IEnumerable<EmployeeViewModel>>(employees);

            return View(employeeVm);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel employeeVm)
        {

            if (ModelState.IsValid)
            {

                employeeVm.ImageName = DocumentSettings.UploadFile(employeeVm.Image, "Images");

                var employee = mapper.Map<Employee>(employeeVm);

                var count = employeeRepository.Add(employee);

                if (count > 0)
                    TempData["AddSuccess"] = "Employee Is Created Successfuly";
                else
                {
                    TempData["AddFail"] = "An Error Has Occured, Employee Not Created :(";
                }
                
                return RedirectToAction(nameof(Index));
            }
            return View(employeeVm);
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

            var employeeVm = mapper.Map<EmployeeViewModel>(employee);

            // if view is delete
            if (viewName == "Delete")
            {
                TempData["ImageName"] = employeeVm.ImageName;
            }

            return View(viewName, employeeVm);
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
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel employeeVm)
        {

            var employee = mapper.Map<Employee>(employeeVm);
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
        public IActionResult Delete(EmployeeViewModel employeeVm)
        {

            employeeVm.ImageName = TempData["ImageName"] as string;

            var employee = mapper.Map<Employee>(employeeVm);

            var count = employeeRepository.Delete(employee);
            if (count > 0)
            {
                DocumentSettings.DeleteFile(employeeVm.ImageName, "Images");
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }


    }
}
