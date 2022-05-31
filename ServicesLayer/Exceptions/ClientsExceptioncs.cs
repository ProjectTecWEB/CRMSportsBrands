using System;
using System.Collections.Generic;
using System.Text;


namespace ServicesLayer.Exceptions
{
    class ClientsExceptioncs :Exception
    {
        public ClientsExceptioncs(String message) : base(message) { }
    }
}
