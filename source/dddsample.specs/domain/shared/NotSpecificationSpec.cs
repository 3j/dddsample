using dddsample.domain.shared;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.shared
{
    public class concern_for_the_not_specification : Observes<ISpecification<IWhateverType>, NotSpecification<IWhateverType>> { }

    public class when_asked_if_an_item_that_meets_the_condition_satisfies_the_not_operation_specification : concern_for_the_not_specification
    {
        Establish context = () =>
        {
            the_to_negate_specification = the_dependency<ISpecification<IWhateverType>>();
            the_item_that_meets_the_condition = an<IWhateverType>();

            the_to_negate_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_condition))
                .Return(true);
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_the_condition);

        It should_confirm_that_the_original_condition_has_been_negated = () => result.ShouldBeFalse();

        It should_evaluate_the_condition = () =>
            the_to_negate_specification
               .received(x => x.is_satisfied_by(the_item_that_meets_the_condition));

        static bool result;
        static IWhateverType the_item_that_meets_the_condition;
        static ISpecification<IWhateverType> the_to_negate_specification;
    }

    public class when_asked_if_an_item_that_does_not_meet_the_condition_satisfies_the_not_operation_specification : concern_for_the_not_specification
    {
        Establish context = () =>
        {
            the_to_negate_specification = the_dependency<ISpecification<IWhateverType>>();
            the_item_that_does_not_meet_the_condition = an<IWhateverType>();

            the_to_negate_specification
                .Stub(x => x.is_satisfied_by(the_item_that_does_not_meet_the_condition))
                .Return(false);
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_does_not_meet_the_condition);

        It should_confirm_that_the_original_condition_has_been_negated = () => result.ShouldBeTrue();

        It should_evaluate_the_condition = () =>
           the_to_negate_specification
               .received(x => x.is_satisfied_by(the_item_that_does_not_meet_the_condition));

        static bool result;
        static IWhateverType the_item_that_does_not_meet_the_condition;
        static ISpecification<IWhateverType> the_to_negate_specification;
    }
}