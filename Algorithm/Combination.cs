using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithm
{
    [TestClass]
    public class Combination
    {
        private List<string> getList(int count, List<char> chars)
        {
            var result = new List<string>();

            try
            {
                Action<string, string> myFunc = null;
                myFunc = (s, c) =>
                {
                    s = s + c;
                    if (s.Length == count)
                    {
                        result.Add(s);
                    }
                    else
                    {
                        for (int i = 0; i < chars.Count; i++)
                        {
                            myFunc(s, chars[i].ToString());
                        }
                    }
                };

                myFunc("", "");
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
            var list = getList(2, new List<char> { 'a','b','c','d','e' });
            list.ForEach(item => Debug.WriteLine(item));            
        }
    }
}
