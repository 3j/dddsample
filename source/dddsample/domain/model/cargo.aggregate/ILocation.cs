using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface ILocation : IValueObject<ILocation>
    {
        int GetHashCode();
    }
}