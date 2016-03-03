using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using TotalBrowse.Interfaces;
using TotalBrowse.Domain;
using TotalBrowse.Domain.Models;


namespace TotalBrowse.Controllers
{
    public class BrowseController : ApiController
    {
        private IDirectoryHelper DirectoryHelper { get; set; }
        private IFilesHelper FilesHelper {get; set;}
        private IDiskHelper DiskHelper { get; set; }


        public BrowseController(IDirectoryHelper directoryHelper, IFilesHelper filesHelper, TotalBrowse.Interfaces.IDiskHelper diskHelper)
        {
            DirectoryHelper = directoryHelper;
            FilesHelper = filesHelper;
            DiskHelper = diskHelper;
        }


        [HttpGet]
        public Folder GetBaseFolder()
        {
            return DirectoryHelper.GetBaseFolder();
        }


        [HttpGet]
        public Folder GetFolder([FromUri] string address = null)
        {
            return DirectoryHelper.GetFolder(address);
        }


        [HttpGet]
        public HttpResponseMessage GetFile([FromUri] string path)
        {
            return FilesHelper.DownloadFile(path);
        }

        [HttpGet]
        public Disk GetDrives()
        {
            return DiskHelper.GetDisks();
        }

    }
}
