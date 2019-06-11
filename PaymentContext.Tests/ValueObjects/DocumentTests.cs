using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enumerations;
using PaymentContext.Domain.ValueObjects;
namespace PaymentContext.Tests
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        [DataTestMethod]
        [DataRow("147.060.600-00")]
        [DataRow("75516515029")]
        [DataRow("942.106.920-10")]
        [DataRow("737904580")]
        [DataRow("862.610.820-62")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var document = new Document(cpf, DocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        }


        [TestMethod]
        [DataTestMethod]
        [DataRow("13.772.582/0001-10")]
        [DataRow("42443975000135")]
        [DataRow("29.492.301/0001-62")]
        [DataRow("708765720001")]
        [DataRow("13.982.381/0001-2")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string cnpj)
        {
            var document = new Document(cnpj, DocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("147.060.600-36")]
        [DataRow("75516515009")]
        [DataRow("942.106.920-00")]
        [DataRow("73790458066")]
        [DataRow("862.610.820-65")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var document = new Document(cpf, DocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("13.772.582/0001-76")]
        [DataRow("42443975000134")]
        [DataRow("29.492.301/0001-61")]
        [DataRow("70876572000114")]
        [DataRow("13.982.381/0001-01")]
        public void ShouldReturnSuccessWhenCNPJIsValid(string cnpj)
        {
            var document = new Document(cnpj, DocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}