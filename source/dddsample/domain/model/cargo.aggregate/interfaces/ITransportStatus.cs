using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate.interfaces
{
    public interface ITransportStatus : IValueObject<ITransportStatus>, IEnumeration
    {
    }
}