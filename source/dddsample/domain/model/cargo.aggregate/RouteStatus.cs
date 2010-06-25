namespace dddsample.domain.model.cargo.aggregate
{
    public class RouteStatus : IRouteStatus
    {
        public static readonly IRouteStatus ROUTED = new RouteStatus("ROUTED");
        public static readonly IRouteStatus NOT_ROUTED = new RouteStatus("NOT_ROUTED");
        public static readonly IRouteStatus MISROUTED = new RouteStatus("MISROUTED");
        
        
        readonly string underlying_display_name;

        RouteStatus(string the_injected_value)
        {
            underlying_display_name = the_injected_value;
        }

        public string display_name()
        {
            return underlying_display_name;
        }

        public bool has_the_same_value_as(IRouteStatus the_other_route_status)
        {
            return underlying_display_name.Equals(the_other_route_status.display_name());
        }
    }
}