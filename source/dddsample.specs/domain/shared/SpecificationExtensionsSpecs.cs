using dddsample.domain.shared;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;

namespace dddsample.specs.domain.shared
{
    public abstract class concern_for_the_specification_extensions : Observes {}

    public class when_using_the_and_specification_extension_method : concern_for_the_specification_extensions
    {
        Establish context = () =>
        {
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
        };

        Because of = () => result = left_side_specification.and(right_side_specification);

        It should_return_an_and_specification_type = () => result.ShouldBeAn<AndSpecification<IWhateverType>>();

        static ISpecification<IWhateverType> result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
    }

    public class when_using_the_or_specification_extension_method : concern_for_the_specification_extensions
    {
        Establish context = () =>
        {
            left_side_specification = an<ISpecification<IWhateverType>>();
            right_side_specification = an<ISpecification<IWhateverType>>();
        };

        Because of = () => result = left_side_specification.or(right_side_specification);

        It should_return_an_or_specification_type = () => result.ShouldBeAn<OrSpecification<IWhateverType>>();

        static ISpecification<IWhateverType> result;
        static ISpecification<IWhateverType> left_side_specification;
        static ISpecification<IWhateverType> right_side_specification;
    }

    public class when_using_the_not_specification_extension_method : concern_for_the_specification_extensions
    {
        Establish context = () =>
        {
            to_negate_specification = an<ISpecification<IWhateverType>>();
        };

        Because of = () => result = to_negate_specification.not();

        It should_return_a_not_specification_type = () => result.ShouldBeAn<NotSpecification<IWhateverType>>();

        static ISpecification<IWhateverType> result;
        static ISpecification<IWhateverType> to_negate_specification;
    }
}