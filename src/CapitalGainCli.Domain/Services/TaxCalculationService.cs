using CapitalGainCli.Domain.Entities;
using CapitalGainCli.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CapitalGainCli.Domain.Services
{
    public static class TaxCalculationService
    {
        private const decimal TaxCollectionMinimumThreshold = 20000;

        public static List<TaxCalculationResult> CalculateTaxes(List<FinancialOperation> financialOperations)
        {
            var resultList = new List<TaxCalculationResult>();
            var averageOperationValue = CalculateAssetWeightedAverageValue(financialOperations.Where(x => x.Operation == OperationType.Buy));

            foreach(var operation in financialOperations)
            {
                if(operation.Operation == OperationType.Buy || operation.UnitCost <= averageOperationValue)
                {
                    resultList.Add(new TaxCalculationResult { Tax = 0 });
                }
            }

            return new List<TaxCalculationResult>();
        }

        private static decimal CalculateAssetWeightedAverageValue(IEnumerable<FinancialOperation> financialOperations)
        {
            var operationCosts = financialOperations.Select(x => x.UnitCost).Distinct();
            decimal numerator = 0;
            decimal denominator = financialOperations.Count();

            foreach (var cost in operationCosts)
            {
                var operations = financialOperations.Where(x => x.UnitCost == cost).Count();
                numerator += operations * cost;
            }

            return numerator / denominator;
        }
    }
}
