using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface IRouteSpecificationFactory
    {
        IRouteSpecification create_route_specification_using(ILocation the_origin_location, ILocation the_destination_location, IDate the_arrival_deadline);
    }
}