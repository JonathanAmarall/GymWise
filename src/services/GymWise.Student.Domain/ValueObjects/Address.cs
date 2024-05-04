using GymWise.Core.Models.Errors;
using GymWise.Core.Models.Primitives;
using GymWise.Core.Models.Result;
using System.Text.RegularExpressions;

namespace GymWise.Student.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public const short MaxNumberLength = 50;
        public const short MinNumberLength = 1;
        public const short MaxCityLength = 100;
        public const short MinCityLength = 3;
        public const short MaxStateLength = 100;
        public const short MinStateLength = 3;
        public const short MaxNeighborhoodLength = 100;
        public const short MinNeighborhoodLength = 3;
        public const short MaxZipCodeLength = 8;
        public const short MinZipCodeLength = 7;

        private const string ZipCodeRegexPattern = @"^\d{5}-\d{3}$";
        private static readonly Lazy<Regex> ZipCodeFormatRegex = new
            Lazy<Regex>(() => new Regex(ZipCodeRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));

        protected Address(string number, string city, string state, string neighborhood, string zipCode)
        {
            Number = number;
            City = city;
            State = state;
            Neighborhood = neighborhood;
            ZipCode = zipCode;
        }

        public string Number { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Neighborhood { get; private set; }
        public string ZipCode { get; private set; }

        public static Result<Address> Create(string number, string city, string state, string neighborhood, string zipCode)
        {
            return Result
                .Create(new Address(number, city, state, neighborhood, zipCode), DomainErrors.Address.NotFound)
                .Ensure(address => ZipCodeFormatRegex.Value.IsMatch(address.ZipCode), DomainErrors.Address.ZipCodeIsNotValid)
                .Ensure(address => address.Number.Length >= MaxNumberLength || address.Number.Length <= MinNumberLength, DomainErrors.Address.NumberLengthIsNotValid)
                .Ensure(address => address.City.Length >= MaxCityLength || address.City.Length <= MinCityLength, DomainErrors.Address.CityLengthIsNotValid)
                .Ensure(address => address.State.Length >= MaxStateLength || address.State.Length <= MinStateLength, DomainErrors.Address.CityLengthIsNotValid)
                .Ensure(address => address.State.Length >= MaxStateLength || address.State.Length <= MinStateLength, DomainErrors.Address.StateLengthIsNotValid)
                .Ensure(address => address.Neighborhood.Length >= MaxNeighborhoodLength || address.State.Length <= MinNeighborhoodLength, DomainErrors.Address.NeighborhoodLengthIsNotValid)
                .Map(x => x);
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
            yield return City;
            yield return State;
            yield return Neighborhood;
            yield return ZipCode;
        }
    }
}
