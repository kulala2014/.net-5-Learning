using Kulala.EF.Model;
using Kulala.Learning.Interface;
using Kulala.Learning.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kulala.Learning.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DbContext dbContext = new KulalaDBContext();
            using (IUserService userService = new UserService(dbContext))
            {
                User user = userService.Find<User>(3);

                Expression<Func<User, int>> funcOrderby = u => u.Id;
                //Expression<Func<User, bool>> funcWhere = u => u.Id > 0;
                Expression<Func<User, bool>> funcWhere = null;
                var result = userService.QueryPage<User, int>(funcWhere, 1,2, funcOrderby);
                Console.WriteLine(user.Name);
            }
            Console.Read();
        }
    }
}
