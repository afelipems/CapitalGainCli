using CapitalGainCli.Domain.Entities;
using CapitalGainCli.Domain.Services;
using CapitalGainCli.UnitTests.TestData;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CapitalGainCli.UnitTests
{
    public class TaxCalculationServiceTests
    {
        [Theory]
        [MemberData(nameof(TaxCalculationTestData.Data), MemberType = typeof(TaxCalculationTestData))]
        public void CalculateTaxes_GivenSpecificScenarios_ShouldReturnAsExpected(IEnumerable<FinancialOperation> financialOperations, IEnumerable<TaxCalculationResult> expectedResult)
        {
            var result = TaxCalculationService.CalculateTaxes(financialOperations);

            result.Should().BeEquivalentTo(expectedResult);
        }
    }

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
