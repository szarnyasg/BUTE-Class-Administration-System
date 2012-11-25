using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BUTEClassAdministrationClient
{
	[Serializable()]
	class BUTEClassAdministrationException : System.Exception
	{
		public BUTEClassAdministrationException() : base() { }
		public BUTEClassAdministrationException(string message) : base(message) { }
		public BUTEClassAdministrationException(string message, System.Exception inner) : base(message, inner) { }

		// A constructor is needed for serialization when an 
		// exception propagates from a remoting server to the client.  
		protected BUTEClassAdministrationException(System.Runtime.Serialization.SerializationInfo info,
			System.Runtime.Serialization.StreamingContext context) { }
	}
}
