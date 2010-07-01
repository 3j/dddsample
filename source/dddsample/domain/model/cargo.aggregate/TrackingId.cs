using System;

namespace dddsample.domain.model.cargo.aggregate
{
    public class TrackingId : ITrackingId
    {
        readonly string underlying_id;

        internal TrackingId(string the_id)
        {
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
            return this.has_the_same_value_as(the_to_compare_object as ITrackingId);
        }
    }
}