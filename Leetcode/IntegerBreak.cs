using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Leetcode
{
    /// <summary>
    /// https://leetcode.com/problems/integer-break/description/
    /// Given a positive integer n, break it into the sum of at least two positive integers and maximize the product of those integers. 
    /// Return the maximum product you can get.
    /// </summary>    
    [TestClass]
    public class IntegerBreak
    {
       public long getInt(int n)
        {
            if (n == 2)
                return 1;

            if (n == 3)
                return 2;

            var residue = n % 3;

            if (residue == 0)
                return (long)Math.Pow(3, (n / 3));
            else if (residue == 1)
            {
                var a = (n - 4) / 3;
                return (long)Math.Pow(3, a) * 4;
            }
            else
            {
                var a = (n - 2) / 3;
                return (long)Math.Pow(3, a) * 2;
            }
        }


        [TestMethod]
        public void TestMethod1()
        {
            var max = getInt(10);
            Debug.WriteLine(max);            
        }
    }
}
