namespace dddsample.domain.shared
{
    public class OrSpecification<T> : ISpecification<T>
    {
        readonly ISpecification<T> left_side_specification;
        readonly ISpecification<T> right_side_specification;

        public OrSpecification(ISpecification<T> left_side_specification, ISpecification<T> right_side_specification)
        {
            this.left_side_specification = left_side_specification;
            this.right_side_specification = right_side_specification;
        }

        public bool is_satisfied_by(T item)
        {
            return left_side_specification.is_satisfied_by(item) || right_side_specification.is_satisfied_by(item);
        }
    }
}