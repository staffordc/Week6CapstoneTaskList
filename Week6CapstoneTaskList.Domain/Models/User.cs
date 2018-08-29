using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Week6CapstoneTaskList.Domain.Models
{
    public class User : IdentityUser
    {
        public string Password { get; set; }
        public ICollection<Task> Tasks { get; set; }

    }
}
