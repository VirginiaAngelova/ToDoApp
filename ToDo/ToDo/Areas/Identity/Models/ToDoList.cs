using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Areas.Identity.Models
{
    public partial class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ContentToDo { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }

    }
}
