using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.Builder
{
    [TestClass]
    public class BuilderWikiTest
    {
        [TestMethod]
        public void BuilderTest()
        {
            var builder = new FerrariBuilder();
            var director = new SportsCarBuildDirector(builder);
            
            director.Construct();
            Car myRaceCar = builder.GetResult();   
            Debug.WriteLine($"Colour:{myRaceCar.Colour} Make:{myRaceCar.Make} Model:{myRaceCar.Model} NumDoors:{myRaceCar.NumDoors}");
        }
    }
}