using System;

namespace TDD_Algorithms.Stack
{
    public class ImmutableStack<T> : IStack<T>
    {
        private sealed class EmptyStack : IStack<T>
        {
            public bool IsEmpty => throw new NotImplementedException();

            public T Peek()
            {
                throw new NotImplementedException();
            }

            public IStack<T> Pop()
            {
                throw new NotImplementedException();
            }

            public IStack<T> Push(T value)
            {
                throw new NotImplementedException();
            }
        }
    }
}