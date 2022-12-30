using SigmaHomework_12_Task1.Models;

namespace SigmaHomework_12_Task1.Interfaces
{
    internal interface IPersonsGenerator
    {
        PersonModel[] GeneratePersons(int count);
    }
}