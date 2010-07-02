using dddsample.domain.shared;

namespace dddsample.domain.model.voyage.aggregate.interfaces
{
    public interface IVoyage : IEntity<IVoyage>
    {
        int GetHashCode();
    }
}