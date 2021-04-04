namespace SubnetCalculatorEngine.Models
{
    public class SubnetCalculatorInput
    {
        public string IPAddress { get; set; }
        public int NumberOfNetworks { get; set; }

        public SubnetCalculatorInput()
        {

        }

        public SubnetCalculatorInput(string ipAddress, int numberOfNetworks)
        {
            IPAddress = ipAddress;
            NumberOfNetworks = numberOfNetworks;
        }
    }
}
