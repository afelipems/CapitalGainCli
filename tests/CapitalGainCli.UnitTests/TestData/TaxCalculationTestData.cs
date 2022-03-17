using System;
using System.Collections.Generic;
using System.Text;

namespace CapitalGainCli.UnitTests.TestData
{
    public class TaxCalculationTestData
    {
        public static IEnumerable<object[]> Data()
        {
            return new List<object[]>
            {
                new object[]{ TaxCalculationTestScenarios.GetCaseOneInput(), TaxCalculationTestScenarios.GetCaseOneOutput() },

                new object[]{ TaxCalculationTestScenarios.GetCaseTwoInput(), TaxCalculationTestScenarios.GetCaseTwoOutput() },

                new object[]{ TaxCalculationTestScenarios.GetCaseThreeInput(), TaxCalculationTestScenarios.GetCaseThreeOutput() },

                new object[]{ TaxCalculationTestScenarios.GetCaseFourInput(), TaxCalculationTestScenarios.GetCaseFourOutput() },

                new object[]{ TaxCalculationTestScenarios.GetCaseFiveInput(), TaxCalculationTestScenarios.GetCaseFiveOutput() },

                new object[]{ TaxCalculationTestScenarios.GetCaseSixInput(), TaxCalculationTestScenarios.GetCaseSixOutput() },

                new object[]{ TaxCalculationTestScenarios.GetCaseSevenInput(), TaxCalculationTestScenarios.GetCaseSevenOutput() },
            };
        }
    }
}
