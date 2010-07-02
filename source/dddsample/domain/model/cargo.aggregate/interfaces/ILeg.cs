using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using dddsample.domain.model.voyage.aggregate;
using dddsample.domain.model.voyage.aggregate.interfaces;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface ILeg : IValueObject<ILeg>
    {
        IVoyage voyage();
        ILocation load_location();
        ILocation unload_location();
        IDate load_time();
        IDate unload_time();
        int GetHashCode();
        bool Equals(object the_to_compare_object);
    }
}