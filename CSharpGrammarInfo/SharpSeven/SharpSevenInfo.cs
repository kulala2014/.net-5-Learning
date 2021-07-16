using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSharpGrammarInfo.SharpSeven
{
    public static class SharpSevenInfo
    {
        public static void Show()
        {
            #region out变量
            //在C# 7以前，我们在使用out变量时，必须提前定义out变量。
            //string name;  getName(out name);
            //现在可以在调用的参数列表中声明out 变量
            string input = "23";
            if (int.TryParse(input, out int result))
            {
                Console.WriteLine(result);
            }
            else
                Console.WriteLine("could not parse input");

            //包含字段初始值设定项、属性初始值设定项、构造函数初始值设定项和查询子句
            var d = new D(1);
            #endregion

            #region 元组和弃元
            //.net 4.0中其实已经引入了tuple元组，因为效率低下且不具有语言支持。
            //C#7重新设计元组：元组是包含多个字段以表示数据成员的轻量级数据结构。
            (string Alpha, string Beta) namedLetters = ("a", "b");
            Console.WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");

            var alphabetStart = (Alpha: "a", Beta: "b");
            Console.WriteLine($"{alphabetStart.Alpha}, {alphabetStart.Beta}");

            int[] numbers = new int[2] { 1, 2 };
            //结构方法返回的元组，
            (int max, int min) = Range(numbers);
            Console.WriteLine(max);
            Console.WriteLine(min);
            (int, int) Range(int[] numbers)
            {
                return (1, 2);
            }
            //编写 Deconstruct 方法，用作类的成员
            var point = new Point(2.1, 3.5);
            (double X, double Y) = point;
            Console.WriteLine($"Deconstruct: {X}, {Y}");

            int count = 5;
            string label = "color used in the map";
            var pair = (count, label);
            Console.WriteLine($"{pair.count}, {pair.label}");

            //弃元:在进行元组解构或者out参数调用方法时，必须定义一个其值无关紧要且我们不打算使用的变量。
            //为此，C#增添了弃元_（下划线字符）的致谢变量弃元类似于为负值的变量
            //一下方案中支持弃元
            //1.在对元组或者用户定义的类型进行解构时。
            //2.在使用out参数调用方法时
            //3.在使用is和switch语句匹配惭怍的模式时
            //4.在要将某复制的值显示表示为弃元时用做独立标识符
            (_, int number, _) = QueryCityData("New York City");
            Console.WriteLine(number);
            #endregion


            #region 模式匹配
            //模式匹配是一组功能，可以通过新的方式在代码中表示控制流。
            //模式匹配支持is 和switch表达式，每个表达式都允许检查对象及其属性以确定该对象是否满足所寻求的模式。
            //使用when关键字来指定模式的其他规则
            //is: 可以针对值类型和引用类型进行测试，并且可以将成功结果分配给类型正确的新变量。
            int inputData = 1234;
            int sum = default;
            if (inputData is int countData)
                sum += countData;
            Console.WriteLine($"sum: {sum}");


            //switch语句右几个新构造：
            //1.switch表达式的控制类型不再局限于int, enum, string或这些类型.现在可以使用任何类型
            //2.可以在每个case标签中测试switch表达式的类型，于is表达式一样，可以为该类型指定一个新变量
            //3.可以添加when 字句 进一步测试该变量的条件
            //4.case标签的顺序现在很重要，执行匹配的第一个分支，其他将跳过
            //

            var data = new List<object>
            {
                0,
                new List<int> { 0,1,2,3,4,5},
                100,
                //null
            };
            var sumResult = SumPositiveNumbers(data);
            Console.WriteLine(sumResult);
            #endregion

            #region 更多的表达式体成员
            //表达式构造函数
            //class ExpressionMembersExample
            //{

            //    public ExpressionMembersExample(string label) => this.label = label;
            //    private string label;

            //Expression-bodied get / set accessors
            //    public string Lable
            //    {
            //        get => label;
            //        set => this.label = value ?? "default label";
            //    }
            //    ~ExpressionMembersExample() => Console.Error.WriteLine("Finalized");
            //}
            #endregion

            #region 默认文本表达式
            //默认文本表达式是针对默认值表达式的一项增强功能。 这些表达式将变量初始化为默认值
            string test = default; //null
            int testInt = default; //0
            Func<string, bool> whereClause = default(Func<string, bool>);//null
            #endregion

            #region throw表达式
            //以前的版本中throw始终是一个语句无法出现在表达式中，c#7以后我们可以在表达式中使用throw语句
            DisplayFistNumber(new string[] { "12"});

            DateTime ToDateTime(IFormatProvider provider) =>
            throw new InvalidCastException("Conversion to a DateTime is not supported.");
            #endregion


            #region 数字文本语法改进
            //通过引入 _ 作为数字分隔符通常更易于查看位模式
            const long BillionsAndBillions = 100_000_000_000_000;//100000000000000
            const int Sixteen = 0b0001_0000;
            #endregion


            #region 本地函数
            //在一个函数的上下文中声明的方法
            //对于本地函数有两个常见的用例：公共迭代器方法和公共异步方法
            var localMethodResult = AlphabetSubset3('a', 'c');
            Console.WriteLine(localMethodResult.ToString());


            //可以对 async 方法采用相同的技术，以确保在异步工作开始之前引发由参数验证引起的异常
            var taskLocalResult = PerformLongRunningWork("xian", 23, "kulala");
            #endregion

            #region in参数修饰符
            //in关键字会导致按引用传递参数，但确保不修改参数的值。
            //它类似于ref或者out关键字，不同之处是in参数无法通过调用的方法进行修改。
            //out参数必须有调用的方法修改，
            //ref参数是可以修改的
            //作为in参数传递的变量的方法调用中传递之前必须初始化
          
            int readonlyArgument = 44;
            InArgExample(readonlyArgument);
            void InArgExample(in int number) 
            {
                //number = 19;//无法分配只读变量
            }
            Console.WriteLine(readonlyArgument);
            #endregion



            #region ref局部变量和返回结果
            //此功能允许使用并返回对变量的引用的算法。
            //必须将 ref 关键字添加到方法签名和方法中的所有 return 语句中
            //可以将 ref return 分配给值变量或 ref 变量\
            //不可向 ref 本地变量赋予标准方法返回值:因为那将禁止类似 ref int i = sequence.Count(); 这样的语句
            //不能将 ref 返回给其生存期不超出方法执行的变量
            //f 局部变量和返回结果不可用于异步方法:编译器无法知道异步方法返回时，引用的变量是否已设置为其最终值

            int[,] matrix = new int[1, 1] { { 42 } };
            ref var item = ref Find(matrix, (val) => val == 42);
            Console.WriteLine(item);
            item = 24;
            Console.WriteLine(matrix[0,0]);


            ref int Find(int [,] matrix, Func<int, bool> predicate)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (predicate(matrix[i, j]))
                            return ref matrix[i, j];

                    }
                throw new InvalidOperationException("Not found");
            }
            #endregion

            #region 条件ref 表达式
            //i件表达式可能生成 ref 结果而不是值。 例如，你将编写以下内容以检索对两个数组之一中第一个元素的引用
            int[] arr = new int[] { 1,2,3};
            int[] otherArr = new int[] { 1, 2, 3 };
            //变量 r 是对 arr 或 otherArr 中第一个值的引用。
            ref var r = ref (arr != null ? ref arr[0] : ref otherArr[0]);

            #endregion

        }
        private static (string, int, double) QueryCityData(string name)
        {
            if (name == "New York City")
                return (name, 8175133, 468.48);

            return ("", 0, 0);
        }

        //case 0:是常量模式。
        //case IEnumerable<int> childSequence：是声明模式
        //case int n when n > 0: 是具有附加when条件的声明模式
        //case null：是null常量模式
        //default：是常见的默认模式
        private static int SumPositiveNumbers(IEnumerable<object> sequence)
        {
            int sum = 0;
            foreach (var i in sequence)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case IEnumerable<int> childSequence:
                        {
                            foreach (var item in childSequence)
                            {
                                sum += (item > 0) ? item : 0;
                            }
                            break;
                        }
                    case int n when n > 0:
                        sum += n;
                        break;

                    case null:
                        throw new NullReferenceException("Null found in sequence");
                    default:
                        throw new InvalidOperationException("Unrecognized type");
                }
            }
            return sum;
        }

        private static void DisplayFistNumber(string[] args)
        {
            string arg = args.Length >= 1 ? args[0] :
                                        throw new ArgumentException("You must supply an argument");
            if(Int64.TryParse(arg, out var number))
                Console.WriteLine($"You entered {number: F0}");
            else
                Console.WriteLine($"{arg} is not a number.");

        }

        private static IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return alphabetSubsetImplementation();
            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        private static Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return longRunningWorkImplementation();

            async Task<string> longRunningWorkImplementation()
            {
                var interimResult = await FirstWork(address);
                var secondResult = await SecondStep(index, name);
                return $"The results are {interimResult} and {secondResult}. Enjoy.";
            }
        }
        private static Task<string> FirstWork(string address)
        {
            return null;
        }

        private static Task<string> SecondStep(int index, string address)
        {
            return null;
        }

    }
}
