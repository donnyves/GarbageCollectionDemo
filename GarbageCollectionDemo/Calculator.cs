using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarbageCollectionDemo
{
    class Calculator : IDisposable //IDisposable need to have the Dispose() method implemented.
    {
        private bool disposed = false;
        public Calculator()
        {
            Console.WriteLine("Caluculator being created");
        }
        ~Calculator()//The destructor is explicit garbage disposal.
        {
            Console.WriteLine("Calculator being finalized");
            this.Dispose();
        }
        public int Divide(int first, int second)
        {
            return first / second;
        }
        public void Dispose()//Get called by the CLR when the object goes out of scope.Implicit garbage disposal.
        {
            lock (this)
            {
                if (!this.disposed)
                {
                    Console.WriteLine("Calculator being disposed");
                }
                this.disposed = true;
                GC.SuppressFinalize(this);
            }
        }
    }
}
