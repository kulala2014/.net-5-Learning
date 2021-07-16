using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Graph;

namespace CSharpGrammarInfo.SharpEight
{
    public static class SharpEightInfo
    {
        public static async void ShowEightSample()
        {
            #region readonly成员
            //可以将readonly修饰符应用于结构的成员。他指示该成员不修改状态。这比将 readonly 修饰符应用于 struct 声明更精细
            var point = new Point();
            point.X = 2;
            point.Y = 3;
            Console.WriteLine(point.ToString());
            #endregion

            #region 默认接口方法
            //现在可以将成员添加到接口，并为这些成员提供实现
            ICalcuate shows = new ShowClass();
            shows.Show();
            shows.ShowInfo();
            #endregion

            #region 模式匹配功能增强
            // 增强了模式匹配功能
            //1.switch
            //a.变量位于switch关键字之前，不同的顺序使得在视觉上可以很轻松地区分switch表达式和switch语句。
            //b.将case和 : 元素替换为=>，它更简洁，更直观。
            //c.将default事例替换为_弃元。
            //d.正文是表达式，不是语句。
            Console.WriteLine(FromRainbow(Rainbow.Blue));

            //2.属性模式
            var address = new Address
            {
                State = "WA",
                PhoneNo = "12243"
            };
            Console.WriteLine(ComputeSalesTax(address, 12));
            //3.元组模式
            Console.WriteLine(RockPaperScissors("rock", "paper"));

            //4.位置模式
            //某些类型包含Deconstruct方法，该方法将其属性解构为离散变量，如果可以访问Deconstruct 方法，就可以使用位置模式检查对象地属性并将这些属性用于模式。
            var pointClass = new PointClass(1, 2);
            var result = GetQuadrant(pointClass);
            Console.WriteLine(result.ToString());
            #endregion


            #region using 声明
            //using 声明是前面带 using 关键字的变量声明。 它指示编译器声明的变量应在封闭范围的末尾进行处理
            using var file = new System.IO.StreamWriter("WriteLines2.txt");
            //private static int WriteLinesToFile(IEnumerable<string> lines);
            #endregion

            #region 静态本地函数
            //现在可以向本地函数添加 static修饰符，以确保本地函数不会从封闭范围捕获(引用)任何变量。
            //下面的代码包含一个静态本地函数。 它可以是静态的，因为它不访问封闭范围中的任何变量
            int M()
            {
                int y = 5;
                int x = 7;
                return Add(x, y);
                static int Add(int left, int right) => left + right;
            }
            #endregion

            #region 可处置地ref解构
            //用ref修饰符声明的struct可能无法实现任何接口，因此无法实现IDiposable.因此，要够能处理ref stuct，他必须有一个可访问的void Dispose()方法。此功能同样适用于readonly ref struct 声明。
            #endregion

            #region 可为空引用类型
            //C#8k开始允许设置可为空引用类型和不可为空引用类型
            //在项目文件中添加： <Nullable>enable</Nullable>
            //在程序上下文中添加#nullable enable
            string? test = null;

#nullable enable
            int? count = null;

            // 如果设置<Nullable>disable</Nullable>:不可为空引用类型，
            //1.引用不能为null
            //2.必须将变量初始化为非null值
            //3.变量永远 不能赋值null
            //test!.Length



            #endregion

            #region 异步流
            //可以创建并以异步方式使用流，返回异步流的方法有三个属性：
            //1.他是用async修饰符声明的；
            //2.他将返回IASyncEnumberable<T>
            //3.该方法包含用于在异步流中返回连续元素的yield return 语句
            //使用异步流需要在枚举流元素时在foreach关键字前面添加await关键字

            async IAsyncEnumerable<int> GenerateSequence()
            {
                for (int i = 0; i < 20; i++)
                {
                    await Task.Delay(100);
                    yield return i;
                }
            }

            await foreach (var number in GenerateSequence())
            {
                Console.WriteLine(number);
            }

            #endregion

            #region 异步可释放
            //支持实现 System.IAsyncDisposable 接口的异步可释放类型
            //提供一种用于异步释放非托管资源的机制。
            //需要执行资源清理时，可以实现 IAsyncDisposable.DisposeAsync()方法，就像实现Dispose 方法一样。
            //DisposeAyync返回表示异步释放操作的ValueTask。
            //通常当实现 IAsyncDisposable 接口时，类还将实现 IDisposable 接口。 IAsyncDisposable 接口的一种良好实现模式是为同步或异步释放做好准备。 用于实现释放模式的所有指南也适用于异步实现
            //IAsyncDisposable 接口声明单个无参数方法 DisposeAsync()。 任何非密封类都应具有另外一个也返回 ValueTask 的 DisposeAsyncCore() 方法。

            //    public async ValueTask DisposeAsync()
            //    {
            //        await DisposeAsyncCore();
            //        Dispose(false);
            //        // Suppress finalization.
            //        GC.SuppressFinalize(this);
            //    }

            //protected static virtual ValueTask DisposeAsyncCore()
            //{
            //    return ValueTask;
            //}
            #endregion

            #region 索引和范围
            //索引和范围为访问序列中的单个元素或范围提供了简洁的语法
            //1.System.Index表示一个序列索引
            //2.来自末尾运算符^的索引，指定一个索引于序列末尾相关
            //3.System.Range表示序列的子范围
            //4.范围运算符..,用于指定范围的开始和结尾，就像操作数一样
            //0索引与sequence[0]相同，^0索引与sequence[sequence.Length]相同。
            //对于任何数字n，索引^n与sequence.Length -n相同
            //范围指定范围的开始和结尾。
            var words = new string[]
            {
                            // index from start    index from end
                "The",      // 0                   ^9
                "quick",    // 1                   ^8
                "brown",    // 2                   ^7
                "fox",      // 3                   ^6
                "jumped",   // 4                   ^5
                "over",     // 5                   ^4
                "the",      // 6                   ^3
                "lazy",     // 7                   ^2
                "dog"       // 8                   ^1
            };

            Console.WriteLine($"The last word is {words[^1]}");
            var quickBrownFox = words[1..4];//包括words[1]到words[3]，不包括words[4]

            var lazyDog = words[^2..^0];//表示的时最后2位
            var allWords = words[..];
            var firstPhrase = words[..4];
            var lastPhrase = words[6..];

            //Range
            System.Range phrase = 1..4;

            var text = words[phrase];

            #endregion

            #region null合并赋值
            //引入了null合并赋值运算符??=,仅当左操作数计算为null时，才能使用运算符??=将其右操作数的值分配给左操作数。
            List<int> numbers = null;
            int? i = null;
            numbers ??= new List<int>();
            numbers.Add(i ??= 17);
            numbers.Add(i ??= 20);
            #endregion

            #region 非托管构造类型
            //从C#8开始，如果构造的值类型仅包含非托管类型的字段，则该类型不受管理。
            //struct Coords<T> where T : unmanaged
            //{
            //    public T X;
            //    public T Y;
            //}

            #endregion

            #region 嵌套表达式中的stackalloc
            //从 C# 8.0 开始，如果 stackalloc 表达式的结果为 System.Span<T> 或 System.ReadOnlySpan<T> 类型，则可以在其他表达式中使用 stackalloc 表达式

            //Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
            //var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
            //Console.WriteLine(ind);  // output: 1
            #endregion

            #region 内插逐字字符的增强功能
            //内插逐字字符串中 $ 和 @ 标记的顺序可以任意安排：$@"..." 和 @$"..." 均为有效的内插逐字字符串。 在早期 C# 版本中，$ 标记必须出现在 @ 标记之前。
            #endregion
        }

