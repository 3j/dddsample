namespace dddsample.domain.shared
{
    /// <summary>
    /// A domain event is something that is unique, but does not have a lifecycle.
    /// The identity may be explicit, for example the sequence number of a payment, 
    /// or it could be derived from various aspects of the event such as 
    /// where, when and what has happened.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDomainEvent<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="the_other_event">The other domain event.</param>
        /// <returns><code>true</code> if the given domain event 
        /// and this event are regarded as being the same event.</returns>
        bool is_the_same_event_as(T the_other_event);
    }
}