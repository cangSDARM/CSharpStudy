using System;

//委托可以写类外面
//声明一个委托指向一个函数
//所指向的函数必须和委托有相同的修饰
delegate void DelSay(string name);

class Commissioned_Anonymous_Lamda {

    //event相当于属性, delegate相当于字段
    //  event限制delegate无法直接new，防止将委托替换
    //  event限制delegate只能在其定义的类中被调用
    public event DelSay del;
    
    void se() {
        del = new DelSay(main);

    }

    void main(string arg) {

        /*
         * 第一种
         * DelSay del = SayHi;     
         *      //第二种声明：new DelSay(SayHi);
         *      
         *      //匿名函数
         *      //第三种声明：delegate(string name){
         *                      Console.WriteLine("Hi" + name);
         *                  };
         *      
         *      //lamda表达式
         *      //第四种声明：(string name)=>{Console.WriteLine("Hi" + name);};
         * del("zhangsan");
        */

        /*
         * 第二种
         * Test("zhangsan", SayHi);
        */

        /*
         * 第三种，使用匿名函数
         * Test("zhangsan", delegate(string name){
         *    Console.WriteLine("Hi" + name)
         * });
         */
    }


    //static void Test(string name, DelSay del) {
    //    del(name);
    //}

    //泛型委托
    //delegate T Dele<T>(T t1);
    //static void Test<T>(T name, DelSay del) {

    //}

    //static void SayHi(string name) {
    //    Console.WriteLine("Hi" + name);
    //}
    //static void SayNo(string name) {
    //    Console.WriteLine("No" + name);
    //}
}
