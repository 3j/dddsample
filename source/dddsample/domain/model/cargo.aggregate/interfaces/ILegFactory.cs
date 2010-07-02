using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using dddsample.domain.model.voyage.aggregate;
using dddsample.domain.model.voyage.aggregate.interfaces;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface ILegFactory
    {
        ILeg create_leg_using(IVoyage the_voyage, ILocation the_load_location, ILocation the_unload_location, IDate the_load_time, IDate the_unload_time);
    }
}