﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Users
{
    public class Users
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public int Mobile { get; set; }
        public string Password { get; set; }
    }

}
