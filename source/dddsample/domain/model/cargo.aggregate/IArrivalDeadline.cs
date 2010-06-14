using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface IArrivalDeadline : IValueObject<IArrivalDeadline>
    {
        bool is_afterwards_than(IArrivalDeadline final_arrival_date);
    }
}