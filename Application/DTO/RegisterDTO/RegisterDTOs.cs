using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO.RegisterDTO
{
    public class RegisterDTOs
    {
            [Required]
            public int Id { get; set; }
            [Required]
            public string? FullName { get; set; }
            [Required]
            public string? Mobile { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string? Password { get; set; }
            [Required]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن با یکدیگر متفاوت هستند")]
            public string? RePassword { get; set; }
    }
}
