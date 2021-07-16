using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGrammarInfo.SharpNine
{
   public static class SharpNineInfo
    {
        public static void Show()
        {
            //1.记录
            #region Record
            //C# 9.0 引入了记录类型。 可使用 record 关键字定义一个引用类型，用来提供用于封装数据的内置功能。
            //记录类型提供如下功能：
            //1. 用于创建育有不可变属性的引用类型的简明语法
            //2. 欣慰对于以数据为中心的引用类型非常有用：
            //a.值相等性
            //b.非破坏性变化的简明语法
            //c.用于显示的内置格式设置
            //3.支持继承层次结构
            //记录可以继承记录但是不能和类相互继承
            //可以创建具有不可变属性的记录类型：
            var person = new Person("kulala", "TOm");
            //还可以创建具有可变属性和字段的记录类型
            var person1 = new Person1() { FirstName = "kulala", LastName = "TOm"};
            person1.LastName = "Gao";
            Console.WriteLine(person1.LastName);

            Person2 teacher = new Teacher("Nancy", "Davolio", 3);
            Console.WriteLine(teacher);
            #endregion
            //2.仅限 Init 的资源库
            //从 C# 9.0 开始，可为属性和索引器创建 init 访问器，而不是 set 访问器。 调用方可使用属性初始化表达式语法在创建表达式中设置这些值，但构造完成后，这些属性将变为只读
            #region init
            var initTest = new WeatherObservation() { RecordedAt = DateTime.Now,TemperatureInCelsius = 12, PressureInMillibars=12 };

            //initTest.RecordedAt = DateTime.Now;//error：只能在初始化设定项或构造函数中初始化。
            #endregion
            //3.顶级语句
            //顶级语句从许多应用程序中删除了不必要的流程。 请考虑规范的“Hello World!” 程序
            //using System;

            //Console.WriteLine("Hello World!");

            //4.模式匹配增强功能
            #region 模式匹配增强功能
            //类型模式要求在变量是一种类型时匹配
            //带圆括号的模式强制或强调模式组合的优先级
            //联合and模式要求两个模式都匹配
            //析取or模式要求任意模式匹配
            //否定not模式要求模式不匹配
            //关系模式要求输入小于、大于、小于等于、大于等于给定常数
            //这些模式都可以在is和switch中使用

            static bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';
            static bool IsLetterOrSeperator(char c) => c is (>= 'a' and <= 'z') or (>= 'A' and <= 'Z') or '.' or ',';
            int? e = null;
            if (e is not null)
            {
                
            }

            #endregion
            //5.本机大小的整数
            //nint, unint

            //6.函数指针
            //7.禁止发出 localsinit 标志
            //8.目标类型的新表达式
            List<string> dataCollection = new();


            //9.静态匿名函数
            //从 C# 9.0 开始，可以将 static 修饰符应用于 lambda 表达式，以防止由 lambda 无意中捕获本地变量或实例状态
            //静态 lambda 无法从封闭范围中捕获本地变量或实例状态，但可以引用静态成员和常量定义。
            Func<int, int> square = static x => x * x;


            //10.目标类型的条件表达式
            //11.协变返回类型
            //12.扩展 GetEnumerator 支持 foreach 循环


            //13.Lambda 弃元参数
            //可以使用弃元指定 lambda 表达式中不使用的两个或更多输入参数
            Func<int, int, int> constant = (_, _) => 423;


            //14.本地函数的属性
            //15.模块初始值设定项
            //16.分部方法的新功能
        }
    }

    public struct WeatherObservation
    {
        public DateTime RecordedAt { get; init; }
        public decimal TemperatureInCelsius { get; init; }
        public decimal PressureInMillibars { get; init; }

        public override string ToString() =>
            $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
            $"Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure";
    }

    public record Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public Person(string FirstName, string LastName) => (this.FirstName, this.LastName) = (FirstName, LastName);
    }

    public abstract record Person2(string FirstName, string LastName);
    public record Teacher(string FirstName, string LastName, int Grade)
        : Person2(FirstName, LastName);

    public record Person1
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    };
}
