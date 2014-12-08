﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;

namespace SeanLynch.YearFourProject.ProofOfConcept.WCFPOC
{
    public class ClientService : IComputerData
    {
        ClientComputer clientComputer = new ClientComputer();
        
        public string GetComputerData()
        {
            Console.WriteLine(clientComputer.GetComputerData());
            return clientComputer.GetComputerData();
        }

        public ClientComputer GetComputer()
        {
            return clientComputer;
        }

        public void StartProcess(string ProcessName)
        {
            Process.Start(ProcessName);
        }

        public int GetClientCPUUsage(ClientComputer PC)
        {
            PC.SetCPUUsage();
            return PC.CPUUsage;
        }
    }
}
