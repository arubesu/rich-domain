using System.Collections.Generic;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscriptions { get; set; }

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(name, document, email);
        }

        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasActiveSubscription = false;
            foreach (var sub in Subscriptions)
            {
                if (sub.Active)
                    hasActiveSubscription = true;
            }

            AddNotifications(new Contract()
                .Requires()
                .IsGreaterThan(subscription.Payments.Count, 0, "Student.Subscriptions.Payments", "The subscription must have a payment!")
                .IsFalse(hasActiveSubscription, "Student.Subscription.Active", "The Student Already have an active subscription!")
               );

            if (this.Valid)
                _subscriptions.Add(subscription);
        }
    }
}