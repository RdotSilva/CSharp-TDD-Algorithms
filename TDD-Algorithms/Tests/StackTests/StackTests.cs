using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace TDD_Algorithms.Tests.StackTests
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_ReturnsTrue()
        {
            MyStack stack = new MyStack();
            Assert.IsTrue(stack.IsEmpty);
        }
    }
}
