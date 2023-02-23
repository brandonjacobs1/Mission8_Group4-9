using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission8_Group4_9.Models
{
    public class Task
    {
        [Key]
        [Required]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        [Required]
        public bool Completed { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
