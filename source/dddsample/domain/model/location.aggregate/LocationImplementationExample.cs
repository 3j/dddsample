using System;

namespace dddsample.domain.model.location.aggregate
{
    public class LocationImplementationExample : ILocation
    {
        /// <summary>
        /// Special Location object that marks an unknown location.
        /// </summary>
        public static readonly LocationImplementationExample UNKNOWN = new LocationImplementationExample();

        public bool has_the_same_identity_as(ILocation the_other_entity)
        {
            throw new NotImplementedException();
        }

        public ILocation location_unknown()
        {
            throw new NotImplementedException();
        }
    }
}