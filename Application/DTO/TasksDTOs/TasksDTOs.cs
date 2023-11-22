using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.TasksDTOs
{
    public class TasksDTOs
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Task { get; set; }
        [Required]
        public bool? status { get; set; } = false;
        [Required]
        public string? Importance { get; set; }
    }
}
