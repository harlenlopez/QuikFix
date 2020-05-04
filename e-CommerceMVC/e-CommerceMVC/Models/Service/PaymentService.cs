using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC.Models.Service
{
    public class PaymentService
    {
        private readonly IConfiguration _config;

        public PaymentService(IConfiguration configuration)
        {
            _config = configuration;

        }
        public bool Run(customerAddressType addressType, decimal totalAmount)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType
            {
                name = _config["An-ApiId"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _config["An-TransactionKey"]
            };

            var CreditCard = new creditCardType
            {
                cardNumber = "4111111111111111",
                expirationDate = "0521",
                cardCode = "102"
            };
            var paymentType = new paymentType
            {
                Item = CreditCard
            };
            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = totalAmount,
                payment = paymentType,
                billTo = addressType
            };
            var request = new createTransactionRequest
            {
                transactionRequest = transactionRequest
            };
            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
