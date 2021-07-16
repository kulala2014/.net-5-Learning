using System;
using static CSharpGrammarInfo.SharpSix.SharpSixInfo;
using CSharpGrammarInfo.SharpSeven;
using static CSharpGrammarInfo.SharpEight.SharpEightInfo;
using CSharpGrammarInfo.SharpNine;

namespace CSharpGrammarInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************************************************** c# 6 new feature start *****************************************************");
            //C# 6 new features
            //Using static
            Show();
            Console.WriteLine("***************************************************** c# 6 new feature end *****************************************************");

            Console.WriteLine("***************************************************** c# 7 new feature end *****************************************************");
            SharpSevenInfo.Show();
            Console.WriteLine("***************************************************** c# 7 new feature end *****************************************************");

            Console.WriteLine("***************************************************** c# 8 new feature start *****************************************************");
            ShowEightSample();
            Console.WriteLine("***************************************************** c# 8 new feature end *****************************************************");


            Console.WriteLine("***************************************************** c# 9 new feature start *****************************************************");
            SharpNineInfo.Show();
            Console.WriteLine("***************************************************** c# 9 new feature end *****************************************************");
            Console.ReadKey();
        }
    }
}
