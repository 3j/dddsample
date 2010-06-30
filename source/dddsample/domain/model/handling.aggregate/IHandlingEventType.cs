using dddsample.domain.shared;

namespace dddsample.domain.model.handling.aggregate
{
    public interface IHandlingEventType : IValueObject<IHandlingEventType>, IEnumeration
    {
        int GetHashCode();
    }
}