using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServersProject.Shared
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string League { get; set; } = string.Empty;
        public string Coach { get; set; } = string.Empty;
    }
}
