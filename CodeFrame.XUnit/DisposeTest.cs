using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeFrame.XUnit
{
   
    public class DisposeTest
    {
        [Fact]
        public void Mytest()
        {
            using (var x = new MyDisposable())
            {
                
            }
            

        }
    }

    public class MyDisposable : IDisposable
    {
        public MyDisposable()
        {
            Console.WriteLine("+ {0} was created", this.GetType().Name);
        }

        public void Dispose()
        {
            Console.WriteLine("- {0} was disposed!", this.GetType().Name);
        }
    }
}
