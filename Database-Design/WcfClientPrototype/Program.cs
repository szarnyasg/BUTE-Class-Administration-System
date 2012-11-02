using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Database_Design;
using System.Data.Common;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;

namespace WcfClientPrototype
{
  class Program
  {
    static void Main(string[] args)
    {
      ServiceClient client = new ServiceClient();

      using (TerembeosztoEntitasok context = new TerembeosztoEntitasok())
      {
        Hallgato h = client.GetHallgato();
        h.Nev = "Gipsz Jakab";
        h.Neptun = "ABC123";

        context.SaveChanges();
      }
      



      Console.WriteLine();
      Console.WriteLine("Press <ENTER> to terminate client.");
      Console.ReadLine();
    }
  }
}
