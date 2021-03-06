﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5456
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Runtime.Serialization.ContractNamespaceAttribute("http://Microsoft.ServiceModel.Samples", ClrNamespace="microsoft.servicemodel.samples")]

namespace microsoft.servicemodel.samples
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ComplexNumber", Namespace="http://Microsoft.ServiceModel.Samples")]
    public partial class ComplexNumber : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private double ImaginaryField;
        
        private double RealField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Imaginary
        {
            get
            {
                return this.ImaginaryField;
            }
            set
            {
                this.ImaginaryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double Real
        {
            get
            {
                return this.RealField;
            }
            set
            {
                this.RealField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="IService")]
public interface IService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IService/Add", ReplyAction="http://Microsoft.ServiceModel.Samples/IService/AddResponse")]
    microsoft.servicemodel.samples.ComplexNumber Add(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IService/Subtract", ReplyAction="http://Microsoft.ServiceModel.Samples/IService/SubtractResponse")]
    microsoft.servicemodel.samples.ComplexNumber Subtract(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IService/Multiply", ReplyAction="http://Microsoft.ServiceModel.Samples/IService/MultiplyResponse")]
    microsoft.servicemodel.samples.ComplexNumber Multiply(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IService/Divide", ReplyAction="http://Microsoft.ServiceModel.Samples/IService/DivideResponse")]
    microsoft.servicemodel.samples.ComplexNumber Divide(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IServiceChannel : IService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class ServiceClient : System.ServiceModel.ClientBase<IService>, IService
{
    
    public ServiceClient()
    {
    }
    
    public ServiceClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public microsoft.servicemodel.samples.ComplexNumber Add(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2)
    {
        return base.Channel.Add(n1, n2);
    }
    
    public microsoft.servicemodel.samples.ComplexNumber Subtract(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2)
    {
        return base.Channel.Subtract(n1, n2);
    }
    
    public microsoft.servicemodel.samples.ComplexNumber Multiply(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2)
    {
        return base.Channel.Multiply(n1, n2);
    }
    
    public microsoft.servicemodel.samples.ComplexNumber Divide(microsoft.servicemodel.samples.ComplexNumber n1, microsoft.servicemodel.samples.ComplexNumber n2)
    {
        return base.Channel.Divide(n1, n2);
    }
}
