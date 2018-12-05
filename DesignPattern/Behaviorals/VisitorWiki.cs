using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace wiki.Visitor
{
    interface CarElement
    {
        void accept(CarElementVisitor visitor);
    }

    interface CarElementVisitor
    {
        void visit(Body body);
        void visit(Car car);
        void visit(Engine engine);
        void visit(Wheel wheel);
    }

    class Car : CarElement
    {
        CarElement[] elements;

        public Car()
        {
            this.elements = new CarElement[] {
            new Wheel("front left"), new Wheel("front right"),
            new Wheel("back left"), new Wheel("back right"),
            new Body(), new Engine()
        };
        }

        public void accept(CarElementVisitor visitor)
        {
            foreach (CarElement elem in elements)
            {
                elem.accept(visitor);
            }
            visitor.visit(this);
        }
    }

    class Body : CarElement
    {
        public void accept(CarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Engine : CarElement
    {
        public void accept(CarElementVisitor visitor)
        {
            visitor.visit(this);
        }
    }

    class Wheel : CarElement
    {
        private String name;

        public Wheel(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return name;
        }

        public void accept(CarElementVisitor visitor)
        {
            /*
             * accept(CarElementVisitor) in Wheel implements
             * accept(CarElementVisitor) in CarElement, so the call
             * to accept is bound at run time. This can be considered
             * the *first* dispatch. However, the decision to call
             * visit(Wheel) (as opposed to visit(Engine) etc.) can be
             * made during compile time since 'this' is known at compile
             * time to be a Wheel. Moreover, each implementation of
             * CarElementVisitor implements the visit(Wheel), which is
             * another decision that is made at run time. This can be
             * considered the *second* dispatch.
             */
            visitor.visit(this);
        }
    }

    class CarElementDoVisitor : CarElementVisitor
    {
        public void visit(Body body)
        {
            Debug.WriteLine("Moving my body");
        }

        public void visit(Car car)
        {
            Debug.WriteLine("Starting my car");
        }

        public void visit(Wheel wheel)
        {
            Debug.WriteLine("Kicking my " + wheel.getName() + " wheel");
        }

        public void visit(Engine engine)
        {
            Debug.WriteLine("Starting my engine");
        }
    }

    class CarElementPrintVisitor : CarElementVisitor
    {
        public void visit(Body body)
        {
            Debug.WriteLine("Visiting body");
        }

        public void visit(Car car)
        {
            Debug.WriteLine("Visiting car");
        }

        public void visit(Engine engine)
        {
            Debug.WriteLine("Visiting engine");
        }

        public void visit(Wheel wheel)
        {
            Debug.WriteLine("Visiting " + wheel.getName() + " wheel");
        }
    }
}