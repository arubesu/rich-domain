using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
                AddNotification("FirstName", "Invalid Name");

            if (string.IsNullOrEmpty(LastName))
                AddNotification("LastName", "Invalid Name");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}