
namespace Banca.Domain.Strategies.Transfer
{
    public static class TransferStrategyFactory
    {
        public static ITransferStrategy GetStrategy(string transferType)
        {
            switch (transferType)
            {
                case "TRF_PROPIAS":
                    return new OwnAccountTransferStrategy();
                case "TRF_TERCEROS":
                    return new ThirdPartyTransferStrategy();
                case "TRF_INTERNACIONAL":
                    return new InternationalTransferStrategy();
                default:
                    throw new ArgumentException("Tipo de transferencia no soportado.");
            }
        }
    }
}
