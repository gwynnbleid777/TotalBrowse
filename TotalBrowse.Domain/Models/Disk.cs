using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalBrowse.Domain.Models
{
    public class Disk
    {
        public Disk()
        {
            Disks = new List<DiskItem>();
        }

        public List<DiskItem> Disks { get; set; }
    }
}
