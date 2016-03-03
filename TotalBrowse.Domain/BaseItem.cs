using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalBrowse.Domain
{
    public abstract class BaseItem
    {
        public string Name { get; set; }
        public string FullName { get; set; }
    }
}
