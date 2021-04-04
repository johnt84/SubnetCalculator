using SubnetCalculatorEngine.Models.Enums;

namespace SubnetCalculatorEngine.Models
{
    public class IPInformation
    {
        public IPType IPType { get; set; }
        public IPClass? IPClass { get; set; }

        public IPInformation(IPType ipType, IPClass? ipClass)
        {
            IPType = ipType;
            IPClass = ipClass;
        }
    }
}
