using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.voyage.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    public class Leg : ILeg
    {
        readonly IVoyage underlying_voyage;
        readonly ILocation underlying_load_location;
        readonly ILocation underlying_unload_location;
        readonly IDate underlying_load_time;
        readonly IDate underlying_unload_time;

        internal Leg(IVoyage the_voyage, ILocation the_load_location, ILocation the_unload_location, IDate the_load_time, IDate the_unload_time)
        {
            underlying_voyage = the_voyage;
            underlying_load_location = the_load_location;
            underlying_unload_location = the_unload_location;
            underlying_load_time = the_load_time;
            underlying_unload_time = the_unload_time;
        }

        public IVoyage voyage()
        {
            return underlying_voyage;
        }

        public ILocation load_location()
        {
            return underlying_load_location;
        }

        public ILocation unload_location()
        {
            return underlying_unload_location;
        }

        public IDate load_time()
        {
            return underlying_load_time;
        }

        public IDate unload_time()
        {
            return underlying_unload_time;
        }

        public bool has_the_same_value_as(ILeg the_other_leg)
        {
            return the_other_leg != null &&
                underlying_voyage.has_the_same_identity_as(the_other_leg.voyage()) &&
                underlying_load_location.has_the_same_identity_as(the_other_leg.load_location()) &&
                underlying_unload_location.has_the_same_identity_as(the_other_leg.unload_location()) &&
                underlying_load_time.has_the_same_value_as(the_other_leg.load_time()) &&
                underlying_unload_time.has_the_same_value_as(the_other_leg.unload_time());
        }

        public override int GetHashCode()
        {
            var result = 37;
            result = result*19 + underlying_voyage.GetHashCode();
            result = result*19 + underlying_load_location.GetHashCode();
            result = result*19 + underlying_unload_location.GetHashCode();
            result = result*19 + underlying_load_time.GetHashCode();
            result = result*19 + underlying_unload_time.GetHashCode();
            return result;
        }

        public override bool Equals(object the_to_compare_object)
        {
            if (the_to_compare_object == null || this_leg_has_a_different_type_than(the_to_compare_object))
                return false;
            
            return has_the_same_value_as((ILeg)the_to_compare_object);
        }

        bool this_leg_has_a_different_type_than(object the_to_compare_object)
        {
            return GetType() != the_to_compare_object.GetType();
        }
    }
}