using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithm
{
    [TestClass]
    public class IntTake
    {
        /// <summary>
        /// 列出所有加總等於輸入數值的組合
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>        
        private List<string> getList(int current)
        {
            var totalLists = new List<List<int>>();

            Action<int, List<int>, int> myFunc = null;
            myFunc = (num, sumList, sum) =>
            {
                int quotient = sum / 2;

                for (int i = num; i <= quotient; i++)
                {
                    if(sum - i >= num)
                    {
                        var _sumList = new List<int>(sumList);
                        _sumList.Add(i);
                        _sumList.Add(sum - i);
                        totalLists.Add(_sumList);

                        if (sum - i >= num)
                        {
                            var _newList = new List<int>(sumList);
                            _newList.Add(i);
                            myFunc(i, _newList, sum - i);
                        }
                    }
                }                
            };

            myFunc(1, new List<int>(), current);

            var result = new List<string>();

            foreach (List<int> numbers in totalLists)
            {
                result.Add(String.Join("+", numbers));
            }

            return result;
        }


        [TestMethod]
        public void TestMethod1()
        {
            var list = getList(8);
            list.ForEach(item => Debug.WriteLine(item));            
        }
    }
}
