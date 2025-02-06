using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Config
{
    public class SiteSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public int NumberUnfinishedTasks { get; set; }
    }
}
