using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IRouteStatus : IValueObject<IRouteStatus>
    {
        string display_name();
    }
}