using Azure.Core;
using CashFlow.Application.Configuration.Commands;
using CashFlow.Application.Moviment.Save;
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
        public void TestAdd_Success()
        {
            bool resultValue = true;

            decimal valueMovement = 200;
            string typeMovement = "1";
            string namePerson = "Name Person 001";
            string typePerson = "1";

            CancellationToken cancellationToken = new CancellationToken();

            var command = new SaveMovimentCommand(valueMovement, typeMovement, namePerson, typePerson);

            Mock<ICommandHandler<SaveMovimentCommand, bool>> mock = new Mock<ICommandHandler<SaveMovimentCommand, bool>>();
            mock.Setup(m => m.Handle(command, cancellationToken).Result).Returns(resultValue);

            // act
            var result = mock.Object.Handle(command, cancellationToken).Result;

            // assert
            Assert.That(resultValue, Is.EqualTo(result));
        }


        [Test]
        public void TestAdd_Fail()
        {
            bool resultValue = false;

            decimal valueMovement = 0;
            string typeMovement = "";
            string namePerson = "";
            string typePerson = "";

            CancellationToken cancellationToken = new CancellationToken();

            var command = new SaveMovimentCommand(valueMovement, typeMovement, namePerson, typePerson);

            Mock<ICommandHandler<SaveMovimentCommand, bool>> mock = new Mock<ICommandHandler<SaveMovimentCommand, bool>>();
            mock.Setup(m => m.Handle(command, cancellationToken).Result).Returns(resultValue);

            // act
            var result = mock.Object.Handle(command, cancellationToken).Result;

            // assert
            Assert.That(resultValue, Is.EqualTo(result));
        }


    }
}