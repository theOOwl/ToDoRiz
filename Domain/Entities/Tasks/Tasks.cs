using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Tasks
{
    public class Tasks
    {
        public int Id { get; set; }
        public string? Task { get; set; }
        public bool? status { get; set; } = false;
        public string? Importance { get; set; }

    }
}
