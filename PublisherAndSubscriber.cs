using System;

//发布者
class Publisher {
    public event Dele Delevent;

    public delegate void Dele(string pic);

    public void TouchOff() {
        //触发事件
        Delevent("Deis");
    }
}

//订阅者
class Subscriber {
    public Subscriber(Publisher pub) {
        //订阅事件
        pub.Delevent += Events;
    }

    //事件处理程序，修饰要和委托匹配。
    void Events(string picture) {
        Console.WriteLine(picture);
    }

}

//Design Patterns
//发布-订阅模式
class PublisherAndSubscriber {

    void Main() {
        Publisher pub = new Publisher();
        Subscriber sub = new Subscriber(pub);

        //事件触发
        pub.TouchOff();
    }
}
