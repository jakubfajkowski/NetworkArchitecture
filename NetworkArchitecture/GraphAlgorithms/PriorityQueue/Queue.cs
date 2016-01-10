using System;
using System.IO;

namespace NetworkArchitecture.GraphAlgorithms.PriorityQueue
{
    abstract class Queue<T> where T : new()
    {
        protected Element<T>[] nodes;
        protected int n;
        public int Size
        {
            get { return n; }
        }

        public void initialise(int length)
        {
            nodes = new Element<T>[length];
        }
        abstract public void insertElement(Element<T> e);
        abstract public Element<T> deleteMax();
    }
}
