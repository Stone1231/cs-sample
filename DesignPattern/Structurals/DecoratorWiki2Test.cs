using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace wiki.Decorator
{
    [TestClass]
    public class DecoratorWiki2Test
    {
        [TestMethod]
        public void DecoratorTest()
        {
            Coffee c = new SimpleCoffee();
            printInfo(c);

            c = new WithMilk(c);
            printInfo(c);

            c = new WithSprinkles(c);
            printInfo(c);
        }

        public static void printInfo(Coffee c)
        {
            Debug.WriteLine("Cost: " + c.getCost() + "; Ingredients: " + c.getIngredients());
        }
    }
}