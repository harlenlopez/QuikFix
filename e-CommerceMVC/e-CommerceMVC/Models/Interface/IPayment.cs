using AuthorizeNet.Api.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Interface
{
    public interface IPayment
    {
        bool Run(customerAddressType addressType, decimal totalAmount);
    }
}
