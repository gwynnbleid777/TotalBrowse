using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using TotalBrowse.Domain;
using TotalBrowse.Interfaces;


namespace TotalBrowse.Interfaces
{
    public class FilesHelper : IFilesHelper
    {
        public /*FileSizes*/void CalculateFilesSizes(/*IEnumerable<FileInfo> files*/DirectoryInfo dInfo, FileSizes filesizes)
        {
            IEnumerable<FileInfo> files;

            //Handling of unauthorised exception
            try
            {
                files = dInfo.GetFiles();
            }
            catch (UnauthorizedAccessException)
            {
                return;
            }

            var numFilesLess10mb = files.Count(file => file.Length <= 10485760);
            var numFilesLess50mb = files.Count(file => file.Length > 10485760 && file.Length <= 52428800);
            var numFilesOver50mb = files.Count(file => file.Length >= 104857600);

            filesizes.NumFilesLess10mb += numFilesLess10mb;
            filesizes.NumFilesLess50mb += numFilesLess50mb;
            filesizes.NumFilesOver50mb += numFilesOver50mb;

            List<FolderItem> Subdirs;
            try
            {
                Subdirs = dInfo.GetDirectories()
                .Select(directory =>
                    new FolderItem()
                    {
                        FullName = directory.FullName,
                        Name = directory.Name,
                    }
                    ).ToList();
            }
            catch
            {
                return;
            }

            //folders with full path larger than 248 symbols are skipped                  

            foreach (var fI in Subdirs)
            {
                if (fI.FullName.Length > 248)
                {
                    continue;
                }
                var dI = new DirectoryInfo(fI.FullName);
                CalculateFilesSizes(dI, filesizes);
            }

            //FileSizes filesizes = new FileSizes();
            //return filesizes;
        }

        public string GetFileExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                case ".docx":
                    return "application/ms-word";               
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mp3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        public HttpResponseMessage DownloadFile(string path)
        {
            FileInfo file = new FileInfo(path);
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
            var stream = new FileStream(path, FileMode.Open);
            result.Content = new StreamContent(stream);
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = Path.GetFileName(path);
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            result.Content.Headers.ContentLength = stream.Length;
            return result;          
      
        }

             
       
    }
}