        private static string FromRainbow(Rainbow colorBand) =>
    colorBand switch
    {
        Rainbow.Red => "(0xFF, 0x00, 0x00)",
        Rainbow.Orange => "(0xFF, 0x7F, 0x00)",
        Rainbow.Yellow => "(0xFF, 0xFF, 0x00)",
        Rainbow.Green => "(0x00, 0xFF, 0x00)",
        Rainbow.Blue => "(0x00, 0x00, 0xFF)",
        Rainbow.Indigo => "(0x4B, 0x00, 0x82)",
        Rainbow.Violet => "(0x94, 0x00, 0xD3)",
        _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
    };

    private static decimal ComputeSalesTax(Address location, decimal salePrice) =>
         location switch
         {
             { State: "WA" } => salePrice * 0.06M,
             { State: "XIAN" } => salePrice * 0.075M,
             { State: "Japan" } => salePrice * 0.05M,
             _ => 0M
         };

    private static string RockPaperScissors(string first, string second)
        => (first, second) switch
        {
            ("rock", "paper") => "rock is covered by paper. Paper wins.",
            ("rock", "scissors") => "rock breaks scissors. Rock wins.",
            ("paper", "rock") => "paper covers rock. Paper wins.",
            ("paper", "scissors") => "paper is cut by scissors. Scissors wins.",
            ("scissors", "rock") => "scissors is broken by rock. Rock wins.",
            ("scissors", "paper") => "scissors cuts paper. Scissors wins.",
            (_, _) => "tie"
        };

    private static Quadrant GetQuadrant(PointClass point) => point switch
    {
        (0, 0) => Quadrant.Origin,
        var (x, y) when x > 0 && y > 0 => Quadrant.One,
        var (x, y) when x < 0 && y > 0 => Quadrant.Two,
        var (x, y) when x < 0 && y < 0 => Quadrant.Three,
        var (x, y) when x > 0 && y < 0 => Quadrant.Four,
        var (_, _) => Quadrant.OnBorder,
        _ => Quadrant.Unknown
    };

    private static int WriteLinesToFile(IEnumerable<string> lines)
    {
        using var file = new System.IO.StreamWriter("WriteLines2.txt");
        int skippedLines = 0;
        foreach (string line in lines)
        {
            if (!line.Contains("Second"))
            {
                file.WriteLine(line);
            }
            else
            {
                skippedLines++;
            }
        }
        // Notice how skippedLines is in scope here.
        return skippedLines;
        // file is disposed here
    }
}


    struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }

        public readonly double Distance => Math.Sqrt(X * X + Y * Y);
        public readonly override string ToString() =>
            $"({X}, {Y}) is {Distance} from the origin";
    }

    public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    public class Address
    {
        public string State { get; set; }
        public string PhoneNo { get; set; }
    }

    public enum Quadrant
    {
        Unknown,
        Origin,
        One,
        Two,
        Three,
        Four,
        OnBorder
    }

    class PointClass
    { 
        public int X { get; set; }
        public int Y { get; set; }

        public PointClass(int x, int y) => (X, Y) = (x, y);

        public void Deconstruct(out int x, out int y) =>
            (x, y) = (X, Y);
    }

    struct Coords<T> where T : unmanaged
    {
        public T X;
        public T Y;
    }
}
