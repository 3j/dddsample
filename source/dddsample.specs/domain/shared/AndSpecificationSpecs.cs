using dddsample.domain.shared;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using Rhino.Mocks;

namespace dddsample.specs.domain.shared
{
    public class concern_for_the_and_specification : Observes<ISpecification<IWhateverType>, AndSpecification<IWhateverType>> { }

    public class when_asked_if_an_item_that_meets_both_requirements_of_the_and_operator_satisfies_the_condition : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            //left_side_specification = the_dependency<ISpecification<IWhateverType>>();
            //right_side_specification = the_dependency<ISpecification<IWhateverType>>();
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            the_item_that_meets_the_requirements = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_requirements))
                .Return(true);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_requirements))
                .Return(true);

            create_sut_using(() => new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_the_requirements);

        It should_confirm_that_the_condition_was_satisfied = () => result.ShouldEqual(true);
        It should_check_if_the_left_side_requirement_is_met = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_requirements));
        It should_check_if_the_right_side_requirement_is_met = () =>
            right_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_requirements));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_the_requirements;
    }

    public class when_asked_if_an_item_that_meets_only_the_left_side_requirement_of_the_and_operator_satisfies_the_condition : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            //left_side_specification = the_dependency<ISpecification<IWhateverType>>();
            //right_side_specification = the_dependency<ISpecification<IWhateverType>>();
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            
            the_item_that_meets_the_left_side_requirement = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_left_side_requirement))
                .Return(true);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_left_side_requirement))
                .Return(false);

            create_sut_using(()=> new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_the_left_side_requirement);

        It should_confirm_that_the_condition_was_satisfied = () => result.ShouldEqual(false);
        It should_check_if_the_left_side_requirement_is_met = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_left_side_requirement));
        It should_check_if_the_right_side_requirement_is_not_met = () =>
            right_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_left_side_requirement));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_the_left_side_requirement;
    }

    public class when_asked_if_an_item_that_meets_only_the_right_side_requirement_of_the_and_operator_satisfies_the_condition : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            //left_side_specification = the_dependency<ISpecification<IWhateverType>>();
            //right_side_specification = the_dependency<ISpecification<IWhateverType>>();
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            the_item_that_meets_the_right_side_requirement = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_right_side_requirement))
                .Return(true);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_right_side_requirement))
                .Return(false);

            create_sut_using(() => new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_the_right_side_requirement);

        It should_confirm_that_the_condition_was_satisfied = () => result.ShouldEqual(false);
        It should_check_if_the_left_side_requirement_is_not_met = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_right_side_requirement));
        It should_check_if_the_right_side_requirement_is_met = () =>
            right_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_right_side_requirement));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_the_right_side_requirement;
    }

    public class when_asked_if_an_item_that_does_not_meet_any_of_the_requirements_of_the_and_operator_satisfies_the_condition : concern_for_the_and_specification
    {
        Establish context = () =>
        {
            //left_side_specification = the_dependency<ISpecification<IWhateverType>>();
            //right_side_specification = the_dependency<ISpecification<IWhateverType>>();
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
            the_item_that_meets_the_requirements = an<IWhateverType>();

            left_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_requirements))
                .Return(false);
            right_side_specification
                .Stub(x => x.is_satisfied_by(the_item_that_meets_the_requirements))
                .Return(false);

            create_sut_using(() => new AndSpecification<IWhateverType>(left_side_specification, right_side_specification));
        };

        Because of = () => result = sut.is_satisfied_by(the_item_that_meets_the_requirements);

        It should_confirm_that_the_condition_was_not_satisfied = () => result.ShouldEqual(false);
        It should_check_if_the_left_side_requirement_is_not_met = () =>
            left_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_requirements));
        It should_check_if_the_right_side_requirement_is_not_met = () =>
            right_side_specification
                .received(x => x.is_satisfied_by(the_item_that_meets_the_requirements));

        static bool result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
        static IWhateverType the_item_that_meets_the_requirements;
    }
}