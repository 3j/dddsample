using System;
using dddsample.domain.model.location.aggregate.interfaces;

namespace dddsample.domain.model.location.aggregate
{
    public class UnitedNationsLocationCode : IUnitedNationsLocationCode
    {
        readonly string underlying_country_and_location_pattern;

        public UnitedNationsLocationCode(string the_country_and_location_pattern)
        {
            underlying_country_and_location_pattern = the_country_and_location_pattern;
        }

        public bool has_the_same_value_as(IUnitedNationsLocationCode the_other_value_object)
        {
            throw new NotImplementedException();
        }

        public string united_nations_location_code_representation()
        {
            return underlying_country_and_location_pattern;
        }
    }
}