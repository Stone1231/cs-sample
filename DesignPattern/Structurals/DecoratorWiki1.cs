using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace wiki.Decorator
{
    // The Window interface class
    public abstract class Window
    {
        public abstract void draw(); // Draws the Window
        public abstract String getDescription(); // Returns a description of the Window
    }

    // Implementation of a simple Window without any scrollbars
    class SimpleWindow : Window
    {
        public override void draw()
        {
            // Draw window
        }
        public override String getDescription()
        {
            return "simple window";
        }
    }

    // abstract decorator class - note that it implements Window
    abstract class WindowDecorator : Window
    {
        protected Window windowToBeDecorated; // the Window being decorated

        public WindowDecorator(Window windowToBeDecorated)
        {
            this.windowToBeDecorated = windowToBeDecorated;
        }

        public override void draw()
        {
            windowToBeDecorated.draw(); //Delegation
        }

        public override String getDescription()
        {
            return windowToBeDecorated.getDescription(); //Delegation            
        }
    }

    // The first concrete decorator which adds vertical scrollbar functionality
    class VerticalScrollBarDecorator : WindowDecorator
    {
        public VerticalScrollBarDecorator(Window windowToBeDecorated): base(windowToBeDecorated)
        {
        }

        public override void draw()
        {
            base.draw();
            drawVerticalScrollBar();
        }

        private void drawVerticalScrollBar()
        {
            // Draw the vertical scrollbar
        }

        public override String getDescription()
        {
            return base.getDescription() + ", including vertical scrollbars";
        }
    }

    // The second concrete decorator which adds horizontal scrollbar functionality
    class HorizontalScrollBarDecorator : WindowDecorator
    {
        public HorizontalScrollBarDecorator(Window windowToBeDecorated) : base(windowToBeDecorated)
        {
        }

        public override void draw()
        {
            base.draw();
            drawHorizontalScrollBar();
        }

        private void drawHorizontalScrollBar()
        {
            // Draw the horizontal scrollbar
        }

        public override String getDescription()
        {
            return base.getDescription() + ", including horizontal scrollbars";
        }
    }
}