using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SigmaHomework_8_Task1.Services.Interfaces;
 
namespace SigmaHomework_8_Task1.Services
{
    public class FileHandler : IFileHandler
    {
        public string PathToRead { get; set; }
        public string PathToWrite { get; set; }

        public FileHandler(string pathToRead, string pathToWrite)
        {
            PathToRead = pathToRead;
            PathToWrite = pathToWrite;
        }

        public string[] Read(string path) => File.ReadAllLines(path);

        public string[] Read() => Read(PathToRead);

        public void WriteOverride(string path, string text) => File.WriteAllText(path, text);

        public void WriteOverride(string text) => WriteOverride(PathToWrite, text);

        public void Write(string path, string text) => File.AppendAllText(path, text);

        public void Write(string text) => Write(PathToWrite, text);

    }
}
