using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Areas.Identity.Models;
using ToDo.Models;
using ToDo.Services.Interfaces;

namespace ToDo.Controllers
{
    public class TaskController : Controller
    {
        private ITaskService _taskService;
        //  private readonly UserManager<User> userManager;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
            // this.userManager = userManager;
        }
        public IActionResult Index()
        {
            List<TaskModel> tasks = _taskService.GetTasks();
            return View(tasks);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View(new TaskModel());
        }
        [HttpPost]
        public IActionResult Add(TaskModel task)
        {
            if (!ModelState.IsValid)
            {
                return View("Add", task);
            }
            if (task.Id == 0)
            {
                // task.UserId = userManager.FindByNameAsync(User.Identity.Name).Result.Id;
                _taskService.AddTask(task);
            }
            else
            {
                _taskService.EditTask(task);
            }


            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            TaskModel task = _taskService.GetTask(Id);
            return View("Add", task);
        }
        public IActionResult Delete(int Id)
        {
            TaskModel task = _taskService.GetTask(Id);
            return View(task);
        }
        public IActionResult ConfirmDelete(int Id)
        {
            _taskService.DeleteTask(Id);
            return RedirectToAction("Index");
        }
    }
}
