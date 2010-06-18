using dddsample.domain.shared;

namespace dddsample.domain.model.location.aggregate
{
    public interface ILocation : IEntity<ILocation>
    {
        int GetHashCode();
    }
}