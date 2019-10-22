using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TDD_Algorithms.Tests.LinkedListTests
{
    [TestFixture]
    public class LinkedListTests
    {
        [Test]
        public void CreateNode_SetsValueAndNextIsNull()
        {
            ListNode<int> node = new ListNode<int>(1);

            Assert.AreEqual(1, node.Value);
            Assert.IsNull(node.Next);
        }
    }

    public class ListNode<T>
    {
        public ListNode(T value)
        {
            throw new NotImplementedException();
        }

        public ListNode<T> Next { get; set; }
        public T Value { get; set; }
    }
}
