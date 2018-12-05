using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Leetcode
{
    /// <summary>
    /// https://leetcode.com/problems/search-for-a-range/description/
    /// </summary>    
    [TestClass]
    public class SearchRange
    {
        /// <summary>
        /// copy from BinarySearchController
        /// </summary>
        /// <param name="target"></param>
        /// <param name="nums"></param>
        /// <returns></returns>        
        private int[] getList(int target, int[] nums)
        {
            int[] result = null;

            try
            {
                Func<int, int, (int s_index, int e_index)> myFunc = null;
                myFunc = (start, end) =>
                {
                    if (start > end)
                    {
                        return (-1, -1);
                    }

                    var mid = start + Convert.ToInt16(Math.Ceiling((decimal)(end - start) / 2));
                    var current = nums[mid];
                    if (current == target)
                    {
                        var s_index = mid;
                        for (var i = mid; i >= 0; i--)
                        {
                            if (nums[i] == target)
                            {
                                s_index = i;
                            }
                        }

                        var e_index = mid;
                        for (var i = mid; i < nums.Length; i++)
                        {
                            if (nums[i] == target)
                            {
                                e_index = i;
                            }
                        }

                        return (s_index, e_index);
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

                var t = myFunc(0, nums.Length - 1);
                result = new int[] { t.s_index, t.e_index };

            }
            catch (Exception ex)
            {
            }

            return result;
        }


        [TestMethod]
        public void TestMethod1()
        {
            var list = getList(5, new int[] { 1, 5, 3, 4, 5, 6, 7, 5, 9 });
            foreach (var item in list)
            {
                Debug.WriteLine(item);
            }
        }
    }
}
