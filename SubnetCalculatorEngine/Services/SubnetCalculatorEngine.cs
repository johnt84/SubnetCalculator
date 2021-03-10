using SubnetCalculatorEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubnetCalculatorEngine.Services
{
    public class SubnetCalculatorEngine
    {
        private const int NO_OF_OCTETS = 4;
        private const int NO_OF_BITS_IN_IP_ADDRESS = 32;
        private const int NO_OF_RESERVED_HOSTS = 2;

    private bool IsLastOctet(int octetIndex) => octetIndex == NO_OF_OCTETS - 1;
        private string AddDotInBetweenOctets(int octetIndex) => !IsLastOctet(octetIndex) ? "." : string.Empty;
        private string GetIPAddressWithMask(string IPAddress, int mask) => $"{IPAddress}/{mask}";
        private string GetBroadcastBit(bool isBroadcastBit) => isBroadcastBit ? "1" : "0";
        private int CalculateNoOfHostBits(int mask) => NO_OF_BITS_IN_IP_ADDRESS - mask;
        private int[] GetBinaryToDecimalConversionForOctet() => new int[]{
                                                                1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1 };
        private int NumberOfRemainingBits(int netMask) => NO_OF_BITS_IN_IP_ADDRESS - netMask;

        private double NumberOfUsableHosts(double numberOfHosts) => numberOfHosts > 1
                                                                    ? numberOfHosts - NO_OF_RESERVED_HOSTS
                                                                    : 0;

        private List<BitsCalculatorTable> BitsCalculatorTableList() => new List<BitsCalculatorTable>()
            { 
                new BitsCalculatorTable()
                {
                    Bits = 0,
                    Networks = 1,
                    Hosts = 0,
                },
                new BitsCalculatorTable()
                {
                    Bits = 1,
                    Networks = 2,
                    Hosts = 0,
                },
                new BitsCalculatorTable()
                {
                    Bits = 2,
                    Networks = 4,
                    Hosts = 2,
                },
                new BitsCalculatorTable()
                {
                    Bits = 3,
                    Networks = 8,
                    Hosts = 6,
                },
                new BitsCalculatorTable()
                {
                    Bits = 4,
                    Networks = 16,
                    Hosts = 14,
                },
                new BitsCalculatorTable()
                {
                    Bits = 5,
                    Networks = 32,
                    Hosts = 30,
                },
                new BitsCalculatorTable()
                {
                    Bits = 6,
                    Networks = 64,
                    Hosts = 62,
                },
                new BitsCalculatorTable()
                {
                    Bits = 7,
                    Networks = 128,
                    Hosts = 126,
                },
                new BitsCalculatorTable()
                {
                    Bits = 8,
                    Networks = 256,
                    Hosts = 254,
                },
                new BitsCalculatorTable()
                {
                    Bits = 9,
                    Networks = 512,
                    Hosts = 510,
                },
                new BitsCalculatorTable()
                {
                    Bits = 10,
                    Networks = 1024,
                    Hosts = 1020,
                },
            };

        public SubnetCalculatorResult CalculateSubnet(SubnetCalculatorInput subnetCalculatorInput)
        {
            var splitIPAddress = subnetCalculatorInput
                                    .IPAddress
                                    .Split('/')
                                    .ToArray();

            string IPAddress = splitIPAddress[0];
            int netMask = Convert.ToInt32(splitIPAddress[1]);

            var bitsCalculatorTableRecord = BitsCalculatorTableList()
                                            .Where(x => x.Networks > subnetCalculatorInput.NumberOfNetworks && x.Bits <= NumberOfRemainingBits(netMask))
                                            .FirstOrDefault(); 

            string IPAddressInBinary = ConvertIPAddressToBinary(IPAddress);
            string IPAddressWithMask = GetIPAddressWithMask(IPAddress, netMask);

            string subnetMaskInBinary = CalculateSubNetBinaryMask(netMask);
            string subnetMaskIPAddress = ConvertBinaryToIPAdress(subnetMaskInBinary);
            string subnetMaskIPAddressWithMask = GetIPAddressWithMask(subnetMaskIPAddress, netMask);

            string networkAddressInBinary = GetIPAddressInBinaryUsingMask(IPAddressInBinary, netMask, false);
            string networkIPAddress = ConvertBinaryToIPAdress(networkAddressInBinary);
            string networkIPAddressWithMask = GetIPAddressWithMask(networkIPAddress, netMask);

            string broadcastAddressInBinary = GetIPAddressInBinaryUsingMask(IPAddressInBinary, netMask, true);
            string broadcastIPAddress = ConvertBinaryToIPAdress(broadcastAddressInBinary);
            string broadcastIPAddressWithMask = GetIPAddressWithMask(broadcastIPAddress, netMask);

            string firstUsableIPAddress = ChangeLastOctetInIPAddress(networkIPAddress, 1);
            string firstUsableIPAddressWithMask = GetIPAddressWithMask(firstUsableIPAddress, netMask);
            string lastUsableIPAddress = ChangeLastOctetInIPAddress(broadcastIPAddress, -1);
            string lastUsableIPAddressWithMask = GetIPAddressWithMask(lastUsableIPAddress, netMask);

            var usableIPAddresses = GetIPAddressesInRange(firstUsableIPAddress, lastUsableIPAddress, netMask);

            double totalNumberOfHosts = Math.Pow(2, NumberOfRemainingBits(netMask)); //2 to the power of 

            double numberOfUsableHosts = NumberOfUsableHosts(totalNumberOfHosts);

            int networkMask = netMask + bitsCalculatorTableRecord.Bits;

            string networkSubnetMaskInBinary = CalculateSubNetBinaryMask(networkMask);
            string networkSubnetMaskIPAddress = ConvertBinaryToIPAdress(networkSubnetMaskInBinary);
            string networkSubnetMaskIPAddressWithMask = GetIPAddressWithMask(networkSubnetMaskIPAddress, networkMask);

            string networkAddressWithNetworkMaskInBinary = GetIPAddressInBinaryUsingMaskAndNetworkMask(IPAddressInBinary, netMask, bitsCalculatorTableRecord.Bits, false);
            string networkWithNetworkMaskIPAddress = ConvertBinaryToIPAdress(networkAddressWithNetworkMaskInBinary);
            string networkWithNetworkMaskIPAddressWithMask = GetIPAddressWithMask(networkWithNetworkMaskIPAddress, networkMask);

            string broadcastWithNetworkMaskAddressInBinary = GetIPAddressInBinaryUsingMaskAndNetworkMask(IPAddressInBinary, netMask, bitsCalculatorTableRecord.Bits, true);
            string broadcastWithNetworkMaskIPAddress = ConvertBinaryToIPAdress(broadcastWithNetworkMaskAddressInBinary);
            string broadcastWithNetworkMaskIPAddressWithMask = GetIPAddressWithMask(broadcastWithNetworkMaskIPAddress, networkMask);

            string firstUsableWithNetworkMaskIPAddress = ChangeLastOctetInIPAddress(networkWithNetworkMaskIPAddress, 1);
            string firstUsableWithNetworkMaskIPAddressWithMask = GetIPAddressWithMask(firstUsableWithNetworkMaskIPAddress, networkMask);
            string lastUsableWithNetworkMaskIPAddress = ChangeLastOctetInIPAddress(broadcastWithNetworkMaskIPAddress, -1);
            string lastUsableWithNetworkMaskIPAddressWithMask = GetIPAddressWithMask(lastUsableWithNetworkMaskIPAddress, networkMask);

            var usableIPWithNetworkMaskAddresses = GetIPAddressesInRange(firstUsableWithNetworkMaskIPAddress, lastUsableWithNetworkMaskIPAddress, networkMask);

            double totalNumberOfHostsWithNetworkMask = Math.Pow(2, NumberOfRemainingBits(networkMask)); //2 to the power of 

            double numberOfUsableHostsWithNetworkMask = NumberOfUsableHosts(totalNumberOfHostsWithNetworkMask);

            var networks = GetNetworks(bitsCalculatorTableRecord, IPAddressInBinary, netMask, networkMask, broadcastIPAddress);

            return new SubnetCalculatorResult()
            {
                NumberOfExtraBitsRequired = bitsCalculatorTableRecord.Bits,
                NumberOfNetworksProvided = bitsCalculatorTableRecord.Networks,
                IPAddress = IPAddress,
                IPAddressInBinary = IPAddressInBinary,
                NetMask = netMask,
                SubnetMaskInBinary = subnetMaskInBinary,
                SubnetMaskIPAddress = subnetMaskIPAddressWithMask,
                NetworkAddressInBinary = networkAddressInBinary,
                NetworkIPAddress = networkIPAddressWithMask,
                BroadcastAddressInBinary = broadcastAddressInBinary,
                BroadcastIPAddress = broadcastIPAddressWithMask,
                FirstUsableIPAddress = firstUsableIPAddressWithMask,
                LastUsableIPAddress = lastUsableIPAddressWithMask,
                UsableIPAddresses = usableIPAddresses,
                TotalNumberOfHosts = totalNumberOfHosts,
                NumberOfUsableHosts = numberOfUsableHosts,
                NetworkSubnetMaskInBinary = networkSubnetMaskInBinary,
                NetworkSubnetMaskIPAddress = networkSubnetMaskIPAddressWithMask,
                NetworkWithNetworkMaskAddressInBinary = networkAddressWithNetworkMaskInBinary,
                NetworkWithNetworkMaskIPAddress = networkWithNetworkMaskIPAddressWithMask,
                BroadcastWithNetworkMaskAddressInBinary = broadcastWithNetworkMaskAddressInBinary,
                BroadcastWithNetworkMaskIPAddress = broadcastWithNetworkMaskIPAddressWithMask,
                FirstUsableWithNetworkMaskIPAddress = firstUsableWithNetworkMaskIPAddressWithMask,
                LastUsableWithNetworkMaskIPAddress = lastUsableWithNetworkMaskIPAddressWithMask,
                UsableWithNetworkMaskIPAddresses = usableIPWithNetworkMaskAddresses,
                TotalNumberOfHostsWithNetworkMask = totalNumberOfHostsWithNetworkMask,
                NumberOfUsableHostsWithNetworkMask = numberOfUsableHostsWithNetworkMask,
                Networks = networks,
            };
        }

        private string CalculateSubNetBinaryMask(int netMask)
        {
            string subNetMask = string.Empty;

            for (int i = 0; i < netMask; i++)
            {
                subNetMask += "1";
            }

            int noOfHosts = CalculateNoOfHostBits(netMask);

            for (int i = 0; i < noOfHosts; i++)
            {
                subNetMask += "0";
            }

            return AddDotsToBinaryAddress(subNetMask);
        }

        private string ConvertBinaryToIPAdress(string IPAddressInBinary)
        {
            var binaryToDecimalConversion = GetBinaryToDecimalConversion();

            var IPAddressOctets = SplitIPAddressIntoOctets(IPAddressInBinary);

            string IPAddress = string.Empty;

            int octetIndex = 0;

            foreach (var IPAddressOctet in IPAddressOctets)
            {
                int octetCalculation = 0;
                int bitIndex = 0;

                foreach (Char bit in IPAddressOctet)
                {
                    octetCalculation += Convert.ToInt32(bit.ToString()) * binaryToDecimalConversion[bitIndex];
                    bitIndex++;
                }

                IPAddress += octetCalculation.ToString();

                //ensure we only add the dot after the first 3 octets
                IPAddress += AddDotInBetweenOctets(octetIndex);

                octetIndex++;
            }

            return IPAddress;
        }

        private string ConvertIPAddressToBinary(string IPAddress)
        {
            var IPAddressOctets = SplitIPAddressIntoOctets(IPAddress);

            string IPAddressInBinary = string.Empty;

            int octetIndex = 0;

            foreach (var IPAddressOctet in IPAddressOctets)
            {
                int IPAddressBitSubtraction = Convert.ToInt32(IPAddressOctet);

                IPAddressInBinary += CalculateIPOctetInBinary(IPAddressOctet);

                //ensure we only add the dot after the first 3 octets
                IPAddressInBinary += AddDotInBetweenOctets(octetIndex);

                octetIndex++;
            }

            return IPAddressInBinary;
        }

        private string GetIPAddressInBinaryUsingMask(string IPAddressInBinary, int mask, bool isBroadcast)
        {
            string IPAddressInBinaryWithNoDotSeperators = IPAddressInBinary.Replace(".", string.Empty);
            string IPAddressNetwork = $"{IPAddressInBinaryWithNoDotSeperators.Substring(0, mask)}";

            int hostBits = CalculateNoOfHostBits(mask);

            for (int i = 0; i < hostBits; i++)
            {
                IPAddressNetwork += GetBroadcastBit(isBroadcast);
            }

            var IPAddressNetworkBits = new List<string>();

            int bitIndex = 0;
            foreach(Char bit in IPAddressNetwork)
            {
                IPAddressNetworkBits.Add(bit.ToString());

                int theBitIndex = bitIndex + 1;
                bool isLastItem = theBitIndex == IPAddressNetwork.Length;

                //Add dot after each octet apart from the last
                bool endOfOctet = theBitIndex % 8 == 0;
                if (endOfOctet && !isLastItem)
                {
                    IPAddressNetworkBits.Add(".");
                }

                bitIndex++;
            }

            return string.Join("", IPAddressNetworkBits);
        }

        private string GetIPAddressInBinaryUsingMaskAndNetworkMask(string IPAddressInBinary, int mask, int noOfNetworkBits, bool isBroadcast)
        {
            string IPAddressInBinaryWithNoDotSeperators = IPAddressInBinary.Replace(".", string.Empty);
            string IPAddressNetwork = $"{IPAddressInBinaryWithNoDotSeperators.Substring(0, mask)}";

            for (int i = 0; i < noOfNetworkBits; i++)
            {
                IPAddressNetwork += GetBroadcastBit(isBroadcast);
            }

            int hostBits = NO_OF_BITS_IN_IP_ADDRESS - IPAddressNetwork.Length;

            for (int i = 0; i < hostBits; i++)
            {
                IPAddressNetwork += GetBroadcastBit(isBroadcast);
            }

            return AddDotsToBinaryAddress(IPAddressNetwork);
        }

        private string CalculateNetworkIPAddressInBinaryUsingNetworkMask(string IPAddressInBinary, int mask, int numberOfExtraBits, int numberOfNetworks)
        {
            string networkBinary = CalculateIPOctetInBinary(numberOfNetworks.ToString(), numberOfBits: numberOfExtraBits);

            string IPAddressInBinaryWithNoDotSeperators = IPAddressInBinary.Replace(".", string.Empty);
            string IPAddressNetwork = $"{IPAddressInBinaryWithNoDotSeperators.Substring(0, mask)}";

            string IPAddress = IPAddressNetwork + networkBinary;

            int remainingBits = NO_OF_BITS_IN_IP_ADDRESS - IPAddress.Length;

            for(int i= 0; i < remainingBits; i++)
            {
                IPAddress += "0";
            }

            return AddDotsToBinaryAddress(IPAddress);
        }

        private string AddDotsToBinaryAddress(string binaryAddress)
        {
            var binaryAddressBits = new List<string>();

            int bitIndex = 0;
            foreach (Char bit in binaryAddress)
            {
                binaryAddressBits.Add(bit.ToString());

                int bitPosition = bitIndex + 1;
                bool isLastItem = bitPosition == binaryAddress.Length;
                bool endsOctet = bitPosition % 8 == 0;
                if (endsOctet && !isLastItem)
                {
                    binaryAddressBits.Add(".");
                }

                bitIndex++;
            }

            return string.Join("", binaryAddressBits);
        }

        private int[] GetBinaryToDecimalConversion(int decimalValue = 128)
        {
            var binaryToDecimalConversionForOctet = GetBinaryToDecimalConversionForOctet();

            return binaryToDecimalConversionForOctet
                    .ToList()
                    .Where(x => decimalValue >= x)
                    .ToArray();
        }

        private string CalculateIPOctetInBinary(string IPAddressOctet, int numberOfBits = 8)
        {
            int IPAddressBitSubtraction = Convert.ToInt32(IPAddressOctet);

            var binaryToDecimalConversionForOctet = GetBinaryToDecimalConversion(decimalValue:IPAddressBitSubtraction);

            string IPOctetInBinary = string.Empty;

            for (int i = 0; i < binaryToDecimalConversionForOctet.Length; i++)
            {
                int theIPAddressBitSubtraction = 0;

                int binaryMultiplier = binaryToDecimalConversionForOctet[i];

                theIPAddressBitSubtraction = IPAddressBitSubtraction - binaryMultiplier;

                if (IPAddressBitSubtraction >= binaryMultiplier &&
                    theIPAddressBitSubtraction >= 0)
                {
                    IPAddressBitSubtraction = theIPAddressBitSubtraction;
                    IPOctetInBinary += "1";
                }
                else
                {
                    IPOctetInBinary += "0";
                }
            }

            int extraBits = numberOfBits - IPOctetInBinary.Length;
            string leadingZeros = string.Empty;

            for (int i = 0; i < extraBits; i++)
            {
                leadingZeros += "0";
            }

            return leadingZeros + IPOctetInBinary;
        }

        private List<string> SplitIPAddressIntoOctets(string IPAddress)
        {
            var IPAddressOctets = IPAddress
                                    .Split('.')
                                    .ToList();

            return IPAddressOctets
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToList();
        }

        private string ChangeLastOctetInIPAddress(string IPAddress, int changeLastOctetBy)
        {
            var IPAddressOctets = SplitIPAddressIntoOctets(IPAddress);
            int newLastOctetNumber = Convert.ToInt32(IPAddressOctets.Last()) + changeLastOctetBy;
            var IPAddressOctetsArr = IPAddressOctets.ToArray();
            IPAddressOctetsArr[IPAddressOctetsArr.Length - 1] = newLastOctetNumber.ToString();
            return string.Join(".", IPAddressOctetsArr.ToList());
        }

        private List<string> GetIPAddressesInRange(string startIPAddress, string endIPAddress, int mask)
        {
            var startIPAddressOctets = SplitIPAddressIntoOctets(startIPAddress);
            int startIPAddressLastOctetNumber = Convert.ToInt32(startIPAddressOctets.Last());
            string startIPAddressApartFromFirstOctet = string.Join(".", startIPAddressOctets.Take(startIPAddressOctets.Count - 1));

            var endIPAddressOctets = SplitIPAddressIntoOctets(endIPAddress);
            int endIPAddressOctetNumber = Convert.ToInt32(endIPAddressOctets.Last());

            if(endIPAddressOctetNumber <= startIPAddressLastOctetNumber)
            {
                return null;
            }

            var IPAddressesInRange = new List<string>();

            for(int i = startIPAddressLastOctetNumber; i <= endIPAddressOctetNumber; i++)
            {
                string currentIPAddress = $"{startIPAddressApartFromFirstOctet}.{i}";
                string currentIPAddressWithMask = GetIPAddressWithMask(currentIPAddress, mask);
                IPAddressesInRange.Add(currentIPAddressWithMask);
            }

            return IPAddressesInRange;
        }

        private List<Network> GetNetworks(BitsCalculatorTable bitsCalculatorTableRecord, string IPAddressInBinary, int netMask, int networkMask, string broadcastIPAddress)
        {
            var networks = new List<Network>();

            for (int x = 0; x < bitsCalculatorTableRecord.Networks; x++)
            {
                int networkNumber = x;

                string networkIPAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, bitsCalculatorTableRecord.Bits, networkNumber);
                string networkIPAddress = ConvertBinaryToIPAdress(networkIPAddressInBinary);
                string networkIPAddressWithMask = GetIPAddressWithMask(networkIPAddress, networkMask);

                string theBroadcastIPAddress = string.Empty;

                bool isLastNetwork = x == bitsCalculatorTableRecord.Networks - 1;

                if (!isLastNetwork)
                {
                    string nextNetworkIPAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, bitsCalculatorTableRecord.Bits, networkNumber + 1);
                    string nextNetworkIPAddress = ConvertBinaryToIPAdress(nextNetworkIPAddressInBinary);
                    theBroadcastIPAddress = ChangeLastOctetInIPAddress(nextNetworkIPAddress, -1);
                }
                else
                {
                    theBroadcastIPAddress = broadcastIPAddress;
                }

                string broadcastIPAddressWithMask = GetIPAddressWithMask(theBroadcastIPAddress, networkMask);

                string firstUsableIPAddress = ChangeLastOctetInIPAddress(networkIPAddress, 1);
                string firstUsableIPAddressWithMask = GetIPAddressWithMask(firstUsableIPAddress, networkMask);
                string lastUsableIPAddress = ChangeLastOctetInIPAddress(theBroadcastIPAddress, -1);
                string lastUsableIPAddressWithMask = GetIPAddressWithMask(lastUsableIPAddress, networkMask);

                networks.Add(new Network()
                {
                    NetworkNumber = networkNumber,
                    NetworkAddress = networkIPAddressWithMask,
                    BroadcastAddress = broadcastIPAddressWithMask,
                    FirstUsableIPAddress = firstUsableIPAddressWithMask,
                    LastUsableIPAddress = lastUsableIPAddressWithMask,
                });
            }

            return networks;
        }
    }
}
