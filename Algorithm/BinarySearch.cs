using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithm
{
    [TestClass]
    public class BinarySearch
    {
        private int getIdx(int target, int[] nums)
        {
            int result = 0;

            try
            {
                Func<int, int, int> myFunc = null;
                myFunc = (start, end) =>
                {
                    if (start > end)
                    {
                        return -1;
                    }

                    var mid = start + Convert.ToInt16(Math.Ceiling((decimal)(end - start) / 2));
                    var current = nums[mid];
                    if (current == target)
                    {
                        return mid;
                    }
                    else if (current > target)
                    {
                        return myFunc(start, mid - 1);
                    }
                    else
                    {
                        return myFunc(mid + 1, end);
                    }
                };

                result = myFunc(0, nums.Length - 1);

            }
            catch (Exception ex)
            {
            }

            return result;
        }

        [TestMethod]
        public void TestMethod1()
        {
            Debug.WriteLine(getIdx(7, new int[] { 1, 2, 3, 6, 7, 9}));
        }
    }
}
