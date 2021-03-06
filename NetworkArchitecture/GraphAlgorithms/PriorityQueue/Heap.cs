﻿using System;

namespace NetworkArchitecture.GraphAlgorithms.PriorityQueue
{
    class Heap<T>: Queue<T> where T: new()
    {
        public void pushUp(int i)
        {
            while (i > 1 && nodes[i-1].Key > nodes[i / 2 - 1].Key)
            {
                Element<T> temp = nodes[i - 1];
                nodes[i - 1] = nodes[i / 2 - 1];
                nodes[i / 2 - 1] = temp;
                i /= 2;
            }
        }

        public void pushDown(int i)
        {
            while (2 * i <= numberOfElements)
            {
                int j = i * 2;

                if (j > numberOfElements)
                    if (nodes[i * 2 - 1].Key < nodes[(i * 2 + 1) - 1].Key)
                        j++;

                Element<T> temp = nodes[i - 1];
                nodes[i - 1] = nodes[j - 1];
                nodes[j - 1] = temp;
                i = j;
            }
        }

        public override void insertElement(Element<T> e)
        {
            nodes[++numberOfElements - 1] = e;
            pushUp(numberOfElements);
        }

        public override Element<T> deleteMax()
        {
            //Check if the queue exists
            if (numberOfElements == 0)
                throw new SystemException("Kolejka nie istnieje.");

            Element<T> max = nodes[0];

            nodes[0] = nodes[--numberOfElements];
            pushDown(1);

            nodes[numberOfElements] = null;

            return max;
        }
    }
}
