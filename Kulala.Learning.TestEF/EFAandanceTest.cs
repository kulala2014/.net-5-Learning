using Kulala.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Kulala.Learning.TestEF
{
    class EFAandanceTest
    {
        public static void Show()
        {
            try
            {
                using (KulalaDBContext context = new KulalaDBContext())
                {
                    context.Database.Log += s => Console.WriteLine($"Current excuting sql:{s}");
                    //1.这句话执行完，没有数据库查询
                    var userList = context.Set<User>().Where(u => u.Id > 3);
                    //迭代遍历数据才去数据库查询，在真实数据使用数据时，才去数据库查询
                    foreach (var user in userList)
                    {
                        Console.WriteLine(user.Name);
                    }

                    userList = userList.Where(u => u.Id < 100);
                    userList = userList.Where(u =>u.Status <2);
                    userList = userList.OrderBy(u => u.Name);
                    foreach (var user in userList)
                    {
                        Console.WriteLine(user.Name);
                    }


                    //导航属性
                    context.Configuration.LazyLoadingEnabled = false;
                    var agentList = context.AGENTS.Include(nameof(Customer)).Where(c => new string[] {"A001","A002" }.Contains(c.AGENT_CODE));

                    foreach (var agent in agentList)
                    {
                        Console.WriteLine(agent.AGENT_NAME);
                        foreach (var customer in agent.CUSTOMER)
                        {
                            Console.WriteLine($"{customer.CUST_NAME}={customer.CUST_COUNTRY}-{customer.CUST_CITY}");
                        }
                    }

                    var agentList1 = context.AGENTS.Where(c => new string[] { "A001", "A002" }.Contains(c.AGENT_CODE));

                    foreach (var agent in agentList1)
                    {
                        Console.WriteLine(agent.AGENT_NAME);
                        context.Entry<Agents>(agent).Collection(u => u.CUSTOMER).Load();
                        foreach (var customer in agent.CUSTOMER)
                        {
                            Console.WriteLine($"{customer.CUST_NAME}={customer.CUST_COUNTRY}-{customer.CUST_CITY}");
                        }
                    }
                }

                using (KulalaDBContext context = new KulalaDBContext())
                {

                    //没有主外键也可以导航属性
                    var mapping = context.SysUserRoleMapping.Where(m => m.Id > 2);
                    foreach (var map in mapping)
                    {
                        Console.WriteLine(map.Id);
                        Console.WriteLine(map.SysRole.Description);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Read();
        }

        public static void ShowOther()
        {
            try
            {
                //using (KulalaDBContext context = new KulalaDBContext())
                //{
                //    using (TransactionScope trans = new TransactionScope())
                //    {


                //        context.Database.Log += s => Console.WriteLine($"Current excuting sql:{s}");
                //        AGENTS agent = new AGENTS
                //        {
                //            AGENT_CODE = "A014",
                //            AGENT_NAME = "Alford",
                //            WORKING_AREA = "Xian",
                //            COMMISSION = "0.14",
                //            PHONE_NO = "045-21447739",
                //            COUNTRY = "China"
                //        };

                //        CUSTOMER customer = new CUSTOMER
                //        {
                //            CUST_CODE = "C00032",
                //            CUST_NAME = "kulala",
                //            CUST_CITY = "yanan",
                //            WORKING_AREA = "shanxi",
                //            CUST_COUNTRY = "China",
                //            PHONE_NO = "13259806187",
                //            AGENT_CODE = agent.AGENT_CODE,

                //        };

                //        CUSTOMER customer1 = new CUSTOMER
                //        {
                //            CUST_CODE = "C00033",
                //            CUST_NAME = "Sarah",
                //            CUST_CITY = "yanan",
                //            WORKING_AREA = "shanxi",
                //            CUST_COUNTRY = "China",
                //            PHONE_NO = "13259806187",
                //            AGENT_CODE = agent.AGENT_CODE,

                //        };

                //        context.AGENTS.Add(agent);
                //        context.SaveChanges();
                //        context.CUSTOMER.Add(customer);
                //        context.SaveChanges();
                //        context.CUSTOMER.Add(customer1);
                //        context.SaveChanges();
                //    }
                //}
                //级联删除，级联更新
                using (KulalaDBContext context1 = new KulalaDBContext())
                    {
                        context1.Database.Log += s => Console.WriteLine($"Current excuting sql:{s}");
                    //1.这句话执行完，没有数据库查询
                    Agents agent = new Agents
                    {
                        AGENT_CODE = "A015",
                        AGENT_NAME = "Alford",
                        WORKING_AREA = "Xian",
                        COMMISSION = "0.14",
                        PHONE_NO = "045-21447739",
                        COUNTRY = "China"
                    };

                    Customer customer = new Customer
                    {
                        CUST_CODE = "C00036",
                        CUST_NAME = "kulala",
                        CUST_CITY = "yanan",
                        WORKING_AREA = "shanxi",
                        CUST_COUNTRY = "China",
                        PHONE_NO = "13259806187",
                        AGENT_CODE = agent.AGENT_CODE,

                    };

                    Customer customer1 = new Customer
                    {
                        CUST_CODE = "C00037",
                        CUST_NAME = "Sarah",
                        CUST_CITY = "yanan",
                        WORKING_AREA = "shanxi",
                        CUST_COUNTRY = "China",
                        PHONE_NO = "13259806187",
                        AGENT_CODE = agent.AGENT_CODE,

                    };
                    context1.AGENTS.Add(agent);
                    context1.CUSTOMER.Add(customer);
                    context1.CUSTOMER.Add(customer1);
                    context1.SaveChanges();
                    context1.AGENTS.Remove(agent);
                    context1.SaveChanges();


                    }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
