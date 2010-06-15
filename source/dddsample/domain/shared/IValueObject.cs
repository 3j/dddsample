namespace dddsample.domain.shared
{
    public interface IValueObject<T>
    {
        /// <summary>
        /// Value objects compare by the values of their attributes, 
        /// they don't have an identity.
        /// </summary>
        /// <param name="the_other_value_object">The other value object.</param>
        /// <returns><code>true</code> if the given value object's and 
        /// this value object's attributes are the same.</returns>
        bool has_the_same_value_as(T the_other_value_object);
    }
}