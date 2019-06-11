using System.Linq;
using System.Collections.Generic;
using System;
using PaymentContext.Shared.Entities;
using Flunt.Validations;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private List<Payment> _payments;

        public Subscription(bool active, DateTime? expireDate = null)
        {
            CreatedDate = DateTime.Now;
            LastUpdatedDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = active;
            _payments = new List<Payment>();
        }

        public DateTime CreatedDate { get; private set; }
        public DateTime LastUpdatedDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            AddNotifications(new Contract()
                .Requires()
                .IsNotNull(payment, "Subscription.Payment", "Payment cannot be null")
            );

            if (this.Valid)
                _payments.Add(payment);
        }
        public void Activate()
        {
            Active = true;
            LastUpdatedDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            LastUpdatedDate = DateTime.Now;
        }
    }
}