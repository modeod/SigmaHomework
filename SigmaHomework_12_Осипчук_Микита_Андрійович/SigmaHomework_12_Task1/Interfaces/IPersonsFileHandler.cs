using SigmaHomework_12_Task1.Models;

namespace SigmaHomework_12_Task1.Interfaces
{
    internal interface IPersonsFileHandler
    {
        PersonModel[]? ReadPersonsFromJSON();
        void WritePersonsToJSON(PersonModel[] persons);

        void ClearPersons();
    }
}