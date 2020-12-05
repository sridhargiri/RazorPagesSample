using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public abstract class EntityBase
    {
        public abstract override string ToString();
        public abstract override bool Equals(object obj);
    }
    public class Customer : EntityBase
    {
        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
    public class D
    {
        public virtual void DoWork(int i)
        {
            // Original implementation.
        }
    }

    public abstract class E : D
    {
        public abstract override void DoWork(int i);
    }
    public abstract class F : E
    {
        public abstract override void DoWork(int i);
    }

    public class G : F
    {
        public override void DoWork(int i)
        {
            // New implementation.
        }
    }
}
