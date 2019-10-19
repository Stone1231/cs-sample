using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Dsa
{
    [TestClass]
    public class EqualityComparerEx
    {
        Dictionary<Box, String> boxes;

        [TestMethod]
        public void TestMethod1()
        {
            BoxSameDimensions boxDim = new BoxSameDimensions();
            boxes = new Dictionary<Box, string>(boxDim);

            Debug.WriteLine("Boxes equality by dimensions:");

            AddBox(new Box(8, 4, 8), "red");
            AddBox(new Box(8, 6, 8), "green");
            AddBox(new Box(8, 4, 8), "blue");
            AddBox(new Box(8, 8, 8), "yellow");

            BoxSameVolume boxVolume = new BoxSameVolume();
            boxes = new Dictionary<Box, string>(boxVolume);

            Debug.WriteLine("");
            Debug.WriteLine("Boxes equality by volume:");

            AddBox(new Box(8, 4, 8), "pink");
            AddBox(new Box(8, 6, 8), "orange");
            AddBox(new Box(4, 8, 8), "purple");
            AddBox(new Box(8, 8, 4), "brown");
        }

        void AddBox(Box bx, string name)
        {
            try
            {
                boxes.Add(bx, name);
                Debug.WriteLine($"Added {name}, Count = {boxes.Count}, HashCode = {bx.GetHashCode()}");
            }
            catch (ArgumentException)
            {
                Debug.WriteLine($"A box equal to {name} is already in the collection.");
            }
        }
    }

    public class Box
    {
        public Box(int h, int l, int w)
        {
            this.Height = h;
            this.Length = l;
            this.Width = w;
        }
        public int Height { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
    }

    class BoxSameDimensions : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null)
                return true;
            else if (b1 == null || b2 == null)
                return false;

            return (b1.Height == b2.Height &&
                    b1.Length == b2.Length &&
                    b1.Width == b2.Width);
        }

        public override int GetHashCode(Box bx)
        {
            int hCode = bx.Height ^ bx.Length ^ bx.Width;
            return hCode.GetHashCode();
        }
    }

    class BoxSameVolume : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2)
        {
            if (b1 == null && b2 == null)
                return true;
            else if (b1 == null || b2 == null)
                return false;

            return (b1.Height * b1.Width * b1.Length ==
                    b2.Height * b2.Width * b2.Length);
        }

        public override int GetHashCode(Box bx)
        {
            int hCode = bx.Height * bx.Length * bx.Width;
            return hCode.GetHashCode();
        }
    }
}