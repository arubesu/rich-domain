using PaymentContext.Domain.Enumerations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.ValueObjects
{
   public class Document : ValueObject
    {
        public Document(string number, DocumentType type)
        {
            Number = number;
            Type = type;
        }

        public string Number { get; private set; }
        public DocumentType Type { get; private set; }
    }
}