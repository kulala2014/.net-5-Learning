using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.MVC.Project.Utility.AOP
{
    public interface ITestServiceF
    {
        //[LogBeforeAttribute]
        //[LogAfterAttribute]
        //[Monitor]
        void Show(int id, string name);
        void Show2(int id, string name);
    }
    public class TestServiceF : ITestServiceF
    {
        [LogBefore]
        [LogAfter]
        [Monitor]
        public void Show(int id, string name)
        {
            Console.WriteLine($"This is {id} {name}");
        }
        public void Show2(int id, string name)
        {
            Console.WriteLine($"This is {id} {name} 2222");
        }
    }
}
