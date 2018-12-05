using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace wiki.Proxy
{
    interface IImage
    {
        void Display();
    }

    class RealImage : IImage
    {
        public RealImage(string fileName)
        {
            FileName = fileName;
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            Debug.WriteLine("Loading " + FileName);
        }

        public String FileName { get; private set; }

        public void Display()
        {
            Debug.WriteLine("Displaying " + FileName);
        }
    }

    class ProxyImage : IImage
    {
        public ProxyImage(string fileName)
        {
            FileName = fileName;
        }

        public String FileName { get; private set; }

        private IImage image;

        public void Display()
        {
            if (image == null)
                image = new RealImage(FileName);
            image.Display();
        }
    }
}