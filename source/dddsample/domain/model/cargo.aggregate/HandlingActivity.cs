using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.location.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    public class HandlingActivity : IHandlingActivity
    {
        readonly ILocation underlying_location;
        readonly IHandlingEventType underlying_handling_event_type;

        internal HandlingActivity(ILocation the_location, IHandlingEventType the_handling_event_type)
        {
            underlying_location = the_location;
            underlying_handling_event_type = the_handling_event_type;
        }

        public ILocation location()
        {
            return underlying_location;
        }

        public IHandlingEventType handling_event_type()
        {
            return underlying_handling_event_type;
        }

        public bool has_the_same_value_as(IHandlingActivity the_other_handling_activity)
        {
            return the_other_handling_activity != null &&
                underlying_location.has_the_same_identity_as(the_other_handling_activity.location()) &&
                    underlying_handling_event_type.has_the_same_value_as(
                        the_other_handling_activity.handling_event_type());
        }

        public override int GetHashCode()
        {
            var result = 37;
            result = result * 19 + underlying_location.GetHashCode();
            result = result * 19 + underlying_handling_event_type.GetHashCode();
            return result;
        }

        public override bool Equals(object the_to_compare_object)
        {
            return this.has_the_same_value_as(the_to_compare_object as IHandlingActivity);
        }
    }
}