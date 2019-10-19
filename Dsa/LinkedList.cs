using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class LinkedListEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Create the link list.
            string[] words =
                { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            Display(sentence, "The linked list values:");
            Debug.WriteLine($"sentence.Contains(\"jumps\") = {sentence.Contains("jumps")}");

            // Add the word 'today' to the beginning of the linked list.
            sentence.AddFirst("today");
            Display(sentence, "Test 1: Add 'today' to beginning of the list:");

            // Move the first node to be the last node.
            LinkedListNode<string> mark1 = sentence.First;
            sentence.RemoveFirst();
            sentence.AddLast(mark1);
            Display(sentence, "Test 2: Move first node to be last node:");

            // Change the last node to 'yesterday'.
            sentence.RemoveLast();
            sentence.AddLast("yesterday");
            Display(sentence, "Test 3: Change the last node to 'yesterday':");

            // Move the last node to be the first node.
            mark1 = sentence.Last;
            sentence.RemoveLast();
            sentence.AddFirst(mark1);
            Display(sentence, "Test 4: Move last node to be first node:");


            // Indicate the last occurence of 'the'.
            sentence.RemoveFirst();
            LinkedListNode<string> current = sentence.FindLast("the");
            IndicateNode(current, "Test 5: Indicate last occurence of 'the':");

            // Add 'lazy' and 'old' after 'the' (the LinkedListNode named current).
            sentence.AddAfter(current, "old");
            sentence.AddAfter(current, "lazy");
            IndicateNode(current, "Test 6: Add 'lazy' and 'old' after 'the':");

            // Indicate 'fox' node.
            current = sentence.Find("fox");
            IndicateNode(current, "Test 7: Indicate the 'fox' node:");

            // Add 'quick' and 'brown' before 'fox':
            sentence.AddBefore(current, "quick");
            sentence.AddBefore(current, "brown");
            IndicateNode(current, "Test 8: Add 'quick' and 'brown' before 'fox':");

            // Keep a reference to the current node, 'fox',
            // and to the previous node in the list. Indicate the 'dog' node.
            mark1 = current;
            LinkedListNode<string> mark2 = current.Previous;
            current = sentence.Find("dog");
            IndicateNode(current, "Test 9: Indicate the 'dog' node:");

            // The AddBefore method throws an InvalidOperationException
            // if you try to add a node that already belongs to a list.
            Debug.WriteLine("Test 10: Throw exception by adding node (fox) already in the list:");
            try
            {
                sentence.AddBefore(current, mark1);
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Exception message: {ex.Message}");
            }
            Debug.WriteLine("");

            // Remove the node referred to by mark1, and then add it
            // before the node referred to by current.
            // Indicate the node referred to by current.
            sentence.Remove(mark1);
            sentence.AddBefore(current, mark1);
            IndicateNode(current, "Test 11: Move a referenced node (fox) before the current node (dog):");

            // Remove the node referred to by current.
            sentence.Remove(current);
            IndicateNode(current, "Test 12: Remove current node (dog) and attempt to indicate it:");

            // Add the node after the node referred to by mark2.
            sentence.AddAfter(mark2, current);
            IndicateNode(current, "Test 13: Add node removed in test 11 after a referenced node (brown):");

            // The Remove method finds and removes the
            // first node that that has the specified value.
            sentence.Remove("old");
            Display(sentence, "Test 14: Remove node that has the value 'old':");

            // When the linked list is cast to ICollection(Of String),
            // the Add method adds a node to the end of the list.
            sentence.RemoveLast();
            ICollection<string> icoll = sentence;
            icoll.Add("rhinoceros");
            Display(sentence, "Test 15: Remove last node, cast to ICollection, and add 'rhinoceros':");

            Debug.WriteLine("Test 16: Copy the list to an array:");
            // Create an array with the same number of
            // elements as the inked list.
            string[] sArray = new string[sentence.Count];
            sentence.CopyTo(sArray, 0);

            foreach (string s in sArray)
            {
                Debug.WriteLine(s);
            }

            // Release all the nodes.
            sentence.Clear();

            Debug.WriteLine("");
            Debug.WriteLine($"Test 17: Clear linked list. Contains 'jumps' = {sentence.Contains("jumps")}");
        }


        void Display(LinkedList<string> words, string test)
        {
            Debug.WriteLine(test);
            foreach (string word in words)
            {
                Debug.Write(word + " ");
            }
            Debug.WriteLine("");
            Debug.WriteLine("");
        }

        void IndicateNode(LinkedListNode<string> node, string test)
        {
            Debug.WriteLine(test);
            if (node.List == null)
            {
                Debug.WriteLine("Node '{0}' is not in the list.\n",
                    node.Value);
                return;
            }

            StringBuilder result = new StringBuilder("(" + node.Value + ")");
            LinkedListNode<string> nodeP = node.Previous;

            while (nodeP != null)
            {
                result.Insert(0, nodeP.Value + " ");
                nodeP = nodeP.Previous;
            }

            node = node.Next;
            while (node != null)
            {
                result.Append(" " + node.Value);
                node = node.Next;
            }

            Debug.WriteLine(result);
            Debug.WriteLine("");
        }
    }

    [TestClass]
    public class LinkedListNodeEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Create a new LinkedListNode of type String and displays its properties.
            LinkedListNode<String> lln = new LinkedListNode<String>("orange");
            Debug.WriteLine("After creating the node ....");
            DisplayProperties(lln);

            // Create a new LinkedList.
            LinkedList<String> ll = new LinkedList<String>();

            // Add the "orange" node and display its properties.
            ll.AddLast(lln);
            Debug.WriteLine("After adding the node to the empty LinkedList ....");
            DisplayProperties(lln);

            // Add nodes before and after the "orange" node and display the "orange" node's properties.
            ll.AddFirst("red");
            ll.AddLast("yellow");
            Debug.WriteLine("After adding red and yellow ....");
            DisplayProperties(lln);
        }

        void DisplayProperties(LinkedListNode<String> lln)
        {
            if (lln.List == null)
                Debug.WriteLine("   Node is not linked.");
            else
                Debug.WriteLine($"   Node belongs to a linked list with {lln.List.Count} elements.");

            if (lln.Previous == null)
                Debug.WriteLine("   Previous node is null.");
            else
                Debug.WriteLine($"   Value of previous node: {lln.Previous.Value}");

            Debug.WriteLine($"   Value of current node:  {lln.Value}");

            if (lln.Next == null)
                Debug.WriteLine("   Next node is null.");
            else
                Debug.WriteLine($"   Value of next node:     {lln.Next.Value}");

            Debug.WriteLine("");
        }
    }
}