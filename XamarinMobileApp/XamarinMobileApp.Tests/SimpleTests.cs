namespace XamarinMobileApp.Tests
{
    using System;
    using System.Threading.Tasks;
    using Xunit;

    public class SimpleTests
    {
        [Fact]
        public void ThisShouldPass()
        {
            Assert.True(true);
        }

        [Fact]
        public async Task ThisShouldFail()
        {
            await Task.Run(() => { throw new Exception("boom"); });
        }
    }
}
