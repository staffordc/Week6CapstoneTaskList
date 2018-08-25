using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6CapstoneTaskList.Data
{
    class Week6CapstoneTaskListInitializer : DropCreateDatabaseIfModelChanges<Week6CapstoneTaskListContext>
    {
        protected override void Seed(Week6CapstoneTaskListContext context)

        {
            base.Seed(context);
        }

    }
}
