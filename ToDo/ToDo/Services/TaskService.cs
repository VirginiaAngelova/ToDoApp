using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDo.Areas.Identity;
using ToDo.Areas.Identity.Models;
using ToDo.Models;
using ToDo.Services.Interfaces;

namespace ToDo.Services
{
    public class TaskService : ITaskService
    {
        private ToDoAppContext _context;
        public TaskService(ToDoAppContext context)
        {
            _context = context;
        }

        public void AddTask(TaskModel model)
        {
            _context.ToDoLists.Add(new ToDoList()
            {

                Title = model.Title,
                ContentToDo = model.ContentToDo,
                Date = model.Date,
                Hour = model.Hour
            });
            _context.SaveChanges();
        }

        public void DeleteTask(int taskId)
        {
            ToDoList taskToBeDeleted = _context.ToDoLists.FirstOrDefault(task => task.Id == taskId);
            if (taskToBeDeleted != null)
            {
                _context.ToDoLists.Remove(taskToBeDeleted);
                _context.SaveChanges();
            }
        }

        public void EditTask(TaskModel model)
        {
            ToDoList todoList = _context.ToDoLists.FirstOrDefault(task => task.Id == model.Id);

            if (todoList != null)
            {
                todoList.Title = model.Title;
                todoList.ContentToDo = model.ContentToDo;
                todoList.Date = model.Date;
                todoList.Hour = model.Hour;

                _context.SaveChanges();
            }
        }

        public TaskModel GetTask(int taskId)
        {
            TaskModel task = _context.ToDoLists.Select(task => new TaskModel()
            {

                Id = task.Id,
                Title = task.Title,
                ContentToDo = task.ContentToDo,
                Date = task.Date,
                Hour = task.Hour,
            }).FirstOrDefault(task => task.Id == taskId);

            return task;
        }

        public List<TaskModel> GetTasks()
        {
            List<TaskModel> todoLists = _context.ToDoLists.Select(task => new TaskModel()
            {
                Id = task.Id,
                Title = task.Title,
                ContentToDo = task.ContentToDo,
                Date = task.Date,
                Hour = task.Hour,
            }).ToList();

            return todoLists;
        }
    }
}
