using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalBrowse.Domain.Models
{
    public class Folder
    {
        public Folder()
        {
            Files = new List<FileItem>();
            Subdirs = new List<FolderItem>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string ParentAddress { get; set; }
        public List<FileItem> Files { get; set; }
        public List<FolderItem> Subdirs { get; set; }
        public FileSizes FileSizes { get; set; }
        public FileSizes FileSizesSubdirs { get; set; }



    }
}