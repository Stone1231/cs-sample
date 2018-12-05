using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace wiki.Bridge
{
    /** "Implementor" */
    interface IDrawingAPI
    {
        void DrawCircle(double x, double y, double radius);
    }

    /** "ConcreteImplementor" 1/2 */
    class DrawingAPI1 : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Debug.WriteLine("API1.circle at {0}:{1} radius {2}", x, y, radius);
        }
    }

    /** "ConcreteImplementor" 2/2 */
    class DrawingAPI2 : IDrawingAPI
    {
        public void DrawCircle(double x, double y, double radius)
        {
            Debug.WriteLine("API2.circle at {0}:{1} radius {2}", x, y, radius);
        }
    }

    /** "Abstraction" */
    interface IShape
    {
        void Draw();                             // low-level (i.e. Implementation-specific)
        void ResizeByPercentage(double pct);     // high-level (i.e. Abstraction-specific)
    }

    /** "Refined Abstraction" */
    class CircleShape : IShape
    {
        private double x, y, radius;
        private IDrawingAPI drawingAPI;
        public CircleShape(double x, double y, double radius, IDrawingAPI drawingAPI)
        {
            this.x = x; this.y = y; this.radius = radius;
            this.drawingAPI = drawingAPI;
        }
        // low-level (i.e. Implementation-specific)
        public void Draw() { drawingAPI.DrawCircle(x, y, radius); }
        // high-level (i.e. Abstraction-specific)
        public void ResizeByPercentage(double pct) { radius *= pct; }
    }
}