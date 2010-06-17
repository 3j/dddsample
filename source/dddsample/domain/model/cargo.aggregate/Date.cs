using System;

namespace dddsample.domain.model.cargo.aggregate
{
    public class Date : IDate
    {
        DateTime underlying_date;

        public Date(DateTime the_date)
        {
            this.underlying_date = the_date;
        }

        public bool has_the_same_value_as(IDate the_other_date)
        {
            return this.underlying_date == the_other_date.datetime_value();
        }

        public bool is_posterior_to(IDate the_other_date)
        {
            return this.underlying_date > the_other_date.datetime_value();
        }

        public override int GetHashCode()
        {
            return this.underlying_date.GetHashCode();
        }

        public DateTime datetime_value()
        {
            return underlying_date;
        }
    }
}