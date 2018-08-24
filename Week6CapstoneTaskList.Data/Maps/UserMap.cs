using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using Week6CapstoneTaskList.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week6CapstoneTaskList.Data.Maps
{
    internal class UserMap : EntityTypeConfiguration<User>
    {
        internal UserMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasMany(x => x.Tasks).WithRequired(x => x.User).HasForeignKey(x => x.UserID);
        }
    }
}
