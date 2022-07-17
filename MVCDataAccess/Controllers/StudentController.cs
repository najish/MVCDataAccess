using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCDataAccess.Models;
using MVCDataAccess.Repository;
using MVCDataAccess.ViewModels;
using System;
using System.Linq;

namespace MVCDataAccess.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository repo;

        public StudentController(IStudentRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents(string sortOrder,string searchString,bool reverse = false)
        {
            var list = await repo.GetStudents();
            if (reverse)
            {
                list.Reverse();
                reverse = false;
            }
            else
                list.Reverse();
            ViewData["NameSortParam"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var students = new List<Student>();
            var s = new Student();
            if (String.IsNullOrEmpty(searchString) == false)
            {
                list.ForEach(x =>
                {
                    if (x.Name.Contains(searchString))
                        students.Add(x);
                });
            }
            if (students.Count > 0)
            {

                return View(students);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    list.OrderByDescending(option => option.Name);
                    break;
            }
            return View(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute]int id)
        {
            var student = await repo.GetStudent(id);
            return View(student);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(StudentViewModel model)
        {
            var student = await repo.AddStudent(model);
            return RedirectToAction("GetStudents");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await repo.GetStudent(id);
            var model = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StudentViewModel model)
        {
            var student = await repo.UpdateStudent(model);
            return RedirectToAction("GetStudents","Student");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await repo.GetStudent(id);
            var model = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(StudentViewModel model)
        {
            await repo.DeleteStudent(model.Id);
            return RedirectToAction("GetStudents","Student");
        }

    }
}
