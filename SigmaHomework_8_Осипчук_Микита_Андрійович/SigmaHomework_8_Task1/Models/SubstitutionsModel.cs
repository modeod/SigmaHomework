using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Models
{
    public class SubstitutionsModel
    {
        public Dictionary<string, string[]> SubstitutionsDictionary { get; set; }

        public SubstitutionsModel(Dictionary<string, string[]> substitutionsDictionary)
        {
            SubstitutionsDictionary = substitutionsDictionary;
        }
    }
}
