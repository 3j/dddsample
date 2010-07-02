using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface ITrackingId : IValueObject<ITrackingId>
    {
        string id();
        int GetHashCode();
        bool Equals(object obj);
    }
}