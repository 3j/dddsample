using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface ICargo : IEntity<ICargo>
    {
        ITrackingId tracking_id();
        IRouteSpecification route_specification();
        ILocation origin_location();

        int GetHashCode();
        string ToString();
        bool Equals(object obj);
    }
}