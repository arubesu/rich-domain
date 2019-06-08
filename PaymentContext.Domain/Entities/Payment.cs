
using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(
            DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            string address, string payer, string payerDocument, string payerEmail
            )
        {
            Code = new Guid();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Payer = payer;
            PayerDocument = payerDocument;
            PayerEmail = payerEmail;
        }

        public Guid Code { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Address { get; private set; }
        public string Payer { get; private set; }
        public string PayerDocument { get; private set; }
        public string PayerEmail { get; private set; }
    }
}