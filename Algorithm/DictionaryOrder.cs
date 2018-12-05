using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Algorithm
{
    [TestClass]
    public class DictionaryOrder
    {
        /// <summary>
        /// 取得所有組合
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        private List<string> getList(char[] chars)
        {
            var result = new List<string>();
            try
            {
                Action<string, int> myFunc = null;
                myFunc = (s, i) =>
                {
                    s = s + chars[i];
                    result.Add(s);
                    if (i + 1 < chars.Length)
                    {
                        for (int j = i + 1; j < chars.Length; j++)
                        {
                            myFunc(s, j);
                        }
                    }
                };

                for (int i = 0; i < chars.Length; i++)
                {
                    myFunc("", i);
                }
            }
            catch (Exception ex)
            {
                result.Add(ex.Message);
            }

            return result;
        }


        /// <summary>
        /// 取得固定數量的所有組合(ex: abc,bca算同一組)
        /// </summary>
        /// <param name="count"></param>
        /// <param name="chars"></param>
        /// <returns></returns>
        private List<string> getList(int count, char[] chars)
        {
            var result = new List<string>();
            try
            {
                Action<string, int> myFunc = null;
                myFunc = (s, i) =>
                {
                    s = s + chars[i];
                    if (s.Length == count)
                    {
                        result.Add(s);
                    }
                    else
                    {
                        int _index = i + 1;
                        if (_index < chars.Length)
                        {
                            for (int j = _index; j <= chars.Length - count + s.Length; j++)
                            {
                                myFunc(s, j);
                            }
                        }
                    }
                };

                for (int i = 0; i <= chars.Length - count; i++)
                {
                    myFunc("", i);
                }
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
            var list = getList(new char[] { 'a','b','c','d','e' });
            list.ForEach(item => Debug.WriteLine(item));            
        }

        [TestMethod]
        public void TestMethod2()
        {
            var list = getList(3, new char[] { 'a','b','c','d','e' });
            list.ForEach(item => Debug.WriteLine(item));            
        }        
    }
}
