namespace SubnetCalculatorEngine.Models
{
    public class SubnetCalculatorResult
    {
        public int NumberOfExtraBitsRequired { get; set; }
        public string IPAddress { get; set; }
        public string IPAddressInBinary { get; set; }
        public int NetMask { get; set; }
        public string SubnetMaskInBinary { get; set; }
        public string SubnetMaskIPAddress { get; set; }
        public string NetworkAddressInBinary { get; set; }
        public string NetworkIPAddress { get; set; }
        public string BroadcastAddressInBinary { get; set; }
        public string BroadcastIPAddress { get; set; }
        public double TotalNumberOfHosts { get; set; }
        public double NumberOfUsableHosts { get; set; }
        public string NetworkSubnetMaskInBinary { get; set; }
        public string NetworkSubnetMaskIPAddress { get; set; }
        public string NetworkWithNetworkMaskAddressInBinary { get; set; }
        public string NetworkWithNetworkMaskIPAddress { get; set; }
        public string BroadcastWithNetworkMaskAddressInBinary { get; set; }
        public string BroadcastWithNetworkMaskIPAddress { get; set; }
        public double TotalNumberOfHostsWithNetworkMask { get; set; }
        public double NumberOfUsableHostsWithNetworkMask { get; set; }
        public string Network5IPAddressInBinary { get; set; }
        public string Network5IPAddress { get; set; }
        public string Network22IPAddressInBinary { get; set; }
        public string Network22IPAddress { get; set; }
    }
}
