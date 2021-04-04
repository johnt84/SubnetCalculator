using SubnetCalculatorEngine.Models.Enums;

namespace SubnetCalculatorEngine.Models
{
    public class PrivateIPRange
    {
        public IPClass IPClass { get; set; }
        public string IPRange { get; set; }

        public PrivateIPRange(IPClass ipClass, string ipRange)
        {
            IPClass = ipClass;
            IPRange = ipRange;
        }
    }
}
