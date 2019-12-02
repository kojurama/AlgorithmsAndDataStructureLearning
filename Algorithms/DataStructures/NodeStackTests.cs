using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DataStructures
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void IsEmpty_EmptyStack_RetrunsTrue()
        {
            var stack = new NodeStack<int>();
            Assert.IsTrue(stack.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var stack = new NodeStack<int>();
            stack.Push(1);

            Assert.AreEqual(1, stack.Count);
            Assert.IsFalse(stack.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var stack = new NodeStack<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                stack.Pop();
            });
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            var stack = new NodeStack<int>();
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Peek());
        }

        [Test]
        public void Peek_PushTwoItemAndPop_ReturnsHeadElement()
        {
            var stack = new NodeStack<int>();

            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.AreEqual(1, stack.Peek());
        }
    }
}
