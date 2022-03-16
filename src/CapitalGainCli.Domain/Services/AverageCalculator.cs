using CapitalGainCli.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapitalGainCli.Domain.Services
{
    public static class AverageCalculator
    {
        public static decimal CalculateAssetWeightedAverageValue(IEnumerable<FinancialOperation> financialOperations)
        {
            var operationCosts = financialOperations.Select(x => x.UnitCost).Distinct();
            decimal numerator = 0;
            int denominator = financialOperations.Sum(x => x.Quantity);

            foreach (var cost in operationCosts)
            {
                var operations = financialOperations.Where(x => x.UnitCost == cost);
                var totalQuantity = operations.Sum(x => x.Quantity);
                numerator += totalQuantity * cost;
            }

            return Math.Round(numerator / denominator, 2);
        }
    }
}
