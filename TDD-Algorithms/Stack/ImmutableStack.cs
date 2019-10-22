using System;

namespace TDD_Algorithms.Stack
{
    public class ImmutableStack<T> : IStack<T>
    {
        private sealed class EmptyStack : IStack<T>
        {
            public T Peek()
            {
                throw new InvalidOperationException();
            }

            public IStack<T> Pop()
            {
                throw new InvalidOperationException();
            }

            public IStack<T> Push(T value)
            {
                return new ImmutableStack<T>(value, this);
            }

            public bool IsEmpty => true;
        }

        private ImmutableStack(T head, IStack<T> tail)
        {
            _head = head;
            _tail = tail;
        }
        public T Peek()
        {
            return _head;
        }

        public IStack<T> Pop()
        {
            return _tail;
        }

        public IStack<T> Push(T value)
        {
            return new ImmutableStack<T>(value, this);
        }

        public bool IsEmpty => true;

        private static readonly EmptyStack _empty = new EmptyStack();

        private readonly T _head;

        private readonly IStack<T> _tail;

        public static IStack<T> Empty => _empty;

    }
}