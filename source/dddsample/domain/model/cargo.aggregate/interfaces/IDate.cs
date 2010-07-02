using System;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface IDate : IValueObject<IDate>
    {
        bool is_posterior_to(IDate the_other_date);
        int GetHashCode();
        bool Equals(object the_to_compare_object);
        DateTime datetime_value();
    }
}