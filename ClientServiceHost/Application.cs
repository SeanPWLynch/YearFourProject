﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description; 

namespace SeanLynch.YearFourProject.ProofOfConcept.WCFPOC
{
    class Application
    {
        static void Main(string[] args)
        {
            // Step 1 Create a URI to serve as the base address.
            //Need to update to Uri Array/List For Multiple Clients
            Uri baseAddress = new Uri("net.tcp://localhost:8000/WCFClientService/");
            
            // Step 2 Create a ServiceHost instance
            ServiceHost selfHost = new ServiceHost(typeof(ClientService), baseAddress);

            try
            {
                // Step 3 Add a service endpoint.
                selfHost.AddServiceEndpoint(typeof(IComputerData), new NetTcpBinding(), "ClientService");

                // Step 4 Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();

                selfHost.Description.Behaviors.Add(smb);

                // Step 5 Start the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine(selfHost.BaseAddresses[0]);
                Console.WriteLine();
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (Exception ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                Console.ReadLine();
                selfHost.Abort();
            }
        }
    }
}
