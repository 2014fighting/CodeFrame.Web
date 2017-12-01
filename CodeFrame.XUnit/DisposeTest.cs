using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;
using Xunit;

namespace CodeFrame.XUnit
{
   
    public class DisposeTest
    {
        [Fact]
        public void Mytest()
        {
            //https://docs.microsoft.com/zh-cn/dotnet/standard/garbage-collection/implementing-dispose
            //释放方式1 使用using 
            //using (var x = new MyDisposable())
            //{

            //}

            //释放方式2 实现Dispose方法 
            var x = new BaseClass();
            //do something
            x.Dispose();

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

    class BaseClass : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
