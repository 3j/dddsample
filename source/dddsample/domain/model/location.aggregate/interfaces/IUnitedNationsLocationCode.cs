using dddsample.domain.shared;

namespace dddsample.domain.model.location.aggregate.interfaces
{
    public interface IUnitedNationsLocationCode : IValueObject<IUnitedNationsLocationCode>
    {
        int GetHashCode();
    }
}