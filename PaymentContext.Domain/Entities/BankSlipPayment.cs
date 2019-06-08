using System;

namespace PaymentContext.Domain.Entities
{
    public class BankSlipPayment : Payment
    {
        public BankSlipPayment(string number, string barCode, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            string address, string payer, string payerDocument, string payerEmail) :
            base(paidDate, expireDate, total, totalPaid,
             address, payer, payerDocument, payerEmail)
        {
            Number = number;
            BarCode = barCode;
        }

        public string Number { get; private set; }
        public string BarCode { get; private set; }
    }
}