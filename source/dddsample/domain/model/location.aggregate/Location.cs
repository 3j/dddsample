using System;
using dddsample.domain.model.location.aggregate.interfaces;

namespace dddsample.domain.model.location.aggregate
{
    public class Location : ILocation
    {
        readonly IUnitedNationsLocationCode underlying_united_nations_location_code;
        readonly ILocationName underlying_location_name;

        internal Location(IUnitedNationsLocationCode the_united_nations_location_code, ILocationName the_injected_location_name)
        {
            underlying_united_nations_location_code = the_united_nations_location_code;
            underlying_location_name = the_injected_location_name;
        }

        public IUnitedNationsLocationCode associated_united_nations_location_code()
        {
            return underlying_united_nations_location_code;
        }

        public string actual_location_name()
        {
            return underlying_location_name.name();
        }

        public bool has_the_same_identity_as(ILocation the_other_entity)
        {
            return the_other_entity != null &&
                underlying_united_nations_location_code.has_the_same_value_as(
                the_other_entity.associated_united_nations_location_code());
        }

        public override int GetHashCode()
        {
            var result = 37;
            result = result * 19 + underlying_united_nations_location_code.GetHashCode();
            result = result * 19 + underlying_location_name.GetHashCode();
            return result;
        }

        public override bool Equals(object the_other_location)
        {
            return has_the_same_identity_as(the_other_location as ILocation);
        }

    }
}