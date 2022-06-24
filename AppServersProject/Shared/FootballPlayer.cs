using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServersProject.Shared
{
    public class FootballPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public Team? Team { get; set; }
        public int TeamId { get; set; }
}
}
