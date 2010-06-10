namespace dddsample.domain.model.cargo.aggregate
{
    public interface ICargo
    {
        ITrackingId tracking_id();
        IRouteSpecification route_specification();
        ILocation origin_location();
    }
}