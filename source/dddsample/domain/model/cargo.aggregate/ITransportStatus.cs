using dddsample.domain.shared;

namespace dddsample.domain.model.cargo.aggregate
{
    public interface ITransportStatus : IValueObject<ITransportStatus>, IEnumeration
    {
    }
}