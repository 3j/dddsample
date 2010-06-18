using dddsample.domain.shared;

namespace dddsample.domain.model.location.aggregate
{
    public interface ILocation : IEntity<ILocation>
    {
        int GetHashCode();

        // just to allow us to perform the "simulated legacy code" Itinerary exercise.
        ILocation location_unknown();
    }
}