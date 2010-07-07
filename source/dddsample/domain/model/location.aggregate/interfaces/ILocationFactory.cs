namespace dddsample.domain.model.location.aggregate.interfaces
{
    public interface ILocationFactory
    {
        ILocation create_location_using(IUnitedNationsLocationCode the_united_nations_location_code, ILocationName the_location_name);
    }
}