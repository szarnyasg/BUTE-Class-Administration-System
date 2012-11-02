using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.Runtime.Serialization;

namespace WcfApplication
{
  // Define a service contract.
  [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
  public interface IService
  {
    [OperationContract]
    ComplexNumber Add(ComplexNumber n1, ComplexNumber n2);
    [OperationContract]
    ComplexNumber Subtract(ComplexNumber n1, ComplexNumber n2);
    [OperationContract]
    ComplexNumber Multiply(ComplexNumber n1, ComplexNumber n2);
    [OperationContract]
    ComplexNumber Divide(ComplexNumber n1, ComplexNumber n2);
  }

  [DataContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
  public class ComplexNumber
  {
    [DataMember]
    public double Real = 0.0D;
    [DataMember]
    public double Imaginary = 0.0D;

    public ComplexNumber(double real, double imaginary)
    {
      this.Real = real;
      this.Imaginary = imaginary;
    }
  }
}
