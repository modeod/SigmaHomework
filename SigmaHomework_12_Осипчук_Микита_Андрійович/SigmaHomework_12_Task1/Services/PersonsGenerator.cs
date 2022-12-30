using Bogus;
using SigmaHomework_12_Task1.Interfaces;
using SigmaHomework_12_Task1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_12_Task1.Services
{
    internal class PersonsGenerator : IPersonsGenerator
    {
        public PersonModel[] GeneratePersons(int count)
        {
            var faker = new Faker<PersonModel>()
                .RuleFor(p => p.Name, f => f.Name.FullName())
                .RuleFor(p => p.Age, f => (uint)f.Random.Number(0, 100))
                .RuleFor(p => p.Status, f => f.Random.Enum<Status>())
                .RuleFor(p => p.CurrentPosition, f => new Point(f.Random.Number(0, 100), f.Random.Number(0, 10)))
                .RuleFor(p => p.MaxTimeInSecondsToUseCashier, f => (uint)f.Random.Number(6, 60));

            return faker.Generate(count).ToArray();
        }
    }
}
