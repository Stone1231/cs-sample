using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class SortedSetEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                // Get a list of the files to use for the sorted set.
                IEnumerable<string> files1 =new string[]{
                    "a.doc",
                    "b.docx",
                    "c.avi",
                    "d.jpg"};

                // Create a sorted set using the ByFileExtension comparer.
                var mediaFiles1 = new SortedSet<string>(new ByFileExtension());

                // Note that there is a SortedSet constructor that takes an IEnumerable,
                // but to remove the path information they must be added individually.
                foreach (string f in files1)
                {
                    mediaFiles1.Add(f.Substring(f.LastIndexOf(@"\") + 1));
                }

                // Remove elements that have non-media extensions.
                // See the 'IsDoc' method.
                Debug.WriteLine("Remove docs from the set...");
                Debug.WriteLine($"\tCount before: {mediaFiles1.Count}");
                mediaFiles1.RemoveWhere(IsDoc);
                Debug.WriteLine($"\tCount after: {mediaFiles1.Count}");


                Debug.WriteLine("");

                // List all the avi files.
                SortedSet<string> aviFiles = mediaFiles1.GetViewBetween("avi", "avj");

                Debug.WriteLine("AVI files:");
                foreach (string avi in aviFiles)
                {
                    Debug.WriteLine($"\t{avi}");
                }

                Debug.WriteLine("");

                // Create another sorted set.
                IEnumerable<string> files2 =new string[]{
                    "a.avi",
                    "b.avi",
                    "c.avi"};                                

                var mediaFiles2 = new SortedSet<string>(new ByFileExtension());

                foreach (string f in files2)
                {
                    mediaFiles2.Add(f.Substring(f.LastIndexOf(@"\") + 1));
                }

                // Remove elements in mediaFiles1 that are also in mediaFiles2.
                Debug.WriteLine("Remove duplicates (of mediaFiles2) from the set...");
                Debug.WriteLine($"\tCount before: {mediaFiles1.Count}");
                mediaFiles1.ExceptWith(mediaFiles2);
                Debug.WriteLine($"\tCount after: {mediaFiles1.Count}");

                Debug.WriteLine("");

                Debug.WriteLine("List of mediaFiles1:");
                foreach (string f in mediaFiles1)
                {
                    Debug.WriteLine($"\t{f}");
                }

                // Create a set of the sets.
                IEqualityComparer<SortedSet<string>> comparer =
                    SortedSet<string>.CreateSetComparer();

                var allMedia = new HashSet<SortedSet<string>>(comparer);
                allMedia.Add(mediaFiles1);
                allMedia.Add(mediaFiles2);
            }
            catch (IOException ioEx)
            {
                Debug.WriteLine(ioEx.Message);
            }

            catch (UnauthorizedAccessException AuthEx)
            {
                Debug.WriteLine(AuthEx.Message);

            }
        }

        bool IsDoc(string s)
        {
            s = s.ToLower();
            return (s.EndsWith(".txt") ||
                s.EndsWith(".xls") ||
                s.EndsWith(".xlsx") ||
                s.EndsWith(".pdf") ||
                s.EndsWith(".doc") ||
                s.EndsWith(".docx"));
        }
    }

    class ByFileExtension : IComparer<string>
    {
        string xExt, yExt;

        CaseInsensitiveComparer caseiComp = new CaseInsensitiveComparer();

        public int Compare(string x, string y)
        {
            // Parse the extension from the file name. 
            xExt = x.Substring(x.LastIndexOf(".") + 1);
            yExt = y.Substring(y.LastIndexOf(".") + 1);

            // Compare the file extensions. 
            int vExt = caseiComp.Compare(xExt, yExt);
            if (vExt != 0)
            {
                return vExt;
            }
            else
            {
                // The extension is the same, 
                // so compare the filenames. 
                return caseiComp.Compare(x, y);
            }
        }
    }
}