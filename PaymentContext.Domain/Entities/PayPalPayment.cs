using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            Address address, string payer, Document payerDocument, Email payerEmail) :
            base(paidDate, expireDate, total, totalPaid,
             address, payer, payerDocument, payerEmail)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}