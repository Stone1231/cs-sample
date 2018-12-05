using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithm
{
    [TestClass]
    public class QuickSort
    {
        private int[] getList(int[] nums)
        {
            int[] result = null;

            try
            {
                Func<int, int, int> ascending = (a, b) =>
                {
                    return a - b;
                };

                Func<int, int, int> descending = (a, b) =>
                {
                    return b - a;
                };

                Action<int[], int, int> swap = (list, a, b) =>
                {
                    int temp = list[a];
                    list[a] = list[b];
                    list[b] = temp;
                };


                //cor
                Func<int[], int, int, int, Func<int, int, int>, int> partitionUnprocessed = null;
                partitionUnprocessed = (list, val, left, right, sort) =>
                {
                    int _left = left;
                    while (_left <= right && sort(val, list[_left]) >= 0)//care
                    {
                        _left++;
                    }

                    int _right = right;
                    while (_right >= _left && sort(val, list[_right]) < 0)//care
                    {
                        _right--;
                    }

                    if (_left < _right)
                    {
                        swap(list, _left, _right);
                        return partitionUnprocessed(list, val, _left + 1, _right - 1, sort);
                    }

                    return _right;
                };

                Func<int[], int, int, Func<int, int, int>, int> getAxis = null;
                //取最左邊的當比較對象,再換到正確的位置,並回傳正確位置的index
                getAxis = (list, left, right, sort) =>
                {
                    var val = list[left];//比較對象

                    var axis = partitionUnprocessed(list, val, left + 1, right, sort);
                    swap(list, left, axis);

                    return axis;
                };

                Action<int[], int, int, Func<int, int, int>> quick = null;
                quick = (list, left, right, sort) =>
                {
                    if (left < right)//care!!
                    {
                        var axis = getAxis(list, left, right, sort);

                        //位置axis資料已經正確,不用再處理
                        quick(list, left, axis - 1, sort);
                        quick(list, axis + 1, right, sort);
                    }
                };

                result = nums;
                quick(result, 0, nums.Length - 1, ascending);
                return result;
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
