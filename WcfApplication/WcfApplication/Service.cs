﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfApplication
{
  // This is the service class that implements the service contract.
  public class Service : IService
  {
    public ComplexNumber Add(ComplexNumber n1, ComplexNumber n2)
    {
      return new ComplexNumber(n1.Real + n2.Real, n1.Imaginary +
                                                    n2.Imaginary);
    }

    public ComplexNumber Subtract(ComplexNumber n1, ComplexNumber n2)
    {
      return new ComplexNumber(n1.Real - n2.Real, n1.Imaginary -
                                                   n2.Imaginary);
    }
    public ComplexNumber Multiply(ComplexNumber n1, ComplexNumber n2)
    {
      double real1 = n1.Real * n2.Real;
      double imaginary1 = n1.Real * n2.Imaginary;
      double imaginary2 = n2.Real * n1.Imaginary;
      double real2 = n1.Imaginary * n2.Imaginary * -1;
      return new ComplexNumber(real1 + real2, imaginary1 +
                                               imaginary2);
    }

    public ComplexNumber Divide(ComplexNumber n1, ComplexNumber n2)
    {
      ComplexNumber conjugate =
           new ComplexNumber(n2.Real, -1 * n2.Imaginary);
      ComplexNumber numerator = Multiply(n1, conjugate);
      ComplexNumber denominator = Multiply(n2, conjugate);
      return new ComplexNumber(numerator.Real / denominator.Real,
                                            numerator.Imaginary);
    }
  }
}
