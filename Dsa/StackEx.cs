using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class StackEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            Stack<string> numbers = new Stack<string>();
            numbers.Push("one");
            numbers.Push("two");
            numbers.Push("three");
            numbers.Push("four");
            numbers.Push("five");

            // A stack can be enumerated without disturbing its contents.
            foreach (string number in numbers)
            {
                Debug.WriteLine(number);
            }

            Debug.WriteLine($"\nPopping '{numbers.Pop()}'");
            Debug.WriteLine($"Peek at next item to destack: {numbers.Peek()}");
            Debug.WriteLine($"Popping '{numbers.Pop()}'");

            // Create a copy of the stack, using the ToArray method and the
            // constructor that accepts an IEnumerable<T>.
            Stack<string> stack2 = new Stack<string>(numbers.ToArray());

            Debug.WriteLine("\nContents of the first copy:");
            foreach (string number in stack2)
            {
                Debug.WriteLine(number);
            }

            // Create an array twice the size of the stack and copy the
            // elements of the stack, starting at the middle of the 
            // array. 
            string[] array2 = new string[numbers.Count * 2];
            numbers.CopyTo(array2, numbers.Count);

            // Create a second stack, using the constructor that accepts an
            // IEnumerable(Of T).
            Stack<string> stack3 = new Stack<string>(array2);

            Debug.WriteLine("\nContents of the second copy, with duplicates and nulls:");
            foreach (string number in stack3)
            {
                Debug.WriteLine(number);
            }

            Debug.WriteLine($"\nstack2.Contains(\"four\") = {stack2.Contains("four")}");

            Debug.WriteLine("\nstack2.Clear()");
            stack2.Clear();
            Debug.WriteLine($"\nstack2.Count = {stack2.Count}");
        }
    }
}