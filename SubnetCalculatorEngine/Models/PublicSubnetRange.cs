using SubnetCalculatorEngine.Models.Enums;

namespace SubnetCalculatorEngine.Models
{
    public class PublicSubnetRange
    {
        public IPClass IPClass { get; set; }
        public int NetMask { get; set; }

        public PublicSubnetRange(IPClass ipClass, int netMask)
        {
            IPClass = ipClass;
            NetMask = netMask;
        }
    }
}
