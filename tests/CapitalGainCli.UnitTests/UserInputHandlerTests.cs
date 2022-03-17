using CapitalGainCli.UnitTests.TestData;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CapitalGainCli.UnitTests
{
    public class UserInputHandlerTests
    {
        private const string GenericString = "xpto";

        [Fact]
        public void ProcessTaxCalculationRequest_GivenInvalidInput_ShouldHandleErrorAndReturnErrorMessage()
        {
            var result = UserInputHandler.ProcessTaxCalculationRequest(new List<string> { GenericString });

            result.Should().BeEquivalentTo(new List<string> { UserInputHandler.ErrorMessage });
        }

        [Fact]
        public void ProcessTaxCalculationRequest_GivenIndependentInputs_ShouldReturnIndependentOutputs()
        {
            var firstInput = JsonConvert.SerializeObject( TaxCalculationTestScenarios.GetCaseOneInput());

            var secondInput = JsonConvert.SerializeObject(TaxCalculationTestScenarios.GetCaseTwoInput());

            var firstInputExpectedResult = JsonConvert.SerializeObject(TaxCalculationTestScenarios.GetCaseOneOutput());

            var secondInputExpectedResult = JsonConvert.SerializeObject(TaxCalculationTestScenarios.GetCaseTwoOutput());

            var result = UserInputHandler.ProcessTaxCalculationRequest(new List<string> { firstInput, secondInput });

            var expectedResult = new List<string> { firstInputExpectedResult, secondInputExpectedResult };

            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
