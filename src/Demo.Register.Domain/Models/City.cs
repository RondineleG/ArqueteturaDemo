using Proton.Core.Exceptions;
using Proton.Register.Domain.Validators;
using System.Collections.Generic;

namespace Proton.Register.Domain.Models
{
    public class City : Entities.Base
    {
        protected City() { }

        public City(string nameCity, string ibgeCodeCity, string intrraCodeCity, bool activeCity)
        {
            NameCity = nameCity;
            IbgeCodeCity = ibgeCodeCity;
            IntrraCodeCity = intrraCodeCity;
            ActiveCity = activeCity;
            _errors = new List<string>();
        }

        public string NameCity { get; set; }

        public string IbgeCodeCity { get; set; }

        public string IntrraCodeCity { get; set; }

        public bool ActiveCity { get; set; }

        public IList<Terminal> Terminals { get; set; } = new List<Terminal>();


        //Comportamentos
        public void ChangeName(string nameCity)
        {
            NameCity = nameCity;
            Validate();
        }
        public void ChangeCity(string nameCity, string ibgeCodeCity, string intrraCodeCity, bool activeCity)
        {
            NameCity = nameCity;
            IbgeCodeCity = ibgeCodeCity;
            IntrraCodeCity = intrraCodeCity;
            ActiveCity = activeCity;
            _errors = new List<string>();

            Validate();
        }

        public override bool Validate()
        {
            var validator = new CityValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }

}
