using AuthorizeNet.Api.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    // Interface for auth.net
    public interface IPayment
    {   
        //Method that will be implemented into the service
        bool Run(customerAddressType addressType, decimal totalAmount);
    }
}
