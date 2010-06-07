namespace dddsample.domain.shared
{
    /// <summary>
    /// Specification interface.
    /// </summary>
    /// <typeparam name="T">Object to test Type</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Check if <code>item</code> is satisfied by the specification.
        /// </summary>
        /// <param name="item">Object to test.</param>
        /// <returns><code>true</code> if <code>item</code> 
        /// satisfies the specification.</returns>
        bool is_satisfied_by(T item);
    }
}