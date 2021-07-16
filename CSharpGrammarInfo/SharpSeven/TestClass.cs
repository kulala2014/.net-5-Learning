using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpGrammarInfo.SharpSeven
{
    class TestClass
    {
    }

    public class B
    {
        public B(int i, out int j) => j = i;
    }

    public class D : B
    {
        public D(int i) : base(i, out var j) => Console.WriteLine($"The value of J is {j}");
    }

    public class Point
    {
        public Point(double x, double y) => (X, Y) = (x, y);
        public double X { get; set; }
        public double Y { get; set; }

        public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
    }


    class ExpressionMembersExample
    {

        public ExpressionMembersExample(string label) => this.label = label;
        private string label;

        //Expression-bodied get / set accessors
        public string Lable
        {
            get => label;
            set => this.label = value ?? "default label";
        }
        ~ExpressionMembersExample() => Console.Error.WriteLine("Finalized");

        private string name;
        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "Name cannot be null");
        }
    }
}
