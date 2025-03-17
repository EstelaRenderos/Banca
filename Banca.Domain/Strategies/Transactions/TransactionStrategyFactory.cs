namespace Banca.Domain.Strategies.Transactions
{
    public static class TransactionStrategyFactory
    {
        public static ITransactionStrategy GetStrategy(string transactionTypeCode)
        {
            switch (transactionTypeCode)
            {
                case "DEP_EFECTIVO": 
                case "REEMBOLSO": 
                case "TRF_PROPIAS":
                case "TRF_TERCEROS": 
                case "TRF_INTERNACIONAL":
                    return new DepositStrategy();
                case "RET_EFECTIVO": 
                case "PAGO_SERVICIOS":
                case "PAGO_PRESTAMO":
                    return new WithdrawalStrategy();
                default:
                    return null;
            }
        }
    }
}
