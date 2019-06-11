using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enumerations;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Student _student;
        private readonly BankSlipPayment _payment;

        public StudentTests()
        {
            _name = new Name("FOO", "BAR");
            _document = new Document("00845011030", DocumentType.CPF);
            _email = new Email("foobar@gmail.com");
            _address = new Address("St Foo", "100", null, "74890758", "FOOBAR", "FOO", "BAR", "FOOBAR");
            _student = new Student(_name, _document, _email);
            _payment = new BankSlipPayment("111", "000000", DateTime.Now, DateTime.Now.AddDays(10), 100, 100, _address, "FOO", _document, _email);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenAddSubscriptionToAStudentThatAlreadyHasAnActiveSubscription()
        {
            var subscription = new Subscription(true, null);
            subscription.AddPayment(_payment);

            var subscription2 = new Subscription(true, null);
            subscription2.AddPayment(_payment);

            _student.AddSubscription(subscription);
            _student.AddSubscription(subscription2);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenAddSubscriptionWithoutPayment()
        {
            var subscription = new Subscription(true, null);
            _student.AddSubscription(subscription);

            Assert.IsTrue(_student.Invalid);
        }


        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubcription()
        {
            var subscription = new Subscription(true, null);
            subscription.AddPayment(_payment);

            Assert.IsTrue(_student.Valid);
        }
    }
}