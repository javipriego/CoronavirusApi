using System;
using Xunit;
using Xunit.Sdk;

namespace WebApiCoronaTests.Support
{
    public abstract class Given_When_Then
        : IDisposable
    {
        protected Given_When_Then()
        {
            this.Given();
            this.When();
        }

        protected abstract void Given();

        protected abstract void When();

        public void Dispose()
        {
            this.CleanUp();
        }

        protected virtual void CleanUp()
        {
        }
    }
}