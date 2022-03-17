using CapitalGainCli.Domain.Entities;
using CapitalGainCli.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace CapitalGainCli
{
    public static class UserInputHandler
    {
        public const string ErrorMessage = "Invalid input format";

        public static List<string> ProcessTaxCalculationRequest(List<string> inputs)
        {
            List<string> resultList = new List<string>();

            foreach(var input in inputs)
            {
                try
                {
                    var castedOperation = JsonConvert.DeserializeObject<List<FinancialOperation>>(input);

                    var result = TaxCalculationService.CalculateTaxes(castedOperation);

                    resultList.Add(JsonConvert.SerializeObject(result));
                }
                catch (Exception)
                {
                    resultList.Add(ErrorMessage);
                }
            }

            return resultList;
        }
    }
}
