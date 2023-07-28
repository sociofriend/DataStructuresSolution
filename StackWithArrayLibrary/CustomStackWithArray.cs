using System.Collections;
using System.Collections.Generic;

namespace StackWithArrayLibrary
{
    public class CustomStackWithArray<T> :  IEnumerable<T>
    {
        public T[] StackArray { get; set; } = new T[] { };
        public int Index { get; set; } = 0;

        public T Number1 { get; set; }
        public T Number2 { get; set; }
        public int Count
        {
            get
            {
                return Index;
            }
        }

        bool IsReadOnly => throw new NotImplementedException();

        public void Push(T v)
        {
            if(Index == StackArray.Length)
            {
                int newLength = Index == 0 ? 4 : Index * 2;

                T[] newArray = new T[newLength];
                StackArray.CopyTo(newArray, 0);
                StackArray = newArray;
            }
            StackArray[Index] = v;
            Index++;
            Number1 = StackArray[Index-1];
            if (Index > 1)
            {
                Number2 = StackArray[Index - 2];
            }
        }

        public T Peek()
        {
            if (Index == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            return StackArray[Index-1];
        }

        public T Pop()
        {
            if(Index == 0)
            {
                throw new InvalidOperationException("The stack is empty");
            }
            Index--;
            Number1 = StackArray[Index];
            if (Index > 1)
            {
                Number2 = StackArray[Index - 1];
            }
            return StackArray[Index];
        }


        void Clear()
        {
            Index = 0;
            Number1 = default(T);
            Number2 = default(T);
        }

       
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for(int i = Index; i > 0; i-- )
            {
                yield return StackArray[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }
    }
}