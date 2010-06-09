namespace dddsample.domain.shared
{
    public interface IEntity<T>
    {
        /// <summary>
        /// Entities compare by identity, not by attributes.
        /// </summary>
        /// <param name="the_other_entity">The other entity.</param>
        /// <returns><code>true</code> if the identities are the same,
        /// regardles of other attributes.</returns>
        bool has_the_same_identity_as(T the_other_entity);

        ///// <summary>
        ///// Entities have an identity.
        ///// </summary>
        ///// <returns>The identity of this entity.</returns>
        //ID identity();
    }
}