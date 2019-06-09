
using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment : Entity
    {
        protected Payment(
            DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid,
            Address address, string payer, Document payerDocument, Email payerEmail
            )
        {
            Code = Guid.NewGuid();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Payer = payer;
            PayerDocument = payerDocument;
            PayerEmail = payerEmail;

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(TotalPaid, 0m, "Payment.TotalPaid","Total paid must be greater than 0.")
                .IsGreaterOrEqualsThan(TotalPaid, Total, "Payment.TotalPaid","Total paid must be equals the Total.")
            );
        }

        public Guid Code { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Address Address { get; private set; }
        public string Payer { get; private set; }
        public Document PayerDocument { get; private set; }
        public Email PayerEmail { get; private set; }
    }
}