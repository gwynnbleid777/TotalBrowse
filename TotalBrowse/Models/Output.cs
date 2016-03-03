using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace TotalBrowse.Models
{
    public class Output
    {
        public List<string> Subdirs { get; set; }
        public List<string> Files { get; set; }
        public string CurrentDir { get; set; }
        public long TotalFiles { get; set; }
        public long NumFilesLess10mb { get; set; }
        public long NumFilesLess50mb { get; set; }
        public long NumFilesOver50mb { get; set; }
        public long Skipped { get; set; }
        
        public Output()
        {
            Subdirs = new List<string>();
            Files = new List<string>();   
        }  
    }
}