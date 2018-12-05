using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithm
{
    [TestClass]
    public class Hanoi
    {
        private List<string> getList(int count)
        {
            var result = new List<string>();

            try
            {
                Action<int, string, string, string> myFunc = null;
                myFunc = (n, f, c, t) =>
                {
                    if (n > 1)
                    {
                        myFunc(n - 1, f, t, c);
                        myFunc(1, f, c, t);
                        myFunc(n - 1, c, f, t);
                    }
                    else
                    {
                        result.Add(string.Format("{0} to {1}", f, t));
                    }
                };

                myFunc(count, "A", "B", "C");
            }
            catch (Exception ex)
            {
                result.Add(ex.Message);
            }

            return result;
        }


        [TestMethod]
        public void TestMethod1()
        {
            var list = getList(5);
            list.ForEach(item => Debug.WriteLine(item));            
        }
    }
}
