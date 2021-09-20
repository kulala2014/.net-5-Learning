using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulala.Learning.CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                using (CodeFirstModel context = new CodeFirstModel())
                {
                    context.Database.Log += s => Console.WriteLine($"Current excuting sql:{s}");
                    User user = context.SysUser.Find(4);
                    Console.WriteLine($"userinfo: {user.Name}-{user.Phone}-{user.QQ}");
                    User user1 = context.SysUser.FirstOrDefault(u => u.Id > 1);
                    Console.WriteLine($"userinfo: {user1.Name}-{user1.Phone}-{user1.QQ}");

                    var userList = context.SysUser.Where(u => u.Id > 2);
                    Console.WriteLine(userList.Count());

                    Role role = context.SysRole.Find(2);
                    Console.WriteLine(role);

                    Log log = context.SysLog.Find(2);
                    Console.WriteLine(log.Introduction);


                    //User user2 = new User
                    //{
                    //    Name = "kulala",
                    //    Password = "7ecad7d8ee2b27e537f64af29b443ec8",
                    //    Status = 1,
                    //    Phone = "12345678",
                    //    Mobile = "12345678",
                    //    Address = "万科城",
                    //    Email = "971266892@qq.com",
                    //    QQ = 971366892,
                    //    WeChat = "12345",
                    //    CreateTime = DateTime.Now,
                    //};

                    //context.SysUser.Add(user2);
                    //context.SaveChanges();
                    //user2.Sex = 1;
                    //user2.LastModifyTime = DateTime.Now;
                    //context.SaveChanges();
                    //context.SysUser.Remove(user2);
                    //context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }
    }
}
