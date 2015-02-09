﻿using HorusClient.HorusServerClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HorusClient
{

    class Program
    {
        static void Main(string[] args)
        {
            s_ClientHost ClientHost = new s_ClientHost();

            Thread t_ClientHost = new Thread(ClientHost.StartServce);
            t_ClientHost.Start();

            try
            {
                ServerClientServiceClient client = new ServerClientServiceClient();

                client.Endpoint.Address = new System.ServiceModel.EndpointAddress("net.tcp://dev-server2012-dc:13000/ServerClientService/ServerClientService");

                client.Open();
                client.HandShake(Environment.MachineName);

                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
