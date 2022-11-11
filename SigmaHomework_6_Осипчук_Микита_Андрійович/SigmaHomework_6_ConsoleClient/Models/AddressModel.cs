using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaHomework_6_ConsoleClient.Models
{
    public class AddressModel : ICloneable
    {
        private PersonModel _owner;

        public PersonModel Owner
        {
            get => (PersonModel)_owner.Clone();
            set => _owner = (PersonModel)value.Clone();
        }

       
        public uint FlatNumber { get; set; }
        
        public string House { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string? Region { get; set; }

        public string? Country { get; set; }

        public AddressModel(uint flatNumber, string house, string street, string city, string? region, string country, PersonModel owner)
        {
            FlatNumber = flatNumber;
            House = house;
            Street = street;
            City = city;
            Region = region;
            Country = country;
            _owner = (PersonModel)owner.Clone();
        }



        public object Clone()
        {
            AddressModel address = MemberwiseClone() as AddressModel;
            address.Owner = this.Owner; //set => _owner = (PersonModel)value.Clone(); 

            return address;
        }

        public override bool Equals(object? obj)
        {
            return obj is AddressModel model &&
                   EqualityComparer<PersonModel>.Default.Equals(_owner, model._owner) &&
                   FlatNumber == model.FlatNumber &&
                   House == model.House &&
                   Street == model.Street &&
                   City == model.City &&
                   Region == model.Region &&
                   Country == model.Country;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_owner, FlatNumber, House, Street, City, Region, Country, Owner);
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
