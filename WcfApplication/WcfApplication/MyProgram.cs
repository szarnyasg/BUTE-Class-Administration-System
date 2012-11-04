﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace WcfApplication
{
  class MyProgram
  {
    static void Main(string[] args)
    {
      Uri baseAddress = new Uri("http://localhost:8000/ServiceModelSamples/Service");

      // Step 2 of the hosting procedure: Create ServiceHost
      ServiceHost selfHost = new ServiceHost(typeof(Service), baseAddress);

      try
      {
        // Step 3 of the hosting procedure: Add a service endpoint.
        selfHost.AddServiceEndpoint(
            typeof(IService),
            new WSHttpBinding(),
            "MyService");

        // Step 4 of the hosting procedure: Enable metadata exchange.
        ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
        smb.HttpGetEnabled = true;
        selfHost.Description.Behaviors.Add(smb);

        // Step 5 of the hosting procedure: Start (and then stop) the service.
        selfHost.Open();
        Console.WriteLine("The service is ready.");
        Console.WriteLine("Press <ENTER> to terminate service.");
        Console.WriteLine();
        Console.ReadLine();

        // Close the ServiceHostBase to shutdown the service.
        selfHost.Close();
      }
      catch (CommunicationException ce)
      {
        Console.WriteLine("An exception occurred: {0}", ce.Message);
        selfHost.Abort();
      }
    }
  }
}


