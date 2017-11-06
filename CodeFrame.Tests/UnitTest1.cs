using System;
using System.Linq;
using Xunit;

namespace CodeFrame.Tests
{
    public class UnitTest1
    {

        [Fact]
        public void TestMethod1()
        {
            var s = "akjdflsjfe2awfjwjafwljfe";
            var res = s.Count(i => i.ToString()=="a");
            Assert.Equal(3, res);
        }
    }
}
