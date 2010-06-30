using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.voyage.aggregate;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface ILegFactory
    {
        ILeg create_leg_using(IVoyage the_voyage, ILocation the_load_location, ILocation the_unload_location, IDate the_load_time, IDate the_unload_time);
    }
}