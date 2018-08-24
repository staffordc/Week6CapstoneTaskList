using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6CapstoneTaskList.Domain.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string TaskDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool Complete { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
    }
}
