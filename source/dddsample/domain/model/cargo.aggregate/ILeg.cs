using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface ILeg : IValueObject<ILeg>
    {
        ILocation load_location();
        ILocation unload_location();
        IDate unload_time();
    }
}