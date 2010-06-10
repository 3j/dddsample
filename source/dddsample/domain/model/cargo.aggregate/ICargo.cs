using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface ICargo : IEntity<ICargo>
    {
        ITrackingId tracking_id();
        IRouteSpecification route_specification();
        ILocation origin_location();
    }
}