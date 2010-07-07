using dddsample.domain.shared;

namespace dddsample.domain.model.location.aggregate.interfaces
{
    public interface ILocationName : IValueObject<ILocationName>
    {
        int GetHashCode();
        string name();
    }
}