using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.location.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IHandlingActivityFactory
    {
        IHandlingActivity create_handling_activity_using(ILocation the_location, IHandlingEventType the_handling_event_type);
    }
}