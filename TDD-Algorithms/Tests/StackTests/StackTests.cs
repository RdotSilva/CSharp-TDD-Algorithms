﻿using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TDD_Algorithms.Tests.StackTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            var stack = new MyStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var stack = new MyStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new MyStack<int>();

            Assert.Throws<InvalidOperationException>(() => { stack.Pop(); });
        }

        

    }

    public class MyStack<T>
    {
        private List<T> _list = new List<T>();
        public bool IsEmpty => Count == 0;

        public int Count => _list.Count;

        public void Push(T value)
        {
            _list.Add(value);
        }

        public void Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }
        }

        public T Peek(int i)
        {
            return _list[Count - 1];
        }
    }
}
