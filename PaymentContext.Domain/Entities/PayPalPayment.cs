using System;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(string transactionCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            string address, string payer, string payerDocument, string payerEmail) :
            base(paidDate, expireDate, total, totalPaid,
             address, payer, payerDocument, payerEmail)
        {
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; }
    }
}