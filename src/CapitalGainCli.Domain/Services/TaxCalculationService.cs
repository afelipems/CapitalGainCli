using CapitalGainCli.Domain.Entities;
using CapitalGainCli.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CapitalGainCli.Domain.Services
{
    public static class TaxCalculationService
    {
        private const decimal TaxCollectionMinimumThreshold = 20000;
        private const decimal TaxFeePercentage = 0.2m;

        public static List<TaxCalculationResult> CalculateTaxes(List<FinancialOperation> financialOperations)
        {
            var resultList = new List<TaxCalculationResult>();
            decimal averageOperationValue = CalculateAssetWeightedAverageValue(financialOperations.Where(x => x.Operation == OperationType.Buy));
            decimal lossAmount = 0;

            foreach(var operation in financialOperations)
            {
                if(operation.Operation == OperationType.Buy)
                {
                    AddZeroTaxResult(resultList);
                    continue;
                }

                if(operation.UnitCost < averageOperationValue)
                {
                    AddZeroTaxResult(resultList);
                    lossAmount += (operation.Quantity * averageOperationValue) - (operation.Quantity * operation.UnitCost);
                    continue;
                }

                if((operation.Quantity * operation.UnitCost) <= TaxCollectionMinimumThreshold)
                {
                    AddZeroTaxResult(resultList);
                    continue;
                }

                decimal profit = (operation.Quantity * operation.UnitCost) - (operation.Quantity * averageOperationValue);
                decimal profitLessLoss = profit - lossAmount;

                if(profitLessLoss <= 0)
                {
                    AddZeroTaxResult(resultList);
                    lossAmount -= profit;
                    continue;
                }
                else
                {
                    AddTaxResult(resultList, profitLessLoss);
                    lossAmount = 0;
                    continue;
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

        private static void AddZeroTaxResult(List<TaxCalculationResult> taxCalculationResults)
        {
            taxCalculationResults.Add(new TaxCalculationResult { Tax = 0 });
        }

        private static void AddTaxResult(List<TaxCalculationResult> taxCalculationResults, decimal liquidProfit)
        {
            var taxValue = liquidProfit * TaxFeePercentage;
            taxCalculationResults.Add(new TaxCalculationResult { Tax = taxValue });
        }
    }
}
