using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithm
{
    [TestClass]
    public class SelectionSort
    {
        private int[] getList(int[] ints)
        {
            int[] result = null;

            try
            {
                var slist = new int[ints.Length];

                for (int i = 0; i < ints.Length; i++)
                {
                    slist[i] = ints[i];
                    for (int j = i; j > 0; j--)
                    {
                        if (slist[j] < slist[j - 1])
                        {
                            int temp = slist[j];
                            slist[j] = slist[j - 1];
                            slist[j - 1] = temp;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                result = slist;
            }
            catch (Exception ex)
            {

            }

            return result;
        }


        [TestMethod]
        public void TestMethod1()
        {
            var list = getList(new int[] { 3, 7, 1, 5, 9, 4 });
            foreach (var item in list)
            {
                Debug.WriteLine(item);
            }         
        }
    }
}
