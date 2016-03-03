using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TotalBrowse.Domain;
using TotalBrowse.Domain.Models;


namespace TotalBrowse.Interfaces
{
    public class DirectoryHelper : IDirectoryHelper
    {
        private IFilesHelper  FilesHelper { get; set; }
        public DirectoryHelper(IFilesHelper filesHelper)
        {
            FilesHelper = filesHelper; 
        }
        public IEnumerable<System.IO.FileInfo> GetFilesInDirectory(string directoryPath)
        {
            var directory = new DirectoryInfo(directoryPath);

            return directory.GetFiles().ToList<FileInfo>();
        }


        public Folder GetFolder(string path)
        {
            var folderPath = path ?? HttpContext.Current.Server.MapPath("~");

            var directoryInfo = new DirectoryInfo(folderPath);
            FileSizes filesizes = new FileSizes() {
            NumFilesLess10mb = 0,
            NumFilesLess50mb = 0,
            NumFilesOver50mb = 0
            
            };

            FilesHelper.CalculateFilesSizes(directoryInfo, filesizes);

            Folder folder = new Folder()
            {
                Address = folderPath,
                Files = directoryInfo.GetFiles()
                .Select(file => new FileItem()
                {
                    FullName = file.FullName,
                    Name = file.Name,
                    Path = file.Directory != null ? file.Directory.Name : string.Empty,
                }
               ).ToList(),
                Name = directoryInfo.Name,
                ParentAddress = directoryInfo.Parent != null ? directoryInfo.Parent.FullName : string.Empty,
                Subdirs = directoryInfo.GetDirectories()
                .Select(directory =>
                    new FolderItem()
                    {
                        FullName = directory.FullName,
                        Name = directory.Name,
                    }
                    ).ToList(),

                FileSizes = filesizes 
                
            };
                
            return folder;
        }

        public Folder GetBaseFolder()
        {
            var baseFolderPath = HttpContext.Current.Server.MapPath("~");
            
            return GetFolder(baseFolderPath);
        }

    }
}
