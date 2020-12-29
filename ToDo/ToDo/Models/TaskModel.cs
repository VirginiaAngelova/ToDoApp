using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Display(Name = "Заглавие")]
        [Required(ErrorMessage = "Полето заглавие е задължително!")]
        [MaxLength(200, ErrorMessage = "Полето заглавие трябва да е с дулжина до 200 символа!")]
        public string Title { get; set; }

        [Display(Name = "Съдържание")]
        public string ContentToDo { get; set; }

        [Display(Name = "Дата")]
        [MaxLength(10, ErrorMessage = "Датата трябва да бъде във формат 20-12-2020")]
        [MinLength(10, ErrorMessage = "Датата трябва да бъде във формат 20-12-2020")]
        public string Date { get; set; }

        [Display(Name = "Час")]
        [MaxLength(8, ErrorMessage = "Датата трябва да бъде във формат 00-00-00")]
        [MinLength(8, ErrorMessage = "Датата трябва да бъде във формат 00-00-00")]
        public string Hour { get; set; }

 
    }
}

