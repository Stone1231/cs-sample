using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class SortedDictionaryEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Create a new sorted dictionary of strings, with string
            // keys.
            SortedDictionary<string, string> openWith =
                new SortedDictionary<string, string>();

            // Add some elements to the dictionary. There are no 
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");

            // The Add method throws an exception if the new key is 
            // already in the dictionary.
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
            // not in the dictionary.
            try
            {
                Debug.WriteLine($"For key = \"tif\", value = {openWith["tif"]}.");
            }
            catch (KeyNotFoundException)
            {
                Debug.WriteLine("Key = \"tif\" is not found.");
            }

            // When a program often has to try keys that turn out not to
            // be in the dictionary, TryGetValue can be a more efficient 
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

            // When you use foreach to enumerate dictionary elements,
            // the elements are retrieved as KeyValuePair objects.
            Debug.WriteLine("");
            foreach (KeyValuePair<string, string> kvp in openWith)
            {
                Debug.WriteLine($"Key = {kvp.Key}, Value = {kvp.Value}");
            }

            // To get the values alone, use the Values property.
            SortedDictionary<string, string>.ValueCollection valueColl =
                openWith.Values;

            // The elements of the ValueCollection are strongly typed
            // with the type that was specified for dictionary values.
            Debug.WriteLine("");
            foreach (string s in valueColl)
            {
                Debug.WriteLine($"Value = {s}");
            }

            // To get the keys alone, use the Keys property.
            SortedDictionary<string, string>.KeyCollection keyColl =
                openWith.Keys;

            // The elements of the KeyCollection are strongly typed
            // with the type that was specified for dictionary keys.
            Debug.WriteLine("");
            foreach (string s in keyColl)
            {
                Debug.WriteLine($"Key = {s}");
            }

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