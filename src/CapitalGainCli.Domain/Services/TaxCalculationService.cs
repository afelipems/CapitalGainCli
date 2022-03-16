using CapitalGainCli.Domain.Entities;
using System.Collections.Generic;

namespace CapitalGainCli.Domain.Services
{
    public static class TaxCalculationService
    {
        private const decimal TaxCollectionMinimumThreshold = 20000;

        public static List<TaxCalculationResult> CalculateTaxes(List<FinancialOperation> financialOperations)
        {
            return new List<TaxCalculationResult>();
        }
    }
}
