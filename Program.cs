using System;
using System.Collections.Generic;

namespace CapitalGainCli
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                ProcessUserOperation();
            }
        }

        private static void ProcessUserOperation()
        {
            var operationsInput = new List<string>();

            while (true)
            {
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                var splittedInput = input.Split("\n");

                operationsInput.AddRange(splittedInput);
            }

            var results = UserInputHandler.ProcessTaxCalculationRequest(operationsInput);

            foreach(var result in results)
            {
                Console.WriteLine(result);
            }
        }
    }
}
