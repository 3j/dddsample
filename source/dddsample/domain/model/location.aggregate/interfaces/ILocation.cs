using dddsample.domain.shared;

namespace dddsample.domain.model.location.aggregate.interfaces
{
    public interface ILocation : IEntity<ILocation>
    {
        IUnitedNationsLocationCode associated_united_nations_location_code();
        string actual_location_name();
        int GetHashCode();
        bool Equals(object obj);
    }
}