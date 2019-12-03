using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace DataStructures
{
    [TestFixture]
    public class ArrayQueueTests
    {
        [Test]
        public void Capacity_EnqueueManyItems_DoubledCapacity()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);

            Assert.AreEqual(8, queue.Capacity);
        }

        [Test]
        public void IsEmpty_EmptyQueue_ReturnsTrue()
        {
            var queue = new ArrayQueue<int>();
            Assert.IsTrue(queue.IsEmpty);
        }

        [Test]
        public void Count_PushOneItem_ReturnsOne()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);

            Assert.AreEqual(1, queue.Count);
            Assert.IsFalse(queue.IsEmpty);
        }

        [Test]
        public void Pop_EmptyStack_ThrowsException()
        {
            var queue = new ArrayQueue<int>();

            Assert.Throws<InvalidOperationException>(() =>
            {
                queue.Dequeue();
            });
        }

        [Test]
        public void Peek_PushTwoItems_ReturnsHeadItem()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            Assert.AreEqual(1, queue.Peek());
        }

        [Test]
        public void Peek_PushTwoItemsAndPop_ReturnsHeadElement()
        {
            var queue = new ArrayQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);

            queue.Dequeue();

            Assert.AreEqual(2, queue.Peek());
        }
    }
}

