
using System.Collections.Generic;
using ToDo.Areas.Identity.Models;
using ToDo.Models;

namespace ToDo.Services.Interfaces
{
    public interface ITaskService
    {
        public void AddTask(TaskModel model);
        public void EditTask(TaskModel model);

        public TaskModel GetTask(int taskId);
        public List<TaskModel> GetTasks();
        public void DeleteTask(int taskId);

    }
}
