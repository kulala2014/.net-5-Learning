using Kulala.EF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kulala.Learning.TestEF
{
    public class EFTestShow
    {
        public static void Show()
        {
            try
            {
                using (KulalaDBContext context = new KulalaDBContext())
                {
                    context.Database.Log += s => Console.WriteLine(s);
                    //查询list
                    var userList = context.SysUser.Where(u => new int[] { 1,2,3,4,5,6,7,8}.Contains(u.Id));
                    foreach (var item in userList)
                    {
                        Console.WriteLine($"userinfo: {item.Name}-{item.Address}");
                    }

                    var list = from u in context.SysUser
                               where new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }.Contains(u.Id)
                               select u;
                    foreach (var item in list)
                    {
                        Console.WriteLine($"userinfo: {item.Name}-{item.Address}");
                    }

                    //分页查询
                    var logList = context.SysLog.Where(l => l.Id < 100)
                                  .OrderBy(l => l.CreateTime)
                                  .Select(l => new
                                  {
                                      UserName = l.UserName,
                                      Detail = l.Introduction
                                  }).Skip(5).Take(5);

                    foreach (var log in logList)
                    {
                        Console.WriteLine(log.Detail);
                    }

                    //inner join
                    var logs = (from l in context.SysLog
                               join u in context.SysUser on l.UserName equals u.Name
                               where new int[] { 1, 2, 3, 4 }.Contains(u.Id)
                               select new 
                               {
                                   UserName = l.UserName,
                                   LogDetail = l.Introduction,
                                   CreateTime = l.CreateTime
                               }).Take(10);

                    foreach (var item in logs)
                    {
                        Console.WriteLine($"loginfo: {item.UserName} - {item.LogDetail} -{item.CreateTime}");
                    }

                    //left join

                    var logLists = (
                                    from u in context.SysUser
                                    join l in context.SysLog on   u.Name equals l.UserName
                                    into logCollection
                                    from log in logCollection.DefaultIfEmpty()
                                    where new int[] { 1, 2 }.Contains(u.Id)
                                    select new
                                    {
                                        UserName = u.Name,
                                        Address = u.Address,
                                        Gendor = u.Sex
                                    }).Take(10);

                    foreach (var item in logLists)
                    {
                        Console.WriteLine($"loginfo: {item.UserName} - {item.Address} -{item.Gendor}");
                    }

                    DbContextTransaction trans = null;
                    try
                    {
                        trans = context.Database.BeginTransaction();
                        string sql = "Update [SysUser] Set Name='xixi' WHERE ID=@Id";
                        SqlParameter parameter = new SqlParameter("@Id", 15);
                        context.Database.ExecuteSqlCommand(sql, parameter);
                        trans.Commit();

                    }
                    catch (Exception ex)
                    {
                        trans?.Rollback();
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        trans.Dispose();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
