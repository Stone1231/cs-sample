using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace wiki.Decorator
{
    // The abstract class Coffee defines the functionality of Coffee implemented by decorator
    public abstract class Coffee
    {
        public abstract double getCost(); // Returns the cost of the coffee
        public abstract String getIngredients(); // Returns the ingredients of the coffee
    }

    // Extension of a simple coffee without any extra ingredients
    public class SimpleCoffee : Coffee
    {
        public override double getCost()
        {
            return 1;
        }

        public override String getIngredients()
        {
            return "Coffee";
        }
    }

    // Abstract decorator class - note that it implements Coffee interface
    public abstract class CoffeeDecorator : Coffee
    {
        protected readonly Coffee decoratedCoffee;

        public CoffeeDecorator(Coffee c)
        {
            this.decoratedCoffee = c;
        }

        public override double getCost()
        { // Implementing methods of the interface
            return decoratedCoffee.getCost();
        }

        public override String getIngredients()
        {
            return decoratedCoffee.getIngredients();
        }
    }

    // Decorator WithMilk mixes milk into coffee.
    // Note it extends CoffeeDecorator.
    class WithMilk : CoffeeDecorator
    {
        public WithMilk(Coffee c) : base(c)
        {
            //super(c);
        }

        public override double getCost()
        { // Overriding methods defined in the abstract superclass
            return base.getCost() + 0.5;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ", Milk";
        }
    }

    // Decorator WithSprinkles mixes sprinkles onto coffee.
    // Note it extends CoffeeDecorator.
    class WithSprinkles : CoffeeDecorator
    {
        public WithSprinkles(Coffee c) : base(c)
        {
            //super(c);
        }

        public override double getCost()
        {
            return base.getCost() + 0.2;
        }

        public override String getIngredients()
        {
            return base.getIngredients() + ", Sprinkles";
        }
    }
}