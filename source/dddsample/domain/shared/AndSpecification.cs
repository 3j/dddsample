namespace dddsample.domain.shared
{
    public class AndSpecification<T> : ISpecification<T>
    {
        ISpecification<T> left_side_specification;
        ISpecification<T> right_side_specification;

        public AndSpecification(ISpecification<T> leftSideSpecification, ISpecification<T> rightSideSpecification)
        {
            left_side_specification = leftSideSpecification;
            right_side_specification = rightSideSpecification;
        }

        public bool is_satisfied_by(T item)
        {
            return left_side_specification.is_satisfied_by(item) & right_side_specification.is_satisfied_by(item);
        }
    }
}