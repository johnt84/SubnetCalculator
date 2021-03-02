using SubnetCalculatorEngine.Models;
using System;

namespace SubnetCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //var subnetCalculatorInput = new SubnetCalculatorInput()
            //{
            //    IPAddress = "100.130.0.30/24",
            //    NumberOfNetworks = 30,
            //};

            //var subnetCalculatorInput = new SubnetCalculatorInput()
            //{
            //    IPAddress = "172.31.96.0/19",
            //    NumberOfNetworks = 300,
            //};

            //var subnetCalculatorInput = new SubnetCalculatorInput()
            //{
            //    IPAddress = "172.17.20.0/22",
            //    NumberOfNetworks = 17,
            //};

            var subnetCalculatorInput = new SubnetCalculatorInput()
            {
                IPAddress = "10.0.48.0/24",//"192.168.224.0/21",
                NumberOfNetworks = 63, //512
            };

            var subnetCalculator = new SubnetCalculatorEngine.Services.SubnetCalculatorEngine();

            var subnetCalculatorResult =  subnetCalculator.CalculateSubnet(subnetCalculatorInput);


            Console.WriteLine("Subnetting Calculation Input");
            Console.WriteLine($"\nIP Address: {subnetCalculatorInput.IPAddress}");
            Console.WriteLine($"Number of networks required: {subnetCalculatorInput.NumberOfNetworks}");

            Console.WriteLine("\nSubnetting Results");

            Console.WriteLine($"\nNumber of extra bits required: {subnetCalculatorResult.NumberOfExtraBitsRequired}");
            Console.WriteLine($"\nIP address in binary: {subnetCalculatorResult.IPAddressInBinary}");
            Console.WriteLine($"\nSubnet mask in binary: {subnetCalculatorResult.SubnetMaskInBinary}");
            Console.WriteLine($"Subnet mask IP Address: {subnetCalculatorResult.SubnetMaskIPAddress}");
            Console.WriteLine($"\nNetwork address in binary: {subnetCalculatorResult.NetworkAddressInBinary}");
            Console.WriteLine($"Network IP Address: {subnetCalculatorResult.NetworkIPAddress}");
            Console.WriteLine($"\nBroadcast address in binary: {subnetCalculatorResult.BroadcastAddressInBinary}");
            Console.WriteLine($"Broadcast IP Address: {subnetCalculatorResult.BroadcastIPAddress}");
            Console.WriteLine($"\nTotal Number of hosts: {subnetCalculatorResult.TotalNumberOfHosts}");
            Console.WriteLine($"Number of usable hosts: {subnetCalculatorResult.NumberOfUsableHosts}");

            Console.WriteLine($"\nSubnet mask with networks address in binary: {subnetCalculatorResult.NetworkSubnetMaskInBinary}");
            Console.WriteLine($"Subnet mask with networks IP Address: {subnetCalculatorResult.NetworkSubnetMaskIPAddress}");
            Console.WriteLine($"\nNetwork address with network mask in binary: {subnetCalculatorResult.NetworkWithNetworkMaskAddressInBinary}");
            Console.WriteLine($"Network with network mask IP Address: {subnetCalculatorResult.NetworkWithNetworkMaskIPAddress}");
            Console.WriteLine($"\nBroadcast with network mask address in binary: {subnetCalculatorResult.BroadcastWithNetworkMaskAddressInBinary}");
            Console.WriteLine($"Broadcast with network mask IP Address: {subnetCalculatorResult.BroadcastWithNetworkMaskIPAddress}");
            Console.WriteLine($"\nTotal Number of hosts: {subnetCalculatorResult.TotalNumberOfHostsWithNetworkMask}");
            Console.WriteLine($"Number of usable hosts: {subnetCalculatorResult.NumberOfUsableHostsWithNetworkMask}");

            Console.WriteLine($"\nNetwork 5 address in binary: {subnetCalculatorResult.Network5IPAddressInBinary}");
            Console.WriteLine($"Network 5 IP Address: {subnetCalculatorResult.Network5IPAddress}");

            Console.WriteLine($"\nNetwork 22 address in binary: {subnetCalculatorResult.Network22IPAddressInBinary}");
            Console.WriteLine($"Network 22 IP Address: {subnetCalculatorResult.Network22IPAddress}");


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
