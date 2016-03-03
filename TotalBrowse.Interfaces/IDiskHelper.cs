using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TotalBrowse.Domain;
using TotalBrowse.Domain.Models;

namespace TotalBrowse.Interfaces
{
    public interface IDiskHelper
    {
       Disk GetDisks();
    }
}
