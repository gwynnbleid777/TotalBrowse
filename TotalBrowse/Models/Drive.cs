using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalBrowse.Models
{
    public class Drive
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Files { get; set; }
        public List<Directory> Directories { get; set; }


    }
}