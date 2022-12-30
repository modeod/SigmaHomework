using SigmaHomework_12_Task1.Interfaces;
using SigmaHomework_12_Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SigmaHomework_12_Task1.Services
{
    internal class PersonsFileHandler : IPersonsFileHandler
    {
        private readonly IFileHandler _fileHandler;

        public PersonsFileHandler(IFileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public void ClearPersons()
        {
            _fileHandler.WriteOverride("");
        }

        public PersonModel[]? ReadPersonsFromJSON()
        {
            var json = string.Join("", _fileHandler.Read());
            var result = JsonSerializer.Deserialize<PersonModel[]>(json);
            return result;
        }

        public void WritePersonsToJSON(PersonModel[] persons)
        {
            var json = JsonSerializer.Serialize<PersonModel[]>(persons);
            _fileHandler.Write(json);
        }
    }
}
