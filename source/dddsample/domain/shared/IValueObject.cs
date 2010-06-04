namespace dddsample.domain.shared
{
    public interface IValueObject<T>
    {
        bool has_the_same_value_as(T the_other);
    }
}