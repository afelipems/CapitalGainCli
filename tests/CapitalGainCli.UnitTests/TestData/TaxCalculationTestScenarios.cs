using CapitalGainCli.Domain.Entities;
using CapitalGainCli.Domain.Enums;
using System.Collections.Generic;

namespace CapitalGainCli.UnitTests.TestData
{
    public static class TaxCalculationTestScenarios
    {
        public static IEnumerable<FinancialOperation> GetCaseOneInput() => new List<FinancialOperation>
        {
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 10, Quantity = 100 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 15, Quantity = 50 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 15, Quantity = 50 },
        };

        public static IEnumerable<TaxCalculationResult> GetCaseOneOutput() => new List<TaxCalculationResult>
        {
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 }
        };

        public static IEnumerable<FinancialOperation> GetCaseTwoInput() => new List<FinancialOperation>
        {
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 10, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 20, Quantity = 5000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 5, Quantity = 5000 },
        };

        public static IEnumerable<TaxCalculationResult> GetCaseTwoOutput() => new List<TaxCalculationResult>
        {
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 10000.00m },
            new TaxCalculationResult { Tax = 0 }
        };

        public static IEnumerable<FinancialOperation> GetCaseThreeInput() => new List<FinancialOperation>
        {
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 10, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 5, Quantity = 5000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 20, Quantity = 3000 },
        };

        public static IEnumerable<TaxCalculationResult> GetCaseThreeOutput() => new List<TaxCalculationResult>
        {
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 1000 }
        };

        public static IEnumerable<FinancialOperation> GetCaseFourInput() => new List<FinancialOperation>
        {
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 10, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 25, Quantity = 5000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 15, Quantity = 10000 },
        };

        public static IEnumerable<TaxCalculationResult> GetCaseFourOutput() => new List<TaxCalculationResult>
        {
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 }
        };

        public static IEnumerable<FinancialOperation> GetCaseFiveInput() => new List<FinancialOperation>
        {
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 10, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 25, Quantity = 5000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 15, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 25, Quantity = 5000 }
        };

        public static IEnumerable<TaxCalculationResult> GetCaseFiveOutput() => new List<TaxCalculationResult>
        {
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 10000 }
        };

        public static IEnumerable<FinancialOperation> GetCaseSixInput() => new List<FinancialOperation>
        {
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 10, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 2, Quantity = 5000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 25, Quantity = 1000 }
        };

        public static IEnumerable<TaxCalculationResult> GetCaseSixOutput() => new List<TaxCalculationResult>
        {
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 3000 }
        };

        public static IEnumerable<FinancialOperation> GetCaseSevenInput() => new List<FinancialOperation>
        {
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 10, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 2, Quantity = 5000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 20, Quantity = 2000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 25, Quantity = 1000 },
            new FinancialOperation { Operation = OperationType.Buy, UnitCost = 20, Quantity = 10000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 5, Quantity = 5000 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 30, Quantity = 4350 },
            new FinancialOperation { Operation = OperationType.Sell, UnitCost = 30, Quantity = 650 },
        };

        public static IEnumerable<TaxCalculationResult> GetCaseSevenOutput() => new List<TaxCalculationResult>
        {
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 3000 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 0 },
            new TaxCalculationResult { Tax = 3050 },
            new TaxCalculationResult { Tax = 0 },
        };
    }
}
