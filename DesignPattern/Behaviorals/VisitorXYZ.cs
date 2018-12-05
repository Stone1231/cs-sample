using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace xyz.Visitor
{
    // 物件結構
    class ObjectStructure
    {
        private List<Element> elements = new List<Element>();

        //增加元素物件
        public void Attach(Element element)
        {
            elements.Add(element);
        }

        //移除元素物件
        public void Detach(Element element)
        {
            elements.Remove(element);
        }

        //顯示
        public void Display(Visitor visitor)
        {
            foreach (Element e in elements)
            {
                e.Accept(visitor);
            }
        }
    }

    // 元素抽像類別 (要放入物件結構中) 
    abstract class Element
    {
        // 每個元素要能接收訪問者物件，以便再將自己傳給訪問者
        public abstract void Accept(Visitor visitor);
    }

    // 誠實人元素物件
    class HonestManElement : Element
    {
        public string name = "誠實人";
        public override void Accept(Visitor visitor)
        {
            // 將自己傳給訪問者，以便訪問者分辨、執行適合自己的行為
            visitor.visit(this);
        }
    }

    // 說謊人元素物件
    class LieManElement : Element
    {
        public string name = "說謊人";
        public override void Accept(Visitor visitor)
        {
            // 將自己傳給訪問者，以便訪問者分辨、執行適合自己的行為
            visitor.visit(this);
        }
    }


    // 訪問者 (能根據不同元素，產生不同結果)
    abstract class Visitor
    {
        // 訪問誠實人的多載方法
        public abstract void visit(HonestManElement honestElement);

        // 訪問說謊人的多載方法
        public abstract void visit(LieManElement lieElement);
    }

    // 數學問題訪問者
    class MathVisitor : Visitor
    {
        // 訪問誠實人的多載方法
        public override void visit(HonestManElement honestElement)
        {
            Debug.WriteLine($"{honestElement.name} 說: 1+1=2");
        }

        // 訪問說謊人的多載方法
        public override void visit(LieManElement lieElement)
        {
            Debug.WriteLine($"{lieElement.name} 說: 1+1=3");
        }
    }

    // 物理問題訪問者
    class PhysicsVisitor : Visitor
    {
        // 訪問誠實人的多載方法
        public override void visit(HonestManElement honestElement)
        {
            Debug.WriteLine($"{honestElement.name} 說: 鐵球在水中會沉下去");
        }

        // 訪問說謊人的多載方法
        public override void visit(LieManElement lieElement)
        {
            Debug.WriteLine($"{lieElement.name} 說: 鐵球在水中會浮起來");
        }
    }
}