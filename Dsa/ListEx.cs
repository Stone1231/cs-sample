using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class ListEx
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Create a list of parts.
            List<Part> parts = new List<Part>{
                new Part() { PartName = "crank arm", PartId = 1234 },
                new Part() { PartName = "chain ring", PartId = 1334 },
                new Part() { PartName = "regular seat", PartId = 1434 }
            };

            // Add parts to the list.
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 });

            // Write out the parts in the list. This will call the overridden ToString method
            // in the Part class.
            Debug.WriteLine("");
            foreach (Part aPart in parts)
            {
                Debug.WriteLine(aPart);
            }

            // Check the list for part #1734. This calls the IEquatable.Equals method
            // of the Part class, which checks the PartId for equality.
            Debug.WriteLine("\nContains(\"1734\"): {0}",
            parts.Contains(new Part { PartId = 1734, PartName = "" }));

            // Insert a new item at position 2.
            Debug.WriteLine("\nInsert(2, \"1834\")");
            parts.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });


            //Debug.WriteLine();
            foreach (Part aPart in parts)
            {
                Debug.WriteLine(aPart);
            }

            Debug.WriteLine("\nParts[3]: {0}", parts[3]);

            Debug.WriteLine("\nRemove(\"1534\")");

            // This will remove part 1534 even though the PartName is different,
            // because the Equals method only checks PartId for equality.
            parts.Remove(new Part() { PartId = 1534, PartName = "cogs" });

            Debug.WriteLine("");
            foreach (Part aPart in parts)
            {
                Debug.WriteLine(aPart);
            }
            Debug.WriteLine("\nRemoveAt(3)");
            // This will remove the part at index 3.
            parts.RemoveAt(3);

            Debug.WriteLine("");
            foreach (Part aPart in parts)
            {
                Debug.WriteLine(aPart);
            }

        }
    }
    class Part : IEquatable<Part>
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Part objAsPart = obj as Part;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }
        public override int GetHashCode()
        {
            return PartId;
        }
        public bool Equals(Part other)
        {
            if (other == null) return false;
            return (this.PartId.Equals(other.PartId));
        }
        // Should also override == and != operators.

    }
}