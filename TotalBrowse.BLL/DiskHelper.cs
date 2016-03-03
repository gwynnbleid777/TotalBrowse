using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalBrowse.Domain;
using TotalBrowse.Interfaces;
using System.IO;
using TotalBrowse.Domain.Models;

namespace TotalBrowse.Interfaces
{
    public class DiskHelper : IDiskHelper
    {                     
        public Disk GetDisks()
        {
            var di = DriveInfo.GetDrives();

            //List<DiskItem> disks = new List<DiskItem>();
            Disk disk = new Disk()
            {

            };

            

            
            int i = 0;
            foreach (DriveInfo drive in di)
            {
                if (drive.IsReady && drive.DriveFormat != "HFS")
                {

                    disk.Disks.Add(new DiskItem { Id = i, Name = drive.Name.First().ToString(), Type = drive.DriveType.ToString() });
                    i++;
                }
            }


            return disk;              
        }


        
    }
}
