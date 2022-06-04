using Xunit;

namespace RabbitMq.MessageGenerator.Tests
{
    public class MessageGeneratorTests
    {
        private readonly MessageGenerator _target;

        public MessageGeneratorTests()
        {
            _target = new MessageGenerator();
        }

        [Fact]
        public void GenerateTest()
        {
            // arrange

            // action
            var actual = _target.Generate();

            // assert
            Assert.NotNull(actual);
        }
    }
}