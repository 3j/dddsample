using dddsample.domain.model.location.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IRouteSpecificationFactory
    {
        IRouteSpecification create_route_specification_using(ILocation the_origin_location, ILocation the_destination_location, IDate the_arrival_deadline);
    }
}