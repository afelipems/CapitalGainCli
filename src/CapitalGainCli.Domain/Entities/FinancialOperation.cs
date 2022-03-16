using CapitalGainCli.Domain.Enums;
using Newtonsoft.Json;

namespace CapitalGainCli.Domain.Entities
{
    public class FinancialOperation
    {
        [JsonProperty("unit-cost")]
        public decimal UnitCost { get; set; }
        public OperationType Operation { get; set; }
        public int Quantity { get; set; }
    }
}
