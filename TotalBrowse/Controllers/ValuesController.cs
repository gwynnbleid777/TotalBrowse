using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TotalBrowse.Models;
using System.IO;

namespace TotalBrowse.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly Output _output = new Output();
        List<Drive> drives = new List<Drive>();
        public IEnumerable<Drive> ReturnDrives;

        [HttpGet]
        public void Drive()
        {
            DriveInfo[] disks = DriveInfo.GetDrives();
            int i = 0;
            foreach (DriveInfo d in disks)
            {
                if (d.IsReady && d.DriveFormat != "HFS")
                {
                    this.drives.Add(
                        new Drive
                        {
                            Id = i,
                            Name = d.Name.First().ToString(),
                            Type = d.DriveType.ToString()
                        });
                    i++;
                }
            }

            foreach (Drive d in drives)
            {
                Console.WriteLine(d.Name);
            }

        }

        [HttpGet]
        public Output GetDirs([FromUri] string address)
        {
            if (true)
            {
                foreach (var disk in System.IO.Directory.GetLogicalDrives())
                {
                    FindFiles(disk);
                }
                _output.Subdirs.AddRange(System.IO.Directory.GetLogicalDrives());
                _output.CurrentDir = "My Computer";
                return _output;
            }
            try
            {
                //InitializeArrays(address);   
            }
            catch (IOException ex)
            {
                _output.Files.Add(ex.Message);
            }

            _output.CurrentDir = address;

            return _output;
        }

        void FindFiles(string address)
        {
            
            //folders with location lengths more than 248 symbols are skipped
            if (address.Length > 248)
            {
                _output.Skipped++;
                return;
            }

            try
            {
                CountFiles(address);

                foreach (var directory in System.IO.Directory.GetDirectories(address))
                {
                    FindFiles(directory);
                }
            }
            catch (UnauthorizedAccessException)
            {
                _output.Skipped++;
            }
        }

        [HttpGet]
        private Output CountFiles(string address)
        {
            foreach (var file in System.IO.Directory.GetFiles(address))
            {
                address = "D:\\";
                //files with location lengths more than 260 symbols are skipped
                if (file.Length > 260)
                {
                    _output.Skipped++;
                    
                }

                var fileInfo = new FileInfo(file);
                _output.TotalFiles++;
                if (fileInfo.Length <= 10485760)
                    _output.NumFilesLess10mb++;
                if (fileInfo.Length > 10485760 && fileInfo.Length <= 52428800)
                    _output.NumFilesLess50mb++;
                if (fileInfo.Length >= 104857600)
                    _output.NumFilesOver50mb++;
            }

            return _output;
        }





        // GET api/values
        public string[] Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}