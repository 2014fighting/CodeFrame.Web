using System;
using System.Linq;
using Xunit;

namespace CodeFrame.Tests
{
    public class UnitTest1
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitTest1(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Fact]
        public void TestMethod1()
        {
            var s = "akjdflsjfe2awfjwjafwljfe";
            var res = s.Count(i => i.ToString()=="a");
            Assert.Equal(3, res);
        }
        [Fact]
        public void GetUserInfo()
        {
             
        }
    }
}
