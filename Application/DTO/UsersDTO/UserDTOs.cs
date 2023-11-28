using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.UsersDTO
{
    public class UserDTOs
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        [Required]
        public string? Mobile { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
