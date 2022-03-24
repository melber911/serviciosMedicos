using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus.Utilities
{
    public class Net
    {
    //    public static bool IsConnected { get; set; } = false;

    //    public static bool IsDisconnected { get; set; } = false;


        private static string xPcName="";
        /// <summary>
        ///     ''' Obtener el Nombre de la PC o Dispositivo
        ///     ''' </summary>
        public static string PcName
        {
            get
            {
                return xPcName;
            }
        }

        private static string xPcIPv4="";
        /// <summary>
        ///     ''' Obtener la IPv4 de la PC o dispositivo 
        ///     ''' </summary>
        public static string PcIPv4
        {
            get
            {
                return xPcIPv4;
            }
        }

        private static string xPcIPV6="";
        /// <summary>
        ///     ''' Obtener la IPv6 de la PC o dispositivo 
        ///     ''' </summary>
        public static string PcIPV6
        {
            get
            {
                return xPcIPV6;
            }
        }

        private static string xPcIPV6Alternate="";
        /// <summary>
        ///     ''' Obtener la IPv6 Alternativa de la PC o dispositivo 
        ///     ''' </summary>
        public static string PcIPV6Alternate
        {
            get
            {
                return xPcIPV6Alternate;
            }
        }

        private static void Load_PcName()
        {
            xPcName = System.Net.Dns.GetHostName();
        }

        private static void Load_PcIpAddress()
        {
            //System.Net.IPAddress oAddr;
            try
            {
                {
                    var withBlock = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                    foreach (var oAddr in withBlock.AddressList)
                    {   
                        switch (oAddr.AddressFamily)
                        {
                            case System.Net.Sockets.AddressFamily.InterNetwork // IPv4 of the PC
                           :
                                {
                                    xPcIPv4 = oAddr.ToString();
                                    break;
                                }

                            case System.Net.Sockets.AddressFamily.InterNetworkV6 // IPv6 of the PC
                     :
                                {
                                    if (oAddr.IsIPv6LinkLocal == true)
                                        xPcIPV6 = oAddr.ToString();
                                    else
                                        xPcIPV6Alternate = oAddr.ToString();
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        ///     ''' Iniciar para obtener las Ip's y Nombre de la PC o Dispositivo
        ///     ''' </summary>
        public void Load_Net()
        {
            Load_PcName();
            Load_PcIpAddress();
        }
    }
}