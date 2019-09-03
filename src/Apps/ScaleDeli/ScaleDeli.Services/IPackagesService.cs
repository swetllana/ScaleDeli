using System;
using System.Collections.Generic;
using System.Text;

namespace ScaleDeli.Services
{
    public interface IPackagesService
    {
        void Create(string description, decimal weight, string shippingAddress, string recipientName);
      
    }
}
