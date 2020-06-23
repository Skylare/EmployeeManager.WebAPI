using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManager.WebAPI.Dtos
{
    public class JobCategoryUpdateDto
    {
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
    }
}
