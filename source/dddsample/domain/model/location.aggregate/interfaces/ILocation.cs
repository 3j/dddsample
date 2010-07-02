using dddsample.domain.shared;

namespace dddsample.domain.model.location.aggregate.interfaces
{
    public interface ILocation : IEntity<ILocation>
    {
        int GetHashCode();
    }
}