namespace SubnetCalculatorEngine.Models
{
    public class Network
    {
        public int NetworkNumber { get; set; }
        public string NetworkAddress { get; set; }
        public string BroadcastAddress { get; set; }
        public string FirstUsableIPAddress { get; set; }
        public string LastUsableIPAddress { get; set; }
    }
}
