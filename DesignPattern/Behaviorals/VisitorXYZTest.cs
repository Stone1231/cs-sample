using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace xyz.Visitor
{
    [TestClass]
    public class VisitorXYZTest
    {
        [TestMethod]
        public void VisitorTest()
        {
            // 物件結構
            ObjectStructure o = new ObjectStructure();
            // 誠實人元素物件
            HonestManElement honestMan = new HonestManElement();
            // 說謊人元素物件
            LieManElement lieMan = new LieManElement();

            // 將誠實人、說謊人元素物件放進物件結構
            o.Attach(honestMan);
            o.Attach(lieMan);


            // 數學問題訪問者
            MathVisitor mathVisitor = new MathVisitor();
            Debug.WriteLine("[數學問題]");
            o.Display(mathVisitor); // 輸出結果

            // 物理問題訪問者
            PhysicsVisitor physicsVisitor = new PhysicsVisitor();
            Debug.WriteLine("[物理問題]");
            o.Display(physicsVisitor); // 輸出結果
        }
    }
}