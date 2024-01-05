using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aspros.SaaS.System.Application.ViewModel
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        //public string Path { get;  set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public string Icon { get; set; }
        public string Component { get; set; }
        public string Permission { get; set; }
        public int Sort { get; set; }
    }
}
