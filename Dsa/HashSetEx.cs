using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class HashSetEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            HashSet<int> evenNumbers = new HashSet<int>();
            HashSet<int> oddNumbers = new HashSet<int>();

            for (int i = 0; i < 5; i++)
            {
                // Populate numbers with just even numbers.
                evenNumbers.Add(i * 2);

                // Populate oddNumbers with just odd numbers.
                oddNumbers.Add((i * 2) + 1);
            }

            Debug.Write($"evenNumbers contains {evenNumbers.Count} elements: ");
            DisplaySet(evenNumbers);

            Debug.Write($"oddNumbers contains {oddNumbers.Count} elements: ");
            DisplaySet(oddNumbers);

            // Create a new HashSet populated with even numbers.
            HashSet<int> numbers = new HashSet<int>(evenNumbers);
            Debug.WriteLine("numbers UnionWith oddNumbers...");
            numbers.UnionWith(oddNumbers);

            Debug.Write($"numbers contains {numbers.Count} elements: ");
            DisplaySet(numbers);
        }

        void DisplaySet(HashSet<int> set)
        {
            Debug.Write("{");
            foreach (int i in set)
            {
                Debug.Write($" {i}");
            }
            Debug.WriteLine(" }");
        }
    }
}