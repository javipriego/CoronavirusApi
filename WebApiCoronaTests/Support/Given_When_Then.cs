using System;

namespace WebApiCoronaTests.Support
{
    public abstract class Given_When_Then
        : IDisposable
    {
        protected Given_When_Then()
        {
            Given();
            When();
        }

        protected abstract void Given();

        protected abstract void When();

        public void Dispose()
        {
            CleanUp();
        }

        protected virtual void CleanUp()
        {
        }
    }
}