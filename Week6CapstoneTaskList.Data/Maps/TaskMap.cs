using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity.ModelConfiguration;
using Week6CapstoneTaskList.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week6CapstoneTaskList.Data.Maps
{
    internal class TaskMap : EntityTypeConfiguration<Task>
    {
        internal TaskMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
