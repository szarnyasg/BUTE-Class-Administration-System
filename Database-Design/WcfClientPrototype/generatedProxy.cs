﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5456
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Database_Design
{
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Hallgato", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", IsReference=true)]
    public partial class Hallgato : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Database_Design.ObjectChangeTracker ChangeTrackerField;
        
        private Database_Design.Csoport CsoportField;
        
        private string FelevField;
        
        private int IdField;
        
        private Database_Design.Kurzus KurzusField;
        
        private string NeptunField;
        
        private string NevField;
        
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
        public Database_Design.ObjectChangeTracker ChangeTracker
        {
            get
            {
                return this.ChangeTrackerField;
            }
            set
            {
                this.ChangeTrackerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Csoport Csoport
        {
            get
            {
                return this.CsoportField;
            }
            set
            {
                this.CsoportField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Felev
        {
            get
            {
                return this.FelevField;
            }
            set
            {
                this.FelevField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Kurzus Kurzus
        {
            get
            {
                return this.KurzusField;
            }
            set
            {
                this.KurzusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Neptun
        {
            get
            {
                return this.NeptunField;
            }
            set
            {
                this.NeptunField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nev
        {
            get
            {
                return this.NevField;
            }
            set
            {
                this.NevField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ObjectChangeTracker", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", IsReference=true)]
    public partial class ObjectChangeTracker : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Database_Design.ExtendedPropertiesDictionary ExtendedPropertiesField;
        
        private Database_Design.ObjectsAddedToCollectionProperties ObjectsAddedToCollectionPropertiesField;
        
        private Database_Design.ObjectsRemovedFromCollectionProperties ObjectsRemovedFromCollectionPropertiesField;
        
        private Database_Design.OriginalValuesDictionary OriginalValuesField;
        
        private Database_Design.ObjectState StateField;
        
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
        public Database_Design.ExtendedPropertiesDictionary ExtendedProperties
        {
            get
            {
                return this.ExtendedPropertiesField;
            }
            set
            {
                this.ExtendedPropertiesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.ObjectsAddedToCollectionProperties ObjectsAddedToCollectionProperties
        {
            get
            {
                return this.ObjectsAddedToCollectionPropertiesField;
            }
            set
            {
                this.ObjectsAddedToCollectionPropertiesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.ObjectsRemovedFromCollectionProperties ObjectsRemovedFromCollectionProperties
        {
            get
            {
                return this.ObjectsRemovedFromCollectionPropertiesField;
            }
            set
            {
                this.ObjectsRemovedFromCollectionPropertiesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.OriginalValuesDictionary OriginalValues
        {
            get
            {
                return this.OriginalValuesField;
            }
            set
            {
                this.OriginalValuesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.ObjectState State
        {
            get
            {
                return this.StateField;
            }
            set
            {
                this.StateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Csoport", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", IsReference=true)]
    public partial class Csoport : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Database_Design.ObjectChangeTracker ChangeTrackerField;
        
        private string FelevField;
        
        private Database_Design.Gyakorlatvezeto GyakorlatvezetoField;
        
        private Database_Design.Hallgato[] HallgatoField;
        
        private int IdField;
        
        private Database_Design.Kurzus KurzusField;
        
        private decimal SorszamField;
        
        private Database_Design.Terem TeremField;
        
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
        public Database_Design.ObjectChangeTracker ChangeTracker
        {
            get
            {
                return this.ChangeTrackerField;
            }
            set
            {
                this.ChangeTrackerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Felev
        {
            get
            {
                return this.FelevField;
            }
            set
            {
                this.FelevField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Gyakorlatvezeto Gyakorlatvezeto
        {
            get
            {
                return this.GyakorlatvezetoField;
            }
            set
            {
                this.GyakorlatvezetoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Hallgato[] Hallgato
        {
            get
            {
                return this.HallgatoField;
            }
            set
            {
                this.HallgatoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Kurzus Kurzus
        {
            get
            {
                return this.KurzusField;
            }
            set
            {
                this.KurzusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Sorszam
        {
            get
            {
                return this.SorszamField;
            }
            set
            {
                this.SorszamField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Terem Terem
        {
            get
            {
                return this.TeremField;
            }
            set
            {
                this.TeremField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Kurzus", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", IsReference=true)]
    public partial class Kurzus : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Database_Design.ObjectChangeTracker ChangeTrackerField;
        
        private Database_Design.Csoport[] CsoportField;
        
        private string FelevField;
        
        private Database_Design.Hallgato[] HallgatoField;
        
        private decimal Het_napjaField;
        
        private bool Het_paritasaField;
        
        private int IdField;
        
        private System.TimeSpan Idosav_kezdeteField;
        
        private Database_Design.Terem[] TeremField;
        
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
        public Database_Design.ObjectChangeTracker ChangeTracker
        {
            get
            {
                return this.ChangeTrackerField;
            }
            set
            {
                this.ChangeTrackerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Csoport[] Csoport
        {
            get
            {
                return this.CsoportField;
            }
            set
            {
                this.CsoportField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Felev
        {
            get
            {
                return this.FelevField;
            }
            set
            {
                this.FelevField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Hallgato[] Hallgato
        {
            get
            {
                return this.HallgatoField;
            }
            set
            {
                this.HallgatoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Het_napja
        {
            get
            {
                return this.Het_napjaField;
            }
            set
            {
                this.Het_napjaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Het_paritasa
        {
            get
            {
                return this.Het_paritasaField;
            }
            set
            {
                this.Het_paritasaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.TimeSpan Idosav_kezdete
        {
            get
            {
                return this.Idosav_kezdeteField;
            }
            set
            {
                this.Idosav_kezdeteField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Terem[] Terem
        {
            get
            {
                return this.TeremField;
            }
            set
            {
                this.TeremField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ExtendedPropertiesDictionary", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", ItemName="ExtendedProperties", KeyName="Name", ValueName="ExtendedProperty")]
    public class ExtendedPropertiesDictionary : System.Collections.Generic.Dictionary<string, object>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsAddedToCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", ItemName="AddedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="AddedObjects")]
    public class ObjectsAddedToCollectionProperties : System.Collections.Generic.Dictionary<string, Database_Design.ObjectList>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectsRemovedFromCollectionProperties", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", ItemName="DeletedObjectsForProperty", KeyName="CollectionPropertyName", ValueName="DeletedObjects")]
    public class ObjectsRemovedFromCollectionProperties : System.Collections.Generic.Dictionary<string, Database_Design.ObjectList>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="OriginalValuesDictionary", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", ItemName="OriginalValues", KeyName="Name", ValueName="OriginalValue")]
    public class OriginalValuesDictionary : System.Collections.Generic.Dictionary<string, object>
    {
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.FlagsAttribute()]
    [System.Runtime.Serialization.DataContractAttribute(Name="ObjectState", Namespace="http://schemas.datacontract.org/2004/07/Database_Design")]
    public enum ObjectState : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Unchanged = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Added = 2,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Modified = 4,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Deleted = 8,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ObjectList", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", ItemName="ObjectValue")]
    public class ObjectList : System.Collections.Generic.List<object>
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Gyakorlatvezeto", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", IsReference=true)]
    public partial class Gyakorlatvezeto : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Database_Design.ObjectChangeTracker ChangeTrackerField;
        
        private Database_Design.Csoport[] CsoportField;
        
        private string EmailField;
        
        private int IdField;
        
        private string NeptunField;
        
        private string NevField;
        
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
        public Database_Design.ObjectChangeTracker ChangeTracker
        {
            get
            {
                return this.ChangeTrackerField;
            }
            set
            {
                this.ChangeTrackerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Csoport[] Csoport
        {
            get
            {
                return this.CsoportField;
            }
            set
            {
                this.CsoportField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Email
        {
            get
            {
                return this.EmailField;
            }
            set
            {
                this.EmailField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Neptun
        {
            get
            {
                return this.NeptunField;
            }
            set
            {
                this.NeptunField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nev
        {
            get
            {
                return this.NevField;
            }
            set
            {
                this.NevField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Terem", Namespace="http://schemas.datacontract.org/2004/07/Database_Design", IsReference=true)]
    public partial class Terem : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private Database_Design.ObjectChangeTracker ChangeTrackerField;
        
        private Database_Design.Csoport CsoportField;
        
        private int Gepek_szamaField;
        
        private int IdField;
        
        private Database_Design.Kurzus[] KurzusField;
        
        private string NevField;
        
        private decimal Ulohelyek_szamaField;
        
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
        public Database_Design.ObjectChangeTracker ChangeTracker
        {
            get
            {
                return this.ChangeTrackerField;
            }
            set
            {
                this.ChangeTrackerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Csoport Csoport
        {
            get
            {
                return this.CsoportField;
            }
            set
            {
                this.CsoportField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Gepek_szama
        {
            get
            {
                return this.Gepek_szamaField;
            }
            set
            {
                this.Gepek_szamaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Database_Design.Kurzus[] Kurzus
        {
            get
            {
                return this.KurzusField;
            }
            set
            {
                this.KurzusField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nev
        {
            get
            {
                return this.NevField;
            }
            set
            {
                this.NevField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal Ulohelyek_szama
        {
            get
            {
                return this.Ulohelyek_szamaField;
            }
            set
            {
                this.Ulohelyek_szamaField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(Namespace="http://Microsoft.ServiceModel.Samples", ConfigurationName="IService")]
public interface IService
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://Microsoft.ServiceModel.Samples/IService/GetHallgato", ReplyAction="http://Microsoft.ServiceModel.Samples/IService/GetHallgatoResponse")]
    Database_Design.Hallgato GetHallgato();
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
    
    public Database_Design.Hallgato GetHallgato()
    {
        return base.Channel.GetHallgato();
    }
}