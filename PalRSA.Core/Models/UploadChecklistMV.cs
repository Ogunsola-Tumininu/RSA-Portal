using PalRSA.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalRSA.Core.Models
{
    public class UploadChecklistMV
    {
        public List<BenefitDocument> BenefitDoc { get; set; }
        public BenefitFile BenefitFile { get; set; }
        public BenefitProcess BenefitProcess { get; set; }
        public List<Int32> SelectedChoices { get; set; }
    }
}
