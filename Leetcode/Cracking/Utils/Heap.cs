using System;
namespace Utils
{
    public class Heap
    {
        private int[] itemList;
        private int lastPosition;

        public Heap(int maxSize)
        {
            itemList = new int[maxSize];
            lastPosition = -1;
        }

        public int Peek()
        {
            if (lastPosition == 0)
            {
                throw new ArgumentException();
            }

            return itemList[0];
        }

        public int GetTop()
        {
            var tmp = itemList[0];
            itemList[0] = itemList[lastPosition];

            lastPosition--;
            HeapifyDown(0);

            return tmp;
        }

        public void Add(int element)
        {
            lastPosition++;
            itemList[lastPosition] = element;

            HeapifyUp(lastPosition);
        }

        private void HeapifyDown(int position)
        {
            var left = position * 2 + 1;
            var right = position * 2 + 2;

            // Either not enough nodes, or it's in the right place already
            if (left > lastPosition || ShouldBeHigher(itemList[position], itemList[left]))
            {
                return;
            }

            if (right > lastPosition)
            {
                var temp = itemList[position];
                itemList[position] = itemList[left];
                itemList[left] = temp;
                HeapifyDown(left);
                return;
            }

            if (ShouldBeHigher(itemList[left], itemList[right]))
            {
                var temp = itemList[position];
                itemList[position] = itemList[left];
                itemList[left] = temp;
                HeapifyDown(left);
            }
            else
            {
                var temp = itemList[position];
                itemList[position] = itemList[right];
                itemList[right] = temp;
                HeapifyDown(right);
            }
        }

        private void HeapifyUp(int position)
        {
            if (position == 0)
            {
                return;
            }

            var parent = position / 2;

            if (ShouldBeHigher(itemList[parent], itemList[position]))
            {
                return;
            }

            var temp = itemList[position];
            itemList[position] = itemList[parent];
            itemList[parent] = temp;
            HeapifyUp(parent);
        }

        private bool ShouldBeHigher(int first, int second)
        {
            return first > second;
        }
    }
}

