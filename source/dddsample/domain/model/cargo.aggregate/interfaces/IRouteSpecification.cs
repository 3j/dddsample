using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface IRouteSpecification :  ISpecification<IItinerary>, IValueObject<IRouteSpecification>
    {
        ILocation origin();
        ILocation destination();
        IDate arrival_dealine();
        int GetHashCode();
        bool Equals(object the_to_compare_object);
    }
}