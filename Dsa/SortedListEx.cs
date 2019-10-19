using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class SortedListEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Create a new sorted list of strings, with string
            // keys.
            SortedList<string, string> openWith =
                new SortedList<string, string>();

            // Add some elements to the list. There are no 
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is 
            // already in the list.
            try
            {
                openWith.Add("txt", "winword.exe");
            }
            catch (ArgumentException)
            {
                Debug.WriteLine("An element with Key = \"txt\" already exists.");
            }

            // The Item property is another name for the indexer, so you 
            // can omit its name when accessing elements. 
            Debug.WriteLine($"For key = \"rtf\", value = {openWith["rtf"]}.");

            // The indexer can be used to change the value associated
            // with a key.
            openWith["rtf"] = "winword.exe";
            Debug.WriteLine($"For key = \"rtf\", value = {openWith["rtf"]}.");

            // If a key does not exist, setting the indexer for that key
            // adds a new key/value pair.
            openWith["doc"] = "winword.exe";

            // The indexer throws an exception if the requested key is
            // not in the list.
            try
            {
                Debug.WriteLine($"For key = \"tif\", value = {openWith["tif"]}.");
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the list, TryGetValue can be a more efficient 
            // way to retrieve values.
            string value = "";
            if (openWith.TryGetValue("tif", out value))
            {
                Debug.WriteLine($"For key = \"tif\", value = {value}.");
            }
            else
            {
                Debug.WriteLine("Key = \"tif\" is not found.");
            }

            // ContainsKey can be used to test keys before inserting 
            // them.
            if (!openWith.ContainsKey("ht"))
            {
                openWith.Add("ht", "hypertrm.exe");
                Debug.WriteLine($"Value added for key = \"ht\": {openWith["ht"]}");
            }

            // When you use foreach to enumerate list elements,
            // the elements are retrieved as KeyValuePair objects.
            Debug.WriteLine("");
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Debug.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
            }

            // To get the values alone, use the Values property.
            IList<string> ilistValues = openWith.Values;

            // The elements of the list are strongly typed with the 
            // type that was specified for the SorteList values.
            Debug.WriteLine("");
            foreach (string s in ilistValues)
            {
                Debug.WriteLine($"Value = {s}");
            }

            // The Values property is an efficient way to retrieve
            // values by index.
            Debug.WriteLine("\nIndexed retrieval using the Values " +
                $"property: Values[2] = {openWith.Values[2]}");

            // To get the keys alone, use the Keys property.
            IList<string> ilistKeys = openWith.Keys;

            // The elements of the list are strongly typed with the 
            // type that was specified for the SortedList keys.
            Debug.WriteLine("");
            foreach (string s in ilistKeys)
            {
                Debug.WriteLine($"Key = {s}");
            }

            // The Keys property is an efficient way to retrieve
            // keys by index.
            Debug.WriteLine("\nIndexed retrieval using the Keys " +
                $"property: Keys[2] = {openWith.Keys[2]}");

            // Use the Remove method to remove a key/value pair.
            Debug.WriteLine("\nRemove(\"doc\")");
            openWith.Remove("doc");

            if (!openWith.ContainsKey("doc"))
            {
                Debug.WriteLine("Key \"doc\" is not found.");
            }
        }
    }
}