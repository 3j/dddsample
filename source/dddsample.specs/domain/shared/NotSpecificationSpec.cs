using dddsample.domain.shared;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.shared
{
    public class concern_for_the_not_specification : Observes<ISpecification<IWhateverType>, NotSpecification<IWhateverType>> { }

    public class when_asked_if_a_to_negate_item_that_meets_the_requirement_satisfies_the_condition : concern_for_the_not_specification
    {
        Establish context = () =>
        {
            the_to_negate_specification = the_dependency<ISpecification<IWhateverType>>();
            the_to_negate_item = an<IWhateverType>();

            the_to_negate_specification
                .Stub(x => x.is_satisfied_by(the_to_negate_item))
                .Return(true);
        };

        Because of = () => result = sut.is_satisfied_by(the_to_negate_item);

        It should_confirm_that_the_condition_has_been_negated = () => result.ShouldEqual(false);

        It should_check_that_the_to_negate_requirement_has_been_met = () =>
            the_to_negate_specification
               .received(x => x.is_satisfied_by(the_to_negate_item));

        static bool result;
        static IWhateverType the_to_negate_item;
        static ISpecification<IWhateverType> the_to_negate_specification;
    }

    public class when_asked_if_a_to_negate_item_that_does_not_meet_the_requirement_satisfies_the_condition : concern_for_the_not_specification
    {
        Establish context = () =>
        {
            the_to_negate_specification = the_dependency<ISpecification<IWhateverType>>();
            the_to_negate_item = an<IWhateverType>();

            the_to_negate_specification
                .Stub(x => x.is_satisfied_by(the_to_negate_item))
                .Return(false);
        };

        Because of = () => result = sut.is_satisfied_by(the_to_negate_item);

        It should_confirm_that_the_condition_has_been_negated = () => result.ShouldEqual(true);

        It should_check_that_the_to_negate_requirement_has_not_been_met = () =>
           the_to_negate_specification
               .received(x => x.is_satisfied_by(the_to_negate_item));

        static bool result;
        static IWhateverType the_to_negate_item;
        static ISpecification<IWhateverType> the_to_negate_specification;
    }
}