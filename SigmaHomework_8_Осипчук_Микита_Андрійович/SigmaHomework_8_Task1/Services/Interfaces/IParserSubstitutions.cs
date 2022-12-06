using SigmaHomework_8_Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Services.Interfaces
{
    public interface IParserSubstitutions
    {
        SubstitutionsModel ParseTxtSubstitutions(string[] documentByLines);

    }
}
