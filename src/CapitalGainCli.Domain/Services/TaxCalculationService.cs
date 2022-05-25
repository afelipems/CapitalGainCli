using CapitalGainCli.Domain.Entities;
using CapitalGainCli.Domain.Enums;
using System;
using System.Collections.Generic;

namespace CapitalGainCli.Domain.Services
{
    public static class TaxCalculationService
    {
        private const decimal TaxCollectionMinimumThreshold = 20000;
        private const decimal TaxFeePercentage = 0.2m;

        public static IEnumerable<TaxCalculationResult> CalculateTaxes(IEnumerable<FinancialOperation> financialOperations)
        {
            var resultList = new List<TaxCalculationResult>();
            var buyHistory = new List<FinancialOperation>();
            decimal averageOperationValue = 0;
            decimal lossAmount = 0;

            foreach(var operation in financialOperations)
            {
                var hasProcessedAnyTaxExemptOperation = ProcessTaxExemptTransactionsIfRequired(operation, ref lossAmount, ref averageOperationValue, ref buyHistory, ref resultList);

                if (hasProcessedAnyTaxExemptOperation)
                {
                    continue;
                }

                decimal profit = (operation.Quantity * operation.UnitCost) - (operation.Quantity * averageOperationValue);
                decimal profitLessLoss = profit - lossAmount;

                switch (profitLessLoss)
                {
                    case <= 0:
                        AddZeroTaxResult(resultList);
                        lossAmount -= profit;
                        continue;
                    default:
                        AddTaxResult(resultList, profitLessLoss);
                        lossAmount = 0;
                        continue;
                }
            }

            return resultList;
        }      

        private static void AddZeroTaxResult(List<TaxCalculationResult> taxCalculationResults)
        {
            taxCalculationResults.Add(new TaxCalculationResult { Tax = Math.Round(0m, 2) });
        }

        private static void AddTaxResult(List<TaxCalculationResult> taxCalculationResults, decimal liquidProfit)
        {
            var taxValue = liquidProfit * TaxFeePercentage;
            taxCalculationResults.Add(new TaxCalculationResult { Tax = Math.Round(taxValue, 2) });
        }

        private static bool ProcessTaxExemptTransactionsIfRequired(FinancialOperation operation, ref decimal lossAmount, ref decimal averageOperationValue, ref List<FinancialOperation> buyHistory, ref List<TaxCalculationResult> resultList)
        {
            if (operation.Operation == OperationType.Buy)
            {
                buyHistory.Add(operation);
                averageOperationValue = AverageCalculator.CalculateAssetWeightedAverageValue(buyHistory);
                AddZeroTaxResult(resultList);
                return true;
            }

            if (operation.UnitCost < averageOperationValue)
            {
                AddZeroTaxResult(resultList);
                lossAmount += (operation.Quantity * averageOperationValue) - (operation.Quantity * operation.UnitCost);
                return true;
            }

            if ((operation.Quantity * operation.UnitCost) <= TaxCollectionMinimumThreshold)
            {
                AddZeroTaxResult(resultList);
                return true;
            }

            return false;
        }
    }
}
