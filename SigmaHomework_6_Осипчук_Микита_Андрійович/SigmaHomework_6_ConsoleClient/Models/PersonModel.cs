using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_6_ConsoleClient.Models
{
    public class PersonModel : ICloneable
    {
        public PersonModel(string? name, string surname, string? passportId)
        {
            Name = name;
            Surname = surname;
            PassportId = passportId;
        }

        public string? Name { get; set; }

        public string Surname { get; set; }

        public string? PassportId { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object? obj)
        {
            return obj is PersonModel model &&
                   Name == model.Name &&
                   Surname == model.Surname &&
                   PassportId == model.PassportId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Surname, PassportId);
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
