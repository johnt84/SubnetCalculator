using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubnetCalculatorEngine.Models;
using SubnetCalculatorEngine.Models.Enums;

namespace SubnetCalculator.UnitTests
{
    [TestClass]
    public class SubnetCalculatorTests
    {
        //Tests scenarios are taken from the Network Layer Addressing and
        //Subnetting Plualsght course at https://app.pluralsight.com/course-player?clipId=57524c33-f76e-45ad-b8c4-2d9d3a1ffded

        [TestMethod]
        public void SubnetIPv4Test1()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput()
            {
                IPAddress = "10.0.50.0/24",
                NumberOfNetworks = 11,
            };

            var subnetCalculator = new SubnetCalculatorEngine.Services.SubnetCalculatorEngine();

            var subnetCalculatorResult = subnetCalculator.CalculateSubnet(subnetCalculatorInput);

            Assert.IsTrue(subnetCalculatorResult.NumberOfExtraBitsRequired == 4);
            Assert.IsTrue(subnetCalculatorResult.NumberOfNetworksProvided == 16);

            Assert.IsTrue(subnetCalculatorResult.IPAddress == "10.0.50.0");
            Assert.IsTrue(subnetCalculatorResult.IPAddressInBinary == "00001010.00000000.00110010.00000000");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskIPAddress == "255.255.255.0/24");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskInBinary == "11111111.11111111.11111111.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkIPAddress == "10.0.50.0/24");
            Assert.IsTrue(subnetCalculatorResult.NetworkAddressInBinary == "00001010.00000000.00110010.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastIPAddress == "10.0.50.255/24");
            Assert.IsTrue(subnetCalculatorResult.BroadcastAddressInBinary == "00001010.00000000.00110010.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableIPAddress == "10.0.50.1/24");
            Assert.IsTrue(subnetCalculatorResult.LastUsableIPAddress == "10.0.50.254/24");
            Assert.IsTrue(subnetCalculatorResult.TotalNumberOfHosts == 256);
            Assert.IsTrue(subnetCalculatorResult.NumberOfUsableHosts == 254);
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaHostName == "50.0.10.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaIPAddresss == "0.50.0.10.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.IPType == IPType.Private);
            Assert.IsTrue(subnetCalculatorResult.IPClass == IPClass.A);

            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskIPAddress == "255.255.255.240/28");
            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskInBinary == "11111111.11111111.11111111.11110000");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskIPAddress == "10.0.50.0/28");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary == "00001010.00000000.00110010.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress == "10.0.50.255/28");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary == "00001010.00000000.00110010.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableWithNetworkMaskIPAddress == "10.0.50.1/28");
            Assert.IsTrue(subnetCalculatorResult.LastUsableWithNetworkMaskIPAddress == "10.0.50.254/28");

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == 16);

            var networks = subnetCalculatorResult.Networks.ToArray();

            var network0 = networks[0];

            Assert.IsTrue(network0.NetworkAddress == "10.0.50.0/28");
            Assert.IsTrue(network0.BroadcastAddress == "10.0.50.15/28");
            Assert.IsTrue(network0.FirstUsableIPAddress == "10.0.50.1/28");
            Assert.IsTrue(network0.LastUsableIPAddress == "10.0.50.14/28");

            var network3 = networks[3];

            Assert.IsTrue(network3.NetworkAddress == "10.0.50.48/28");
            Assert.IsTrue(network3.BroadcastAddress == "10.0.50.63/28");
            Assert.IsTrue(network3.FirstUsableIPAddress == "10.0.50.49/28");
            Assert.IsTrue(network3.LastUsableIPAddress == "10.0.50.62/28");

            var network10 = networks[10];

            Assert.IsTrue(network10.NetworkAddress == "10.0.50.160/28");
            Assert.IsTrue(network10.BroadcastAddress == "10.0.50.175/28");
            Assert.IsTrue(network10.FirstUsableIPAddress == "10.0.50.161/28");
            Assert.IsTrue(network10.LastUsableIPAddress == "10.0.50.174/28");

            var network15 = networks[15];

            Assert.IsTrue(network15.NetworkAddress == "10.0.50.240/28");
            Assert.IsTrue(network15.BroadcastAddress == "10.0.50.255/28");
            Assert.IsTrue(network15.FirstUsableIPAddress == "10.0.50.241/28");
            Assert.IsTrue(network15.LastUsableIPAddress == "10.0.50.254/28");
        }

        [TestMethod]
        public void SubnetIPv4Test2()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput()
            {
                IPAddress = "10.0.0.0/16",
                NumberOfNetworks = 500,
            };

            var subnetCalculator = new SubnetCalculatorEngine.Services.SubnetCalculatorEngine();

            var subnetCalculatorResult = subnetCalculator.CalculateSubnet(subnetCalculatorInput);

            Assert.IsTrue(subnetCalculatorResult.NumberOfExtraBitsRequired == 9);
            Assert.IsTrue(subnetCalculatorResult.NumberOfNetworksProvided == 512);

            Assert.IsTrue(subnetCalculatorResult.IPAddress == "10.0.0.0");
            Assert.IsTrue(subnetCalculatorResult.IPAddressInBinary == "00001010.00000000.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskIPAddress == "255.255.0.0/16");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskInBinary == "11111111.11111111.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkIPAddress == "10.0.0.0/16");
            Assert.IsTrue(subnetCalculatorResult.NetworkAddressInBinary == "00001010.00000000.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastIPAddress == "10.0.255.255/16");
            Assert.IsTrue(subnetCalculatorResult.BroadcastAddressInBinary == "00001010.00000000.11111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableIPAddress == "10.0.0.1/16");
            Assert.IsTrue(subnetCalculatorResult.LastUsableIPAddress == "10.0.255.254/16");
            Assert.IsTrue(subnetCalculatorResult.TotalNumberOfHosts == 65536);
            Assert.IsTrue(subnetCalculatorResult.NumberOfUsableHosts == 65534);
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaHostName == "0.0.10.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaIPAddresss == "0.0.0.10.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.IPType == IPType.Private);
            Assert.IsTrue(subnetCalculatorResult.IPClass == IPClass.A);

            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskIPAddress == "255.255.255.128/25");
            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskInBinary == "11111111.11111111.11111111.10000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskIPAddress == "10.0.0.0/25");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary == "00001010.00000000.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress == "10.0.255.255/25");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary == "00001010.00000000.11111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableWithNetworkMaskIPAddress == "10.0.0.1/25");
            Assert.IsTrue(subnetCalculatorResult.LastUsableWithNetworkMaskIPAddress == "10.0.255.254/25");

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == 512);

            var networks = subnetCalculatorResult.Networks.ToArray();

            var network10 = networks[10];

            Assert.IsTrue(network10.NetworkAddress == "10.0.5.0/25");
            Assert.IsTrue(network10.BroadcastAddress == "10.0.5.127/25");
            Assert.IsTrue(network10.FirstUsableIPAddress == "10.0.5.1/25");
            Assert.IsTrue(network10.LastUsableIPAddress == "10.0.5.126/25");

            var network151 = networks[151];

            Assert.IsTrue(network151.NetworkAddress == "10.0.75.128/25");
            Assert.IsTrue(network151.BroadcastAddress == "10.0.75.255/25");
            Assert.IsTrue(network151.FirstUsableIPAddress == "10.0.75.129/25");
            Assert.IsTrue(network151.LastUsableIPAddress == "10.0.75.254/25");

            var network300 = networks[300];

            Assert.IsTrue(network300.NetworkAddress == "10.0.150.0/25");
            Assert.IsTrue(network300.BroadcastAddress == "10.0.150.127/25");
            Assert.IsTrue(network300.FirstUsableIPAddress == "10.0.150.1/25");
            Assert.IsTrue(network300.LastUsableIPAddress == "10.0.150.126/25");

            var network401 = networks[401];

            Assert.IsTrue(network401.NetworkAddress == "10.0.200.128/25");
            Assert.IsTrue(network401.BroadcastAddress == "10.0.200.255/25");
            Assert.IsTrue(network401.FirstUsableIPAddress == "10.0.200.129/25");
            Assert.IsTrue(network401.LastUsableIPAddress == "10.0.200.254/25");
        }

        [TestMethod]
        public void SubnetIPv4Test3()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput()
            {
                IPAddress = "10.200.0.0/13",
                NumberOfNetworks = 200,
            };

            var subnetCalculator = new SubnetCalculatorEngine.Services.SubnetCalculatorEngine();

            var subnetCalculatorResult = subnetCalculator.CalculateSubnet(subnetCalculatorInput);

            Assert.IsTrue(subnetCalculatorResult.NumberOfExtraBitsRequired == 8);
            Assert.IsTrue(subnetCalculatorResult.NumberOfNetworksProvided == 256);

            Assert.IsTrue(subnetCalculatorResult.IPAddress == "10.200.0.0");
            Assert.IsTrue(subnetCalculatorResult.IPAddressInBinary == "00001010.11001000.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskIPAddress == "255.248.0.0/13");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskInBinary == "11111111.11111000.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkIPAddress == "10.200.0.0/13");
            Assert.IsTrue(subnetCalculatorResult.NetworkAddressInBinary == "00001010.11001000.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastIPAddress == "10.207.255.255/13");
            Assert.IsTrue(subnetCalculatorResult.BroadcastAddressInBinary == "00001010.11001111.11111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableIPAddress == "10.200.0.1/13");
            Assert.IsTrue(subnetCalculatorResult.LastUsableIPAddress == "10.207.255.254/13");
            Assert.IsTrue(subnetCalculatorResult.TotalNumberOfHosts == 524288);
            Assert.IsTrue(subnetCalculatorResult.NumberOfUsableHosts == 524286);
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaHostName == "0.200.10.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaIPAddresss == "0.0.200.10.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.IPType == IPType.Private);
            Assert.IsTrue(subnetCalculatorResult.IPClass == IPClass.A);

            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskIPAddress == "255.255.248.0/21");
            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskInBinary == "11111111.11111111.11111000.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskIPAddress == "10.200.0.0/21");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary == "00001010.11001000.00000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress == "10.207.255.255/21");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary == "00001010.11001111.11111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableWithNetworkMaskIPAddress == "10.200.0.1/21");
            Assert.IsTrue(subnetCalculatorResult.LastUsableWithNetworkMaskIPAddress == "10.207.255.254/21");

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == 256);

            var networks = subnetCalculatorResult.Networks.ToArray();

            var network20 = networks[20];

            Assert.IsTrue(network20.NetworkAddress == "10.200.160.0/21");
            Assert.IsTrue(network20.BroadcastAddress == "10.200.167.255/21");
            Assert.IsTrue(network20.FirstUsableIPAddress == "10.200.160.1/21");
            Assert.IsTrue(network20.LastUsableIPAddress == "10.200.167.254/21");

            var network31 = networks[31];

            Assert.IsTrue(network31.NetworkAddress == "10.200.248.0/21");
            Assert.IsTrue(network31.BroadcastAddress == "10.200.255.255/21");
            Assert.IsTrue(network31.FirstUsableIPAddress == "10.200.248.1/21");
            Assert.IsTrue(network31.LastUsableIPAddress == "10.200.255.254/21");

            var network48 = networks[48];

            Assert.IsTrue(network48.NetworkAddress == "10.201.128.0/21");
            Assert.IsTrue(network48.BroadcastAddress == "10.201.135.255/21");
            Assert.IsTrue(network48.FirstUsableIPAddress == "10.201.128.1/21");
            Assert.IsTrue(network48.LastUsableIPAddress == "10.201.135.254/21");

            var network199 = networks[199];

            Assert.IsTrue(network199.NetworkAddress == "10.206.56.0/21");
            Assert.IsTrue(network199.BroadcastAddress == "10.206.63.255/21");
            Assert.IsTrue(network199.FirstUsableIPAddress == "10.206.56.1/21");
            Assert.IsTrue(network199.LastUsableIPAddress == "10.206.63.254/21");
        }
    }
}
