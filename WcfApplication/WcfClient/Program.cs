using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;

namespace microsoft.servicemodel.samples
{
  class Program
  {
    static void Main(string[] args)
    {
      ServiceClient client = new ServiceClient();


      // Call the Add service operation.
      ComplexNumber value1 = new ComplexNumber(); 
      value1.Real = 1; 
      value1.Imaginary = 2;
      ComplexNumber value2 = new ComplexNumber(); 
      value2.Real = 3;
      value2.Imaginary = 4;
      ComplexNumber result = client.Add(value1, value2);
      Console.WriteLine("Add({0} + {1}i, {2} + {3}i) = {4} + {5}i",
            value1.Real, value1.Imaginary, value2.Real, value2.Imaginary, 
            result.Real, result.Imaginary);
      
      //Step 3: Closing the client gracefully closes the connection and cleans up resources.
      client.Close();

      Console.WriteLine();
      Console.WriteLine("Press <ENTER> to terminate client.");
      Console.ReadLine();
    }
  }
}
