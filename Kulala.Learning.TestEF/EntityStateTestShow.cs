using Kulala.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulala.Learning.TestEF
{
    class EntityStateTestShow
    {
        public static void Show()
        {
            User user2 = new User
            {
                Name = "yongyong",
                Password = "7ecad7d8ee2b27e537f64af29b443ec8",
                Status = 1,
                Phone = "12345678",
                Mobile = "12345678",
                Address = "万科城",
                Email = "971266892@qq.com",
                QQ = 971366892,
                WeChat = "12345",
                CreateTime = DateTime.Now,
            };

            try
            {
                User user3 = null;
                using (KulalaDBContext context = new KulalaDBContext())
                {

                    Console.WriteLine(context.Entry<User>(user2).State);
                    context.SysUser.Add(user2);
                    Console.WriteLine(context.Entry<User>(user2).State);
                    context.SaveChanges();
                    Console.WriteLine(context.Entry<User>(user2).State);
                    user2.Sex = 1;
                    user2.LastModifyTime = DateTime.Now;
                    Console.WriteLine(context.Entry<User>(user2).State);
                    context.SaveChanges();
                    Console.WriteLine(context.Entry<User>(user2).State);
                    context.SysUser.Remove(user2);
                    Console.WriteLine(context.Entry<User>(user2).State);
                    context.SaveChanges();
                    Console.WriteLine(context.Entry<User>(user2).State);

                    user3 = context.SysUser.Find(3);
                }

                using (KulalaDBContext context = new KulalaDBContext())
                {
                    context.SysUser.Attach(user3);
                    Console.WriteLine(context.Entry<User>(user3).State);

                    user3.Name = "ruirui";
                    Console.WriteLine(context.Entry<User>(user3).State);
                    context.SaveChanges();

                    User user = context.SysUser.Find(user3.Id);
                    user.Name = "Sarah";

                    context.SaveChanges();
                }


                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
  