namespace dddsample.domain.shared
{
    static public class SpecificationExtensions
    {
        static public ISpecification<T> and<T>(this ISpecification<T> left_side, ISpecification<T> right_side)
        {
            return new AndSpecification<T>(left_side, right_side);
        }

        static public ISpecification<T> or<T>(this ISpecification<T> left_side, ISpecification<T> right_side)
        {
            return new OrSpecification<T>(left_side, right_side);  
        }

        static public ISpecification<T> not<T>(this ISpecification<T> to_negate)
        {
            return new NotSpecification<T>(to_negate);
        }
    }
}