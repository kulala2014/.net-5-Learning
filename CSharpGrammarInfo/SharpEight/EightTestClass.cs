using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGrammarInfo.SharpEight
{
    class EightTestClass
    {
    }

    public interface ICalcuate
    {
        void Show();
        void ShowInfo() => Console.WriteLine("This is default output");
    }

    class ShowClass : ICalcuate
    {
        public void Show() => Console.WriteLine("this is for class's override output");
    }
}
