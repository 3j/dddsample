using System;
using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IDate : IValueObject<IDate>
    {
        bool is_posterior_to(IDate the_other_date);
        int GetHashCode();
        DateTime datetime_value();
    }
}