namespace dddsample.domain.shared
{
    /// <summary>
    /// Specification interface.
    /// Use <code>AbstractSpecification</code> as base for creating specifications,
    /// and only the method <code>is_satisfied_by(Object)</code> must be implemented.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Check if <code>item</code> is satisfied by the specification.
        /// </summary>
        /// <param name="item">Object to test.</param>
        /// <returns><code>true</code> if <code>item</code> 
        /// satisfies the specification.</returns>
        bool is_satisfied_by(T item);

        /// <summary>
        /// Create a new specification that is the AND operation 
        /// of <code>this</code> specification and another specification.
        /// </summary>
        /// <param name="spec">Specification to AND.</param>
        /// <returns>A new specification.</returns>
        ISpecification<T> and(ISpecification<T> spec);

        /// <summary>
        /// Create a new specification that is the OR operation 
        /// of <code>this</code> specification and another specification.
        /// </summary>
        /// <param name="spec">Specification to OR.</param>
        /// <returns>A new specification.</returns>
        ISpecification<T> or(ISpecification<T> spec);

        /// <summary>
        /// Create a new specification that is the NOT operation 
        /// of <code>this</code> specification.
        /// </summary>
        /// <returns>A new specification.</returns>
        ISpecification<T> not();
    }
}