using AutoFixture;
using CapitalGainCli.Domain.Entities;
using CapitalGainCli.Domain.Enums;
using CapitalGainCli.Domain.Services;
using CapitalGainCli.UnitTests.TestData;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CapitalGainCli.UnitTests
{
    public class AverageCalculatorTests
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void CalculateAssetWeightedAverageValue_GivenSpecificScenario_ShouldRoundResultAsExpected()
        {
            var tenStocksAtTwenty = _fixture.Build<FinancialOperation>()
                .With(x => x.Operation, OperationType.Buy)
                .With(x => x.UnitCost, 20)
                .With(x => x.Quantity, 10)
                .Create();

            var fiveStocksAtTen = _fixture.Build<FinancialOperation>()
                .With(x => x.Operation, OperationType.Buy)
                .With(x => x.UnitCost, 10)
                .With(x => x.Quantity, 5)
                .Create();

            var testMass = new List<FinancialOperation> { tenStocksAtTwenty, fiveStocksAtTen };

            var result = AverageCalculator.CalculateAssetWeightedAverageValue(testMass);

            result.Should().Be(16.67m);
        }        
    }
}
