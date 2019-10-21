﻿using System;

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
                throw new NotImplementedException();
            }

            public bool IsEmpty => true;
        }
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

        public bool IsEmpty => true;

        private static readonly EmptyStack _empty = new EmptyStack();
        public static IStack<T> Empty => _empty;

    }
}