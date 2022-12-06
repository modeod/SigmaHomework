using SigmaHomework_8_ConsoleClient.Services.Interfaces;
using SigmaHomework_8_Task1.Models;
using SigmaHomework_8_Task1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_8_Task1.Services
{
    public class SubstitutionsService : ISubstitutionsService
    {
        private readonly IParserSubstitutions _parser;
        private readonly IFileHandler _fileHandler;

        public SubstitutionsService(IParserSubstitutions parser, IFileHandler fileHandler)
        {
            _parser = parser;
            _fileHandler = fileHandler;
        }

        public SubstitutionsModel GetSubstitutions()
        {
            string[] text = _fileHandler.Read();
            return _parser.ParseTxtSubstitutions(text);
        }
    }
}
