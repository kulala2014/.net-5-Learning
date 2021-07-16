using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CSharpGrammarInfo.SharpSix
{
   public static class SharpSixInfo
   {
        public static void Show()
        {
            try
            {
                //1.自动只读属性
                var student = new Student("Richard", "Gao");
                string fullName = student.ToString();
                var fullName1 = student.FullName;
                var fullName2 = student.FullName1;

                Console.WriteLine($"full anme: {fullName} or {fullName1} or {fullName2}");

                //2.using Static 允许我们再导入静态类的时候使用using Static Math

                //3. null 条件运算符
                Student std = null;

                string full = student?.FirstName ?? "Richard Gao";

                int? id = student?.ID;

                student = new Student("Clyde", "Gao");

                full = student?.FullName;
                string testName = student?.TestName ?? "kulala";
                student.TestName = "gao xiaorui";
                testName = student?.TestName ?? "Tom Cat";

                //4. 字符串内插

                var fullInfo = $"{{{testName}}} - {full}";

                //5.异常筛选器
                ExceptionFilter();

                //6.nameof 运算符
                Console.WriteLine(nameof(Student));

                //7.索引初始化表达式

                var dict = new Dictionary<int, string>
                {
                    { 100, "test" },
                    { 200, "kulala"}
                };
                dict.Remove(100, out string obj);
                Console.WriteLine(obj);

                var dict1 = new Dictionary<int, string>
                {
                    [100] = "test",
                    [200] = "kulala"
                };

                //8.属性修改通知事件
                student.PropertyChanged += (object sender, PropertyChangedEventArgs e) => Console.WriteLine("Student's ID is changed");
                student.ID = 100;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void ShowName()
        {
            Console.WriteLine("My Name is Richard");
        }

        private static void ExceptionFilter()
        {
            try
            {
                throw new Exception("kulala, test");
            }
            catch (Exception e) when (e.Message.Contains("kulala"))
            {
                Console.WriteLine("kulala raised an exception.");
            }
        }
   }

    
}
