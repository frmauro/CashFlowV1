using CashFlow.Domain;
using Moq;

namespace CashFlowUnitTest
{
    public class MovementTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetById()
        {
            var id = 348;
            var entityReturn = new Movement()
            {
                Id = id,
                Person = new Person()
            };

            Mock<IMovementRepository> mock = new Mock<IMovementRepository>();
            mock.Setup(m => m.GetByIdAsync(id).Result).Returns(entityReturn);

            // act
            var result = mock.Object.GetByIdAsync(id).Result;

            // assert
            Assert.That(entityReturn, Is.EqualTo(result));
        }
    }
}