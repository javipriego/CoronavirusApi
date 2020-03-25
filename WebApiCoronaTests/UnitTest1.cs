using FluentAssertions;
using WebApiCoronaTests.Support;
using Xunit;

namespace WebApiCoronaTests
{
    public class UnitTest1
         : Given_When_Then
    {
        private string _sut;

        protected override void Given()
        {
        }

        protected override void When()
        {
            _sut = "hola";
        }

        [Theory]
        [InlineData("hola")]
        [InlineData("hol")]
        [InlineData("ho")]
        public void Then_Should_Contain_String(string message)
        {
            _sut.Should().Contain(message);
        }

        [Fact]
        public void Then_Should_Not_Be_Adios()
        {
            _sut.Should().NotBe("adios");
        }
    }
}
