using System;
using System.Collections.Generic;
using System.IO;
using TotalBrowse.Domain;
using System.Net;
using System.Net.Http;



namespace TotalBrowse.Interfaces
{
    public interface IFilesHelper
    {
        void CalculateFilesSizes(DirectoryInfo dInfo, FileSizes filesizes);
        string GetFileExtension(string fileExtension);
        HttpResponseMessage DownloadFile(string path);
    }
}
