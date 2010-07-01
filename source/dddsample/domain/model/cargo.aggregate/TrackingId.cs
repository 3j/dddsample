using System;

namespace dddsample.domain.model.cargo.aggregate
{
    public class TrackingId : ITrackingId
    {
        readonly string underlying_id;

        public TrackingId(string the_id)
        {
            if (the_id == null)
            {
                throw new ArgumentNullException("the_id", "The injected id cannot be null.");
            }
            underlying_id = the_id;
        }

        public string id() 
        {
            return underlying_id; 
        }

        public bool has_the_same_value_as(ITrackingId the_other_tracking_id)
        {
            return (the_other_tracking_id != null) &&
                   (underlying_id.Equals(the_other_tracking_id.id()));
        }

        public override int GetHashCode()
        {
            return underlying_id.GetHashCode();
        }

        public override bool Equals(object the_to_compare_object)
        {
            if (the_to_compare_object == null || this_tracking_id_has_a_different_type_than(the_to_compare_object))
                return false;

            return this.has_the_same_value_as(the_to_compare_object as ITrackingId);
        }

        bool this_tracking_id_has_a_different_type_than(object the_to_compare_object)
        {
            return this.GetType() != the_to_compare_object.GetType();
        }
    }
}