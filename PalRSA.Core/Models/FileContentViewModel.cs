using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalRSA.Core.Models
{
    public class FileContentViewModel
    {
        public string RenamedFileName { get; set; }
        public string FilePropertyName { get; set; }
        public string FileExtension { get; set; }
        public string ErrorMsg { get; set; }
    }
}
