using System;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public class Cargo : ICargo, IEntity<Cargo>
    {
        readonly ITrackingId underlying_tracking_id;
        readonly IRouteSpecification underlying_route_specification;

        public Cargo(ITrackingId tracking_id, IRouteSpecification route_specification)
        {
            this.underlying_tracking_id = tracking_id;
            this.underlying_route_specification = route_specification;
        }

        public bool has_the_same_identity_as(Cargo the_other_entity)
        {
            throw new NotImplementedException();
        }

        public ITrackingId tracking_id()
        {
            return this.underlying_tracking_id;
        }

        public IRouteSpecification route_specification()
        {
            return this.underlying_route_specification;
        }
    }
}