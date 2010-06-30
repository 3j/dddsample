using dddsample.domain.model.handling.aggregate;
using dddsample.domain.model.location.aggregate;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IHandlingActivity : IValueObject<IHandlingActivity>
    {
        ILocation location();
        IHandlingEventType handling_event_type();
        int GetHashCode();
        bool Equals(object obj);
    }
}