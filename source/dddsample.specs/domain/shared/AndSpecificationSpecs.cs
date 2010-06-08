using dddsample.domain.shared;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.shared
{
    public class concern_for_the_and_specification : Observes<ISpecification<IWhateverType>, AndSpecification<IWhateverType>> { }

    public class when_asked_if_an_item_that_meets_both_conditions_satisfies_the_and_operator_specification : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            the_item_that_meets_both_conditions = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_both_conditions))
                .Return(true);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_both_conditions))
                .Return(true);

            create_sut_using(() => new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_both_conditions);

        It should_confirm_that_the_and_operator_specification_was_satisfied = () => result.ShouldBeTrue();
        It should_evaluate_the_left_side_condition = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_both_conditions));
        It should_evaluate_the_right_side_condition = () =>
            right_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_both_conditions));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_both_conditions;
    }

    public class when_asked_if_an_item_that_meets_only_the_left_side_condition_satisfies_the_and_operator_specification : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            
            the_item_that_meets_the_left_side_condition = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_left_side_condition))
                .Return(true);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_left_side_condition))
                .Return(false);

            create_sut_using(() => new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_the_left_side_condition);

        It should_confirm_that_the_and_operator_specification_was_not_satisfied = () => result.ShouldBeFalse();
        It should_evaluate_the_left_side_condition = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_left_side_condition));
        It should_evaluate_the_right_side_condition = () =>
            right_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_left_side_condition));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_the_left_side_condition;
    }

    public class when_asked_if_an_item_that_meets_only_the_right_side_condition_satisfies_the_and_operator_specification : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            the_item_that_meets_the_right_side_condition = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_right_side_condition))
                .Return(false);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_right_side_condition))
                .Return(true);

            create_sut_using(() => new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_the_right_side_condition);

        It should_confirm_that_the_and_operator_specification_was_not_satisfied = () => result.ShouldBeFalse();
        It should_evaluate_the_left_side_condition = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_right_side_condition));
        It should_not_evaluate_the_right_side_condition = () =>
            right_side_specification
                .never_received(x => x.is_satisfied_by(the_item_that_meets_the_right_side_condition));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_the_right_side_condition;
    }

    public class when_asked_if_an_item_that_does_not_meet_any_of_the_conditions_satisfies_the_and_operator_specification : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            the_item_that_meets_no_condition = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_no_condition))
                .Return(false);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_no_condition))
                .Return(false);

            create_sut_using(() => new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_no_condition);

        It should_confirm_that_the_and_operator_specification_was_not_satisfied = () => result.ShouldBeFalse();
        It should_evaluate_the_left_side_condition = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_no_condition));
        It should_not_evaluate_the_right_side_condition = () =>
            right_side_specification
                .never_received(x => x.is_satisfied_by(the_item_that_meets_no_condition));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_no_condition;
    }
}