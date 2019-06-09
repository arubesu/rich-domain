using Flunt.Validations;
using PaymentContext.Domain.Enumerations;
using PaymentContext.Shared.Entities;
using PaymentContext.Shared.Extensions;

namespace PaymentContext.Domain.ValueObjects
{
   public class Document : ValueObject
    {
        public Document(string number, DocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Number.IsValid(),"Document.Number", "Document is not valid!")
            );
        }

        public string Number { get; private set; }
        public DocumentType Type { get; private set; }
    }
}