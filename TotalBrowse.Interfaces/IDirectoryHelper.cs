using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TotalBrowse.Domain.Models;

namespace TotalBrowse.Interfaces
{
    public interface IDirectoryHelper
     {
        IEnumerable<FileInfo> GetFilesInDirectory(string directoryPath);

        Folder GetFolder(string path);

        Folder GetBaseFolder();
    }
}
