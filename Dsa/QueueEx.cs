using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class QueueEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            Queue<string> numbers = new Queue<string>();
            numbers.Enqueue("one");
            numbers.Enqueue("two");
            numbers.Enqueue("three");
            numbers.Enqueue("four");
            numbers.Enqueue("five");

            // A queue can be enumerated without disturbing its contents.
            foreach (string number in numbers)
            {
                Debug.WriteLine(number);
            }

            Debug.WriteLine($"\nDequeuing '{numbers.Dequeue()}'");
            Debug.WriteLine($"Peek at next item to dequeue: {numbers.Peek()}");
            Debug.WriteLine($"Dequeuing '{numbers.Dequeue()}'");

            // Create a copy of the queue, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Queue<string> queueCopy = new Queue<string>(numbers.ToArray());

            Debug.WriteLine("\nContents of the first copy:");
            foreach (string number in queueCopy)
            {
                Debug.WriteLine(number);
            }

            // Create an array twice the size of the queue and copy the
            // elements of the queue, starting at the middle of the 
            // array. 
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second queue, using the constructor that accepts an
            // IEnumerable(Of T).
            Queue<string> queueCopy2 = new Queue<string>(array2);

            Debug.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in queueCopy2)
            {
                Debug.WriteLine(number);
            }

            Debug.WriteLine($"\nqueueCopy.Contains(\"four\") = {queueCopy.Contains("four")}");

            Debug.WriteLine("\nqueueCopy.Clear()");
            queueCopy.Clear();
            Debug.WriteLine($"\nqueueCopy.Count = {queueCopy.Count}");
        }
    }
}