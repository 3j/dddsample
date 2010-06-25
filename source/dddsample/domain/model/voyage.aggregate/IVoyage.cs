using dddsample.domain.shared;

namespace dddsample.domain.model.voyage.aggregate
{
    public interface IVoyage : IEntity<IVoyage>
    {
        int GetHashCode();
    }
}