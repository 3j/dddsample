using dddsample.domain.model.location.aggregate;
using dddsample.domain.model.location.aggregate.interfaces;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace dddsample.specs.domain.model.location.aggregate
{
    public abstract class concern_for_united_nations_location_code : Observes<IUnitedNationsLocationCode, UnitedNationsLocationCode>
    {
        Establish context = () =>
        {
            the_injected_country_and_location_pattern = "SAD";
            create_sut_using(() => new UnitedNationsLocationCode(the_injected_country_and_location_pattern));
        };

        protected static string the_injected_country_and_location_pattern;
    }

    public class when_returning_the_united_nations_location_code_representation : concern_for_united_nations_location_code
    {
        Because of = () => result = sut.united_nations_location_code_representation();

        It should_return_the_underlying_country_and_location_pattern =
            () => result.ShouldEqual(the_injected_country_and_location_pattern);

        static string result;
    }

    public class when_comparing_two_legs_with_the_same_attributes : concern_for_united_nations_location_code
    {
        
    }
}