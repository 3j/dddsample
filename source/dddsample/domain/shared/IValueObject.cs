namespace dddsample.domain.shared
{
    public interface IValueObject<T>
    {
        /// <summary>
        /// Value objects compare by the values of their attributes, they don't have an
        /// identity.
        /// </summary>
        /// <param name="the_other">The other value object.</param>
        /// <returns><code>true</code> if the given value object's and 
        /// this value object's attributes are the same.</returns>
        bool has_the_same_value_as(T the_other);
        
        /// <summary>
        /// Value objects can be freely copied.
        /// </summary>
        /// <returns>A safe, deep copy of this value object.</returns>
        T copy_into_this();
    }
}