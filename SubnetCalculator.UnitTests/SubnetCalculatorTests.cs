using Microsoft.VisualStudio.TestTools.UnitTesting;
using SubnetCalculatorEngine.Models;
using SubnetCalculatorEngine.Models.Enums;

namespace SubnetCalculator.UnitTests
{
    [TestClass]
    public class SubnetCalculatorTests
    {
        //Tests scenarios are taken from the Network Layer Addressing and
        //Subnetting Pluralsight course at https://app.pluralsight.com/course-player?clipId=57524c33-f76e-45ad-b8c4-2d9d3a1ffded

        [TestMethod]
        public void SubnetIPv4Test1()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput("10.0.50.0/24", 11);

            var subnetCalculatorResult = GetSubnetCalculatorResult(subnetCalculatorInput);

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

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == subnetCalculatorResult.NumberOfNetworksProvided);

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
            var subnetCalculatorInput = new SubnetCalculatorInput("10.0.0.0/16", 500);

            var subnetCalculatorResult = GetSubnetCalculatorResult(subnetCalculatorInput);

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

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == subnetCalculatorResult.NumberOfNetworksProvided);

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
            var subnetCalculatorInput = new SubnetCalculatorInput("10.200.0.0/13", 200);

            var subnetCalculatorResult = GetSubnetCalculatorResult(subnetCalculatorInput);

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

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == subnetCalculatorResult.NumberOfNetworksProvided);

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

        [TestMethod]
        public void SubnetIPv4Test4()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput("192.168.224.0/21", 50);

            var subnetCalculatorResult = GetSubnetCalculatorResult(subnetCalculatorInput);

            Assert.IsTrue(subnetCalculatorResult.NumberOfExtraBitsRequired == 6);
            Assert.IsTrue(subnetCalculatorResult.NumberOfNetworksProvided == 64);

            Assert.IsTrue(subnetCalculatorResult.IPAddress == "192.168.224.0");
            Assert.IsTrue(subnetCalculatorResult.IPAddressInBinary == "11000000.10101000.11100000.00000000");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskIPAddress == "255.255.248.0/21");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskInBinary == "11111111.11111111.11111000.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkIPAddress == "192.168.224.0/21");
            Assert.IsTrue(subnetCalculatorResult.NetworkAddressInBinary == "11000000.10101000.11100000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastIPAddress == "192.168.231.255/21");
            Assert.IsTrue(subnetCalculatorResult.BroadcastAddressInBinary == "11000000.10101000.11100111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableIPAddress == "192.168.224.1/21");
            Assert.IsTrue(subnetCalculatorResult.LastUsableIPAddress == "192.168.231.254/21");
            Assert.IsTrue(subnetCalculatorResult.TotalNumberOfHosts == 2048);
            Assert.IsTrue(subnetCalculatorResult.NumberOfUsableHosts == 2046);
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaHostName == "224.168.192.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaIPAddresss == "0.224.168.192.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.IPType == IPType.Private);
            Assert.IsTrue(subnetCalculatorResult.IPClass == IPClass.C);

            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskIPAddress == "255.255.255.224/27");
            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskInBinary == "11111111.11111111.11111111.11100000");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskIPAddress == "192.168.224.0/27");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary == "11000000.10101000.11100000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress == "192.168.231.255/27");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary == "11000000.10101000.11100111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableWithNetworkMaskIPAddress == "192.168.224.1/27");
            Assert.IsTrue(subnetCalculatorResult.LastUsableWithNetworkMaskIPAddress == "192.168.231.254/27");

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == subnetCalculatorResult.NumberOfNetworksProvided);

            var networks = subnetCalculatorResult.Networks.ToArray();

            var network23 = networks[23];

            Assert.IsTrue(network23.NetworkAddress == "192.168.226.224/27");
            Assert.IsTrue(network23.BroadcastAddress == "192.168.226.255/27");
            Assert.IsTrue(network23.FirstUsableIPAddress == "192.168.226.225/27");
            Assert.IsTrue(network23.LastUsableIPAddress == "192.168.226.254/27");

            var network32 = networks[32];

            Assert.IsTrue(network32.NetworkAddress == "192.168.228.0/27");
            Assert.IsTrue(network32.BroadcastAddress == "192.168.228.31/27");
            Assert.IsTrue(network32.FirstUsableIPAddress == "192.168.228.1/27");
            Assert.IsTrue(network32.LastUsableIPAddress == "192.168.228.30/27");

            var network41 = networks[41];

            Assert.IsTrue(network41.NetworkAddress == "192.168.229.32/27");
            Assert.IsTrue(network41.BroadcastAddress == "192.168.229.63/27");
            Assert.IsTrue(network41.FirstUsableIPAddress == "192.168.229.33/27");
            Assert.IsTrue(network41.LastUsableIPAddress == "192.168.229.62/27");

            var network58 = networks[58];

            Assert.IsTrue(network58.NetworkAddress == "192.168.231.64/27");
            Assert.IsTrue(network58.BroadcastAddress == "192.168.231.95/27");
            Assert.IsTrue(network58.FirstUsableIPAddress == "192.168.231.65/27");
            Assert.IsTrue(network58.LastUsableIPAddress == "192.168.231.94/27");
        }

        [TestMethod]
        public void SubnetIPv4Test5()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput("172.16.128.0/17", 30);

            var subnetCalculatorResult = GetSubnetCalculatorResult(subnetCalculatorInput);

            Assert.IsTrue(subnetCalculatorResult.NumberOfExtraBitsRequired == 5);
            Assert.IsTrue(subnetCalculatorResult.NumberOfNetworksProvided == 32);

            Assert.IsTrue(subnetCalculatorResult.IPAddress == "172.16.128.0");
            Assert.IsTrue(subnetCalculatorResult.IPAddressInBinary == "10101100.00010000.10000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskIPAddress == "255.255.128.0/17");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskInBinary == "11111111.11111111.10000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkIPAddress == "172.16.128.0/17");
            Assert.IsTrue(subnetCalculatorResult.NetworkAddressInBinary == "10101100.00010000.10000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastIPAddress == "172.16.255.255/17");
            Assert.IsTrue(subnetCalculatorResult.BroadcastAddressInBinary == "10101100.00010000.11111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableIPAddress == "172.16.128.1/17");
            Assert.IsTrue(subnetCalculatorResult.LastUsableIPAddress == "172.16.255.254/17");
            Assert.IsTrue(subnetCalculatorResult.TotalNumberOfHosts == 32768);
            Assert.IsTrue(subnetCalculatorResult.NumberOfUsableHosts == 32766);
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaHostName == "128.16.172.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaIPAddresss == "0.128.16.172.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.IPType == IPType.Private);
            Assert.IsTrue(subnetCalculatorResult.IPClass == IPClass.B);

            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskIPAddress == "255.255.252.0/22");
            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskInBinary == "11111111.11111111.11111100.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskIPAddress == "172.16.128.0/22");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary == "10101100.00010000.10000000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress == "172.16.255.255/22");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary == "10101100.00010000.11111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableWithNetworkMaskIPAddress == "172.16.128.1/22");
            Assert.IsTrue(subnetCalculatorResult.LastUsableWithNetworkMaskIPAddress == "172.16.255.254/22");

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == subnetCalculatorResult.NumberOfNetworksProvided);

            var networks = subnetCalculatorResult.Networks.ToArray();

            var network7 = networks[7];

            Assert.IsTrue(network7.NetworkAddress == "172.16.156.0/22");
            Assert.IsTrue(network7.BroadcastAddress == "172.16.159.255/22");
            Assert.IsTrue(network7.FirstUsableIPAddress == "172.16.156.1/22");
            Assert.IsTrue(network7.LastUsableIPAddress == "172.16.159.254/22");

            var network16 = networks[16];

            Assert.IsTrue(network16.NetworkAddress == "172.16.192.0/22");
            Assert.IsTrue(network16.BroadcastAddress == "172.16.195.255/22");
            Assert.IsTrue(network16.FirstUsableIPAddress == "172.16.192.1/22");
            Assert.IsTrue(network16.LastUsableIPAddress == "172.16.195.254/22");

            var network25 = networks[25];

            Assert.IsTrue(network25.NetworkAddress == "172.16.228.0/22");
            Assert.IsTrue(network25.BroadcastAddress == "172.16.231.255/22");
            Assert.IsTrue(network25.FirstUsableIPAddress == "172.16.228.1/22");
            Assert.IsTrue(network25.LastUsableIPAddress == "172.16.231.254/22");
        }

        [TestMethod]
        public void SubnetIPv4Test6()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput("172.17.20.0/22", 17);

            var subnetCalculatorResult = GetSubnetCalculatorResult(subnetCalculatorInput);

            Assert.IsTrue(subnetCalculatorResult.NumberOfExtraBitsRequired == 5);
            Assert.IsTrue(subnetCalculatorResult.NumberOfNetworksProvided == 32);

            Assert.IsTrue(subnetCalculatorResult.IPAddress == "172.17.20.0");
            Assert.IsTrue(subnetCalculatorResult.IPAddressInBinary == "10101100.00010001.00010100.00000000");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskIPAddress == "255.255.252.0/22");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskInBinary == "11111111.11111111.11111100.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkIPAddress == "172.17.20.0/22");
            Assert.IsTrue(subnetCalculatorResult.NetworkAddressInBinary == "10101100.00010001.00010100.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastIPAddress == "172.17.23.255/22");
            Assert.IsTrue(subnetCalculatorResult.BroadcastAddressInBinary == "10101100.00010001.00010111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableIPAddress == "172.17.20.1/22");
            Assert.IsTrue(subnetCalculatorResult.LastUsableIPAddress == "172.17.23.254/22");
            Assert.IsTrue(subnetCalculatorResult.TotalNumberOfHosts == 1024);
            Assert.IsTrue(subnetCalculatorResult.NumberOfUsableHosts == 1022);
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaHostName == "20.17.172.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaIPAddresss == "0.20.17.172.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.IPType == IPType.Private);
            Assert.IsTrue(subnetCalculatorResult.IPClass == IPClass.B);

            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskIPAddress == "255.255.255.224/27");
            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskInBinary == "11111111.11111111.11111111.11100000");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskIPAddress == "172.17.20.0/27");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary == "10101100.00010001.00010100.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress == "172.17.23.255/27");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary == "10101100.00010001.00010111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableWithNetworkMaskIPAddress == "172.17.20.1/27");
            Assert.IsTrue(subnetCalculatorResult.LastUsableWithNetworkMaskIPAddress == "172.17.23.254/27");

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == subnetCalculatorResult.NumberOfNetworksProvided);

            var networks = subnetCalculatorResult.Networks.ToArray();

            var network2 = networks[2];

            Assert.IsTrue(network2.NetworkAddress == "172.17.20.64/27");
            Assert.IsTrue(network2.BroadcastAddress == "172.17.20.95/27");
            Assert.IsTrue(network2.FirstUsableIPAddress == "172.17.20.65/27");
            Assert.IsTrue(network2.LastUsableIPAddress == "172.17.20.94/27");

            var network5 = networks[5];

            Assert.IsTrue(network5.NetworkAddress == "172.17.20.160/27");
            Assert.IsTrue(network5.BroadcastAddress == "172.17.20.191/27");
            Assert.IsTrue(network5.FirstUsableIPAddress == "172.17.20.161/27");
            Assert.IsTrue(network5.LastUsableIPAddress == "172.17.20.190/27");

            var network7 = networks[7];

            Assert.IsTrue(network7.NetworkAddress == "172.17.20.224/27");
            Assert.IsTrue(network7.BroadcastAddress == "172.17.20.255/27");
            Assert.IsTrue(network7.FirstUsableIPAddress == "172.17.20.225/27");
            Assert.IsTrue(network7.LastUsableIPAddress == "172.17.20.254/27");

            var network15 = networks[15];

            Assert.IsTrue(network15.NetworkAddress == "172.17.21.224/27");
            Assert.IsTrue(network15.BroadcastAddress == "172.17.21.255/27");
            Assert.IsTrue(network15.FirstUsableIPAddress == "172.17.21.225/27");
            Assert.IsTrue(network15.LastUsableIPAddress == "172.17.21.254/27");

            var network20 = networks[20];

            Assert.IsTrue(network20.NetworkAddress == "172.17.22.128/27");
            Assert.IsTrue(network20.BroadcastAddress == "172.17.22.159/27");
            Assert.IsTrue(network20.FirstUsableIPAddress == "172.17.22.129/27");
            Assert.IsTrue(network20.LastUsableIPAddress == "172.17.22.158/27");
        }

        [TestMethod]
        public void SubnetIPv4Test7()
        {
            var subnetCalculatorInput = new SubnetCalculatorInput("172.31.96.0/19", 300);

            var subnetCalculatorResult = GetSubnetCalculatorResult(subnetCalculatorInput);

            Assert.IsTrue(subnetCalculatorResult.NumberOfExtraBitsRequired == 9);
            Assert.IsTrue(subnetCalculatorResult.NumberOfNetworksProvided == 512);

            Assert.IsTrue(subnetCalculatorResult.IPAddress == "172.31.96.0");
            Assert.IsTrue(subnetCalculatorResult.IPAddressInBinary == "10101100.00011111.01100000.00000000");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskIPAddress == "255.255.224.0/19");
            Assert.IsTrue(subnetCalculatorResult.SubnetMaskInBinary == "11111111.11111111.11100000.00000000");
            Assert.IsTrue(subnetCalculatorResult.NetworkIPAddress == "172.31.96.0/19");
            Assert.IsTrue(subnetCalculatorResult.NetworkAddressInBinary == "10101100.00011111.01100000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastIPAddress == "172.31.127.255/19");
            Assert.IsTrue(subnetCalculatorResult.BroadcastAddressInBinary == "10101100.00011111.01111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableIPAddress == "172.31.96.1/19");
            Assert.IsTrue(subnetCalculatorResult.LastUsableIPAddress == "172.31.127.254/19");
            Assert.IsTrue(subnetCalculatorResult.TotalNumberOfHosts == 8192);
            Assert.IsTrue(subnetCalculatorResult.NumberOfUsableHosts == 8190);
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaHostName == "96.31.172.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.ReverseArpaIPAddresss == "0.96.31.172.in-addr.arpa");
            Assert.IsTrue(subnetCalculatorResult.IPType == IPType.Private);
            Assert.IsTrue(subnetCalculatorResult.IPClass == IPClass.B);

            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskIPAddress == "255.255.255.240/28");
            Assert.IsTrue(subnetCalculatorResult.NetworkSubnetMaskInBinary == "11111111.11111111.11111111.11110000");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskIPAddress == "172.31.96.0/28");
            Assert.IsTrue(subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary == "10101100.00011111.01100000.00000000");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress == "172.31.127.255/28");
            Assert.IsTrue(subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary == "10101100.00011111.01111111.11111111");
            Assert.IsTrue(subnetCalculatorResult.FirstUsableWithNetworkMaskIPAddress == "172.31.96.1/28");
            Assert.IsTrue(subnetCalculatorResult.LastUsableWithNetworkMaskIPAddress == "172.31.127.254/28");

            Assert.IsTrue(subnetCalculatorResult.Networks.Count == subnetCalculatorResult.NumberOfNetworksProvided);

            var networks = subnetCalculatorResult.Networks.ToArray();

            var network55 = networks[55];

            Assert.IsTrue(network55.NetworkAddress == "172.31.99.112/28");
            Assert.IsTrue(network55.BroadcastAddress == "172.31.99.127/28");
            Assert.IsTrue(network55.FirstUsableIPAddress == "172.31.99.113/28");
            Assert.IsTrue(network55.LastUsableIPAddress == "172.31.99.126/28");

            var network72 = networks[72];

            Assert.IsTrue(network72.NetworkAddress == "172.31.100.128/28");
            Assert.IsTrue(network72.BroadcastAddress == "172.31.100.143/28");
            Assert.IsTrue(network72.FirstUsableIPAddress == "172.31.100.129/28");
            Assert.IsTrue(network72.LastUsableIPAddress == "172.31.100.142/28");

            var network128 = networks[128];

            Assert.IsTrue(network128.NetworkAddress == "172.31.104.0/28");
            Assert.IsTrue(network128.BroadcastAddress == "172.31.104.15/28");
            Assert.IsTrue(network128.FirstUsableIPAddress == "172.31.104.1/28");
            Assert.IsTrue(network128.LastUsableIPAddress == "172.31.104.14/28");

            var network145 = networks[145];

            Assert.IsTrue(network145.NetworkAddress == "172.31.105.16/28");
            Assert.IsTrue(network145.BroadcastAddress == "172.31.105.31/28");
            Assert.IsTrue(network145.FirstUsableIPAddress == "172.31.105.17/28");
            Assert.IsTrue(network145.LastUsableIPAddress == "172.31.105.30/28");
        }

        private SubnetCalculatorResult GetSubnetCalculatorResult(SubnetCalculatorInput subnetCalculatorInput)
        {
            var subnetCalculator = new SubnetCalculatorEngine.Services.SubnetCalculatorEngine();

            return subnetCalculator.CalculateSubnet(subnetCalculatorInput);
        }
    }
}