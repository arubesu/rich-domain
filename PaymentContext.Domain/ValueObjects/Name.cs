using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName,3,"Name.FirstName","FirstName must have at least 3 characters!")
                .HasMinLen(LastName,3,"Name.LastName","LastName must have at least 3 characters!")
                .IsNotNullOrEmpty(FirstName,"Name.FirstName","FirstName cannot be null or empty")
                .IsNotNullOrEmpty(LastName,"Name.LastName","LastName cannot be null or empty")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}