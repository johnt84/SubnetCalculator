using SubnetCalculatorEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SubnetCalculatorEngine.Services
{
    public class SubnetCalculatorEngine
    {
        private string GetIPAddressWithMask(string IPAddress, int mask) => $"{IPAddress}/{mask}";

        public SubnetCalculatorResult CalculateSubnet(SubnetCalculatorInput subnetCalculatorInput)
        {
            var splitIPAddress = subnetCalculatorInput
                                    .IPAddress
                                    .Split('/')
                                    .ToArray();

            string IPAddress = splitIPAddress[0];
            int netMask = Convert.ToInt32(splitIPAddress[1]);

            int extraBitsForNetworkMask = GetNumberOfExtraBitsForNetwork(subnetCalculatorInput.NumberOfNetworks);

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

            int networkMask = netMask + extraBitsForNetworkMask;

            string networkSubnetMaskInBinary = CalculateSubNetBinaryMask(networkMask);
            string networkSubnetMaskIPAddress = ConvertBinaryToIPAdress(networkSubnetMaskInBinary);
            string networkSubnetMaskIPAddressWithMask = GetIPAddressWithMask(networkSubnetMaskIPAddress, networkMask);

            string networkAddressWithNetworkMaskInBinary = GetIPAddressInBinaryUsingMaskAndNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, false);
            string networkWithNetworkMaskIPAddress = ConvertBinaryToIPAdress(networkAddressWithNetworkMaskInBinary);
            string networkWithNetworkMaskIPAddressWithMask = GetIPAddressWithMask(networkWithNetworkMaskIPAddress, networkMask);

            string broadcastWithNetworkMaskAddressInBinary = GetIPAddressInBinaryUsingMaskAndNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, true);
            string broadcastWithNetworkMaskIPAddress = ConvertBinaryToIPAdress(broadcastWithNetworkMaskAddressInBinary);
            string broadcastWithNetworkMaskIPAddressWithMask = GetIPAddressWithMask(broadcastWithNetworkMaskIPAddress, networkMask);

            string N2NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 2);
            string N2NetworkMaskIPAddress = ConvertBinaryToIPAdress(N2NetworkMaskAddressInBinary);
            string N2NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N2NetworkMaskIPAddress, networkMask);

            string N5NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 5);
            string N5NetworkMaskIPAddress = ConvertBinaryToIPAdress(N5NetworkMaskAddressInBinary);
            string N5NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N5NetworkMaskIPAddress, networkMask);

            string N7NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 7);
            string N7NetworkMaskIPAddress = ConvertBinaryToIPAdress(N7NetworkMaskAddressInBinary);
            string N7NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N7NetworkMaskIPAddress, networkMask);

            string N15NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 15);
            string N15NetworkMaskIPAddress = ConvertBinaryToIPAdress(N15NetworkMaskAddressInBinary);
            string N15NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N15NetworkMaskIPAddress, networkMask);

            string N20NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 20);
            string N20NetworkMaskIPAddress = ConvertBinaryToIPAdress(N20NetworkMaskAddressInBinary);
            string N20NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N20NetworkMaskIPAddress, networkMask);

            string N22NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 22);
            string N22NetworkMaskIPAddress = ConvertBinaryToIPAdress(N22NetworkMaskAddressInBinary);
            string N22NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N22NetworkMaskIPAddress, networkMask);

            string N23NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 23);
            string N23NetworkMaskIPAddress = ConvertBinaryToIPAdress(N23NetworkMaskAddressInBinary);
            string N23NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N23NetworkMaskIPAddress, networkMask);

            string N32NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 32);
            string N32NetworkMaskIPAddress = ConvertBinaryToIPAdress(N32NetworkMaskAddressInBinary);
            string N32NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N32NetworkMaskIPAddress, networkMask);

            string N41NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 41);
            string N41NetworkMaskIPAddress = ConvertBinaryToIPAdress(N41NetworkMaskAddressInBinary);
            string N41NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N41NetworkMaskIPAddress, networkMask);

            string N55NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 55);
            string N55NetworkMaskIPAddress = ConvertBinaryToIPAdress(N55NetworkMaskAddressInBinary);
            string N55NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N55NetworkMaskIPAddress, networkMask);

            string N58NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 58);
            string N58NetworkMaskIPAddress = ConvertBinaryToIPAdress(N58NetworkMaskAddressInBinary);
            string N58NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N58NetworkMaskIPAddress, networkMask);

            string N72NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 72);
            string N72NetworkMaskIPAddress = ConvertBinaryToIPAdress(N72NetworkMaskAddressInBinary);
            string N72NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N72NetworkMaskIPAddress, networkMask);

            string N128NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 128);
            string N128NetworkMaskIPAddress = ConvertBinaryToIPAdress(N128NetworkMaskAddressInBinary);
            string N128NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N128NetworkMaskIPAddress, networkMask);

            string N145NetworkMaskAddressInBinary = CalculateNetworkIPAddressInBinaryUsingNetworkMask(IPAddressInBinary, netMask, extraBitsForNetworkMask, 145);
            string N145NetworkMaskIPAddress = ConvertBinaryToIPAdress(N145NetworkMaskAddressInBinary);
            string N145NetworkMaskIPAddressWithMask = GetIPAddressWithMask(N145NetworkMaskIPAddress, networkMask);

            return new SubnetCalculatorResult()
            {
                NumberOfExtraBitsRequired = extraBitsForNetworkMask,
                IPAddress = IPAddress,
                IPAddressInBinary = IPAddressInBinary,
                NetMask = netMask,
                SubnetMaskInBinary = subnetMaskInBinary,
                SubnetMaskIPAddress = subnetMaskIPAddressWithMask,
                NetworkAddressInBinary = networkAddressInBinary,
                NetworkIPAddress = networkIPAddressWithMask,
                BroadcastAddressInBinary = broadcastAddressInBinary,
                BroadcastIPAddress = broadcastIPAddressWithMask,
                NetworkSubnetMaskInBinary = networkSubnetMaskInBinary,
                NetworkSubnetMaskIPAddress = networkSubnetMaskIPAddressWithMask,
                NetworkWithNetworkMaskAddressInBinary = networkAddressWithNetworkMaskInBinary,
                NetworkWithNetworkMaskIPAddress = networkWithNetworkMaskIPAddressWithMask,
                BroadcastWithNetworkMaskAddressInBinary = broadcastWithNetworkMaskAddressInBinary,
                BroadcastWithNetworkMaskIPAddress = broadcastWithNetworkMaskIPAddressWithMask,
                Network5IPAddressInBinary = N5NetworkMaskAddressInBinary,
                Network5IPAddress = N5NetworkMaskIPAddressWithMask,
                Network22IPAddressInBinary = N5NetworkMaskAddressInBinary,
                Network22IPAddress = N22NetworkMaskIPAddressWithMask,
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

            var lastIPAddressOctet = IPAddressOctets.Last();

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
                IPAddress += octetIndex < 3 ? "." : string.Empty;

                octetIndex++;
            }

            return IPAddress;
        }

        private string ConvertIPAddressToBinary(string IPAddress)
        {
            var binaryToDecimalConversionForOctet = GetBinaryToDecimalConversion();

            var IPAddressOctets = SplitIPAddressIntoOctets(IPAddress);

            string IPAddressInBinary = string.Empty;

            var lastIPAddressOctet = IPAddressOctets.Last();

            foreach (var IPAddressOctet in IPAddressOctets)
            {
                int IPAddressBitSubtraction = Convert.ToInt32(IPAddressOctet);

                IPAddressInBinary += CalculateIPOctetInBinary(IPAddressOctet);

                IPAddressInBinary += IPAddressOctet != lastIPAddressOctet ? "." : string.Empty;
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
                IPAddressNetwork += isBroadcast ? "1" : "0";
            }

            var IPAddressNetworkBits = new List<string>();

            int bitIndex = 0;
            foreach(Char bit in IPAddressNetwork)
            {
                IPAddressNetworkBits.Add(bit.ToString());

                int theBitIndex = bitIndex + 1;
                bool isLastItem = theBitIndex == IPAddressNetwork.Length;
                if (theBitIndex % 8 == 0 && !isLastItem)
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
                IPAddressNetwork += isBroadcast ? "1" : "0";
            }

            int hostBits = 32 - IPAddressNetwork.Length;

            for (int i = 0; i < hostBits; i++)
            {
                IPAddressNetwork += isBroadcast ? "1" : "0";
            }

            return AddDotsToBinaryAddress(IPAddressNetwork);
        }

        private string CalculateNetworkIPAddressInBinaryUsingNetworkMask(string IPAddressInBinary, int mask, int numberOfExtraBits, int numberOfNetworks)
        {
            string networkBinary = CalculateIPOctetInBinary(numberOfNetworks.ToString(), numberOfBits: numberOfExtraBits);

            string IPAddressInBinaryWithNoDotSeperators = IPAddressInBinary.Replace(".", string.Empty);
            string IPAddressNetwork = $"{IPAddressInBinaryWithNoDotSeperators.Substring(0, mask)}";

            string IPAddress = IPAddressNetwork + networkBinary;

            int remainingBits = 32 - IPAddress.Length;

            for(int i= 0; i < remainingBits; i++)
            {
                IPAddress += "0";
            }

            return AddDotsToBinaryAddress(IPAddress);
        }

        private int CalculateNoOfHostBits(int mask)
        {
            int noOfBitsInIPAddress = 32;

            return noOfBitsInIPAddress - mask;
        }

        private string AddDotsToBinaryAddress(string binaryAddress)
        {
            var binaryAddressBits = new List<string>();

            int bitIndex = 0;
            foreach (Char bit in binaryAddress)
            {
                binaryAddressBits.Add(bit.ToString());

                int theBitIndex = bitIndex + 1;
                bool isLastItem = theBitIndex == binaryAddress.Length;
                if (theBitIndex % 8 == 0 && !isLastItem)
                {
                    binaryAddressBits.Add(".");
                }

                bitIndex++;
            }

            return string.Join("", binaryAddressBits);
        }

        private int GetNumberOfExtraBitsForNetwork(int numberOfNetworks)
        {
            var bitsCalculatorTableList = new List<BitsCalculatorTable>()
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

            return bitsCalculatorTableList
                    .Where(x => x.Networks > numberOfNetworks)
                    .Select(x => x.Bits)
                    .FirstOrDefault();
        }

        private int[] GetBinaryToDecimalConversion(int decimalValue = 128)
        {
            var binaryToDecimalConversionForOctet = GetBinaryToDecimalConversionForOctet();

            return binaryToDecimalConversionForOctet
                    .ToList()
                    .Where(x => decimalValue >= x)
                    .ToArray();
        }

        private int[] GetBinaryToDecimalConversionForOctet()
        {
            return new int[]{
                1024, 512, 256, 128, 64, 32, 16, 8, 4, 2, 1,
            };
        }

        private string GetDotInIPAddress(int index)
        {
            int hostIndex = index + 1;
            int noOfBitsInOctet = 8;
            return hostIndex % noOfBitsInOctet == 0 ? "." : string.Empty;
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
    }
}
