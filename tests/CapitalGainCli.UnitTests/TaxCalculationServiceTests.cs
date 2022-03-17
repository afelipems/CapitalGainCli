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
}
