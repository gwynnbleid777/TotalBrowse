using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalBrowse.Domain
{
    public class FileSizes
    {
        public int NumFilesLess10mb { get; set; }
        public int NumFilesLess50mb { get; set; }
        public int NumFilesOver50mb { get; set; }

    }
}
