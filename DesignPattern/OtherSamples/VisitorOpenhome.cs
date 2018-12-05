using System.Diagnostics;
using System;
using System.Threading;

namespace openhome.Visitor
{
interface Visitable {
    void accept(Visitor visitor);
}

interface Visitor {
    void visit(Member member);
    void visit(VIP vip);
}

class Customer : Visitable {
    public void doCustomer() {
        Debug.WriteLine("客戶服務");
    }
    public void pay() {
        Debug.WriteLine("結帳");
    }
    public void accept(Visitor visitor) {
        // nothing to do
    }    
}

class Member : Customer {
    public void doMember() {
        Debug.WriteLine("會員服務");
    }
    public void accept(Visitor visitor) {
        visitor.visit(this); // 看似多型，其實是 overload
    }    
}
    
class VIP : Customer {
    public void doVIP() {
        Debug.WriteLine("VIP 服務");
    }

    public void accept(Visitor visitor) {
        visitor.visit(this); // 看似多型，其實是 overload
    }    
}

class VisitorImpl : Visitor {
    public void visit(Member member) {
        member.doMember();
    }
    public void visit(VIP vip) {
        vip.doVIP();
    }
}

class Service {
    private Visitor visitor = new VisitorImpl();
    public void doService(Customer customer) {
        customer.doCustomer();
        ((Visitable) customer).accept(visitor);
        customer.pay();
    }
}
}