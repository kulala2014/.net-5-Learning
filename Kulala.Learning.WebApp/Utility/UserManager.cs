using Kulala.EF.Model;
using Kulala.Learning.Common.Encrypt;
using Kulala.Learning.Common.Extension;
using Kulala.Learning.Common.Model;
using Kulala.Learning.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Kulala.Learning.WebApp.Utility
{
    public static class UserManager
    {
        private static Logger logger = new Logger(typeof(UserManager));

        public static LoginResult Login(this HttpContextBase context, string name, string password, string verifyCode)
        {
            if (context.Session["CheckCode"] != null
                && !string.IsNullOrWhiteSpace(context.Session["CheckCode"].ToString())
                && context.Session["CheckCode"].ToString().Equals(verifyCode, StringComparison.CurrentCultureIgnoreCase))
            {

                using (IUserService service = IOCFactory.GetContainer().Resolve<IUserService>())
                {
                    Expression<Func<User, bool>> funcWhere = c => c.Name.Contains(name);
                    User user = service.Query<User>(funcWhere).FirstOrDefault();
                    if (user == null)
                    {
                        return LoginResult.NoUser;
                    }
                    else if (!user.Password.Equals(MD5Encrypt.Encrypt(password)))
                    {
                        return LoginResult.WrongPwd;
                    }
                    else if (user.Status == 1)
                    {
                        return LoginResult.Frozen;
                    }
                    else
                    {
                        CurrentUser currentUser = new CurrentUser()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Account = user.Name,
                            Email = user.Email,
                            Password = user.Password,
                            LoginTime = DateTime.Now
                        };
                        context.Session["CurrentUser"] = currentUser;
                        context.Session.Timeout = 3;//minute  session过期等于Abandon

                        logger.Debug(string.Format("用户id={0} Name={1}登录系统", currentUser.Id, currentUser.Name));
                        return LoginResult.Success;
                    }
                }

            }
            else
            {
                return LoginResult.WrongVerify;
            }
        }

        public enum LoginResult
        {
            /// <summary>
            /// 登录成功
            /// </summary>
            [RemarkAttribute("登录成功")]
            Success = 0,
            /// <summary>
            /// 用户不存在
            /// </summary>
            [RemarkAttribute("用户不存在")]
            NoUser = 1,
            /// <summary>
            /// 密码错误
            /// </summary>
            [RemarkAttribute("密码错误")]
            WrongPwd = 2,
            /// <summary>
            /// 验证码错误
            /// </summary>
            [RemarkAttribute("验证码错误")]
            WrongVerify = 3,
            /// <summary>
            /// 账号被冻结
            /// </summary>
            [RemarkAttribute("账号被冻结")]
            Frozen = 4
        }

        public static void UserLogout(this HttpContextBase context)
        {
            HttpCookie myCookie = context.Request.Cookies["CurrentUser"];
            if (myCookie != null)
            {
                myCookie.Expires = DateTime.Now.AddMinutes(-1);//设置cookie过期
                context.Response.Cookies.Add(myCookie);
            }

            var sessionUser = context.Session["CurrentUser"];
            if (sessionUser != null && sessionUser is CurrentUser)
            {
                CurrentUser currentUser = (CurrentUser)context.Session["CurrentUser"];
                logger.Debug(string.Format("用户id={0} Name={1}退出系统", currentUser.Id, currentUser.Name));
            }

            context.Session["CurrentUser"] = null; //表示将制定的键的值清空，并释放掉
            context.Session.Remove("CurrentUser");
            context.Session.Clear();//表示将会话中所有的session的键值都清空，但是session还是依然存在，
            context.Session.RemoveAll();
            context.Session.Abandon();////就是把当前Session对象删除了，下一次就是新的Session了  
        }
    }
}