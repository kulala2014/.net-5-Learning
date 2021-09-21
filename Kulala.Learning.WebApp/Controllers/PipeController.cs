using Kulala.Learning.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kulala.Learning.WebApp.Controllers
{
    public class PipeController : Controller
    {
        /// <summary>
        /// 1 Http请求处理流程
        /// 2 HttpApplication的事件
        /// 3 HttpModule
        /// 4 Global事件
        /// 
        /// 管道处理模式，大家平时开发都是在关注功能实现，
        /// 有没有从请求级层面来考虑程序，是怎么托管在IIS，又是怎么样响应的请求
        /// 
        /// Runtime--运行时
        /// Context--上下文
        /// 任何一个Http请求一定是有一个IHttpHandler来处理的 ashx aspx.cs  mvchttphandler 
        /// 任何一个Http请求就是一个HttpApplication对象来处理
        /// 然后处理过程固定包含：权限认证/缓存处理/Session处理/Cookie处理/生成html/输出客户端
        ///  与此同时，千千万万的开发者，又有各种各样的扩展诉求，任何一个环节都有可能要扩展，
        ///  我们来设计，该怎么设计？
        ///  这里用的是观察者模式，把固定的步骤直接写在handler里面，在步骤前&后分别放一个事件，
        ///  然后开发者可以对事件注册动作，等着请求进来了，然后就可以按顺序执行一下
        ///  详见 HttpProcessDemo
        ///  
        ///  对HttpApplication里面的事件进行动作注册的，就叫IHttpModule
        ///  自定义一个HttpModule--配置文件注册--然后任何一个请求都会执行Init里面注册给Application事件的动作
        ///  正常流程下，会按顺序执行19个事件
        ///  学习完HttpModule，我们可以做点什么有用的扩展？
        ///  1 日志-性能监控-后台统计数据
        ///  2 权限
        ///  3 缓存
        ///  4 页面加点东西
        ///  5 请求过滤--黑名单
        ///  6 MVC--就是一个Module扩展
        ///  
        ///  不适合的(不是全部请求的，就不太适合用module，因为有性能损耗)
        ///  1 多语言--根据cookie信息去查询不同的数据做不同的展示
        ///            如果是全部一套处理，最后httpmodule拦截+翻译，适合httpmodule
        ///  2 跳转到不同界面--也不适合
        ///  3 防盗链--针对一类的后缀来处理，而不是全部请求--判断--再防盗链
        ///  
        ///  HttpModule里面发布一个事件CustomHttpModuleHandler,在Global增加一个动作，
        ///  CustomHttpModuleEleven_CustomHttpModuleHandler(配置文件module名称_module里面事件名称)
        ///  请求响应时，该事件会执行
        ///  
        ///  HttpModule是对HttpApplication的事件注册动作
        ///  Global是对httpmodule里面的事件注册动作
        /// 
        /// 
        /// C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config\web.config
        /// .NetFramework安装路径，是一个全局的配置，是当前电脑上任何一个网站的默认配置
        /// 
        /// 
        /// 1 HttpHandler及扩展，自定义后缀，图片防盗链等
        /// 2 RoutingModule,IRouteHandler、IHttpHandler
        /// 3 MVC扩展Route，扩展HttpHandle
        /// 
        /// 配置文件指定映射关系：后缀名与处理程序的关系(IHttpHandler---IHttpHandlerFactory)
        /// Http任何一个请求一定是由某一个具体的Handler来处理的，不管是成功还是失败
        /// 以前写aspx，请求访问的是物理地址，其实不然，请求的处理是框架设置的
        /// 
        /// 所谓管道处理模型，其实就是后台如何处理一个Http请求
        /// 定义多个事件完成处理步骤，每个事件可以扩展动作(httpmodule)，
        /// 最后有个httphandler完成请求的处理，这个过程就是管道处理模型
        /// 还有一个全局的上下文环境httpcontext，无论参数，中间结果 最终结果，都保存在其中
        /// 
        /// 自定义handler处理，就是可以处理各种后缀请求，可以加入自己的逻辑
        /// 如果没有--请求都到某个页面--传参数---返回图片
        /// 防盗链---加水印---伪静态---RSS--robot--trace.axd
        /// 
        /// MVC里面不是controller action？其实是由 MvcHandler来处理请求，期间完成对action调用的
        /// 
        /// 网站启动时---对RouteCollection进行配置
        /// 把正则规则和RouteHandler（提供httphandler）绑定，放入RouteCollection
        /// 
        /// 请求来临时---用RouteCollection进行匹配
        /// 所谓MVC框架，其实就是在Asp.Net管道上扩展的，在PostResolveCache事件扩展了UrlRoutingModule，会在任何请求进来后，先进行路由匹配，如果匹配上了，就指定httphandler；没有匹配就还是走原始流程
        /// 
        /// 扩展自己的route，写入routecollection，可以自定义规则完成路由
        /// 扩展httphandle，就可以为所欲为，跳出MVC框架
        /// 
        /// 1 MVC的Controller激活与IOC扩展
        /// 2 ActionInvoker完成Action调用
        /// 3 Filter深入解读,理解各种ActionResult
        /// 
        /// MVC最终请求到MVCHandler来处理---ProcessRequestInit完成控制器的实例化
        /// 路由匹配--得到HomeController--这个时候去遍历一下全部的类，找一下有没有吻合的？--不可能没次请求都去遍历-----应该有个缓存---启动时扫描初始化--然后就存在Controllerfactory叫 ControllerTypeCache
        /// 
        /// 找的ControllerBuilder的ControllerFactory来完成控制器的实例化
        /// 而且这里还提供了SetControllerFactory
        /// 
        /// 网站启动时， ControllerBuilder.Current.SetControllerFactory(new ElevenControllerFactory());
        /// 把系统的唯一的控制器工厂换成了自己扩展的
        /// 替换之前，是DefaultControllerFactory---创建时先获取类型
        /// ---再GetControllerInstance获取实例--默认调用无参数--所以有参数就会异常
        /// ElevenControllerFactory---继承了DefaultControllerFactory--扩展GetControllerInstance---有完整类型然后去构造对象---IOC最擅长的事儿---可以构造控制器实例完成依赖注入
        /// 
        /// 请求最终是调用Action(实例方法)---肯定得先实例化控制器--已经完成了
        /// 
        /// 
        /// Filter:控制器实例化之后，调用方法前后，加入代码支持
        ///        本职工作其实就 InvokeAction+InvokeActionResult
        ///        找了filter--分别放入集合FilterInfo--
        ///        首先try-catch包住全过程(权限filter-执行方法前 ing  后---执行result 前  ing 后)--这期间的异常都是可以抓住的
        ///        然后先完成权限检测--验证身份---验证授权---套娃式执行action---套娃式执行result
        ///    
        /// Invoker先执行方法得到Result（void就是EmptyResult  其他非ActionResult就是tostring）
        /// ActionResult--在Invoker里面执行ExecuteResult--执行filter(不管怎么返回，都会执行filter)
        /// 
        /// 
        /// 1 MVC的View本质和扩展
        /// 2 MVC全流程解析
        /// 
        /// 不管怎么样，MVC最终要给浏览器响应一个结果，在Action里面要么
        /// 返回ActionResult：ExecuteResult
        /// 返回空的：EmptyResult-->ActionResult
        /// 返回其他类型：ToString() 写入response
        /// 
        /// View--ViewResult--ActionResult--ExecuteResult
        /// 1 找cshtml----交给ViewEngineCollection来FindView
        /// 2 生成html输出response,
        ///   找的是一个cshtml，这里变成了一个IView，就可以生成Html输出了
        ///   
        ///   也需要写个框架，前后台混合在一起，才能产生动态的数据，
        ///   你会怎么设计呢？
        ///   设计一个模板---模板找特殊标签---根据标签替换---不同的数据会产生不同的页面(发布系统){{Name}}
        ///   但是，这种不够灵活，或者说是写不出来ViewBag.Title或者for循环，  因为模板不可能这样智能解析
        ///   
        ///   还可以有个思路，就是把整个csHtml生成一个类，把HTML当成字符串，拼装起来，
        ///   那就很灵活了。。     既然是后台代码，为啥修改后不用编译，就直接能看到效果呢?
        ///   
        /// 通过反射找类型---找dll---找到临时文件夹(网站被访问就生成)---4个dll
        /// global--pipe--shared--viewstart
        /// 每个cshtml会生成一个类，一个文件会生成一个dll
        /// 如果被用到就会生成，没用到就没生成
        /// 为啥更新cshtml就能直接有效呢？因为再次被编译(不是每次请求都会重新编译，文件监控，有变化就重新编译了的)
        /// 每个cshtml会生成一个类---WebViewPage---Execute方法
        /// 
        /// FindView---变成了Engine的CreateView---使用构造里面的路径模型
        /// 效果没show出来，下次课解决
        /// 能做到的就是在不同的浏览器，用的是一套控制器，但是可以有不同的View
        /// 中英文网站   手机/PC
        /// </summary>
        /// <returns></returns>
        // GET: Pipe
        public ActionResult Index()
        {
            return View();
        }

        //获取当前application配置的module，默认的和自定义的
        public ActionResult Module()
        {
            HttpApplication app = base.HttpContext.ApplicationInstance;

            List<SysEvent> sysEventsList = new List<SysEvent>();
            int i = 1;
            foreach (EventInfo e in app.GetType().GetEvents())
            {
                sysEventsList.Add(new SysEvent()
                {
                    Id = i++,
                    Name = e.Name,
                    TypeName = e.GetType().Name
                });
            }

            List<string> list = new List<string>();
            foreach (string item in app.Modules.Keys)
            {
                list.Add($"{item}: {app.Modules.Get(item)}");
            }
            ViewBag.Modules = string.Join(",", list);

            return View(sysEventsList);
        }

        public ActionResult ImageTest()
        {
            ViewBag.Handler = HttpContext.CurrentHandler.GetType().FullName;
            HttpContextBase context = HttpContext;

            var routeData = base.RouteData.Values;
            return View();
        }

        public ActionResult Refuse()
        {
            return View();
        }

        public int IntResult()
        {
            return 123;
        }

        public DateTime DateTimeResult()
        {
            return DateTime.Now;
        }

        public CurrentUser CurrentUserResult()
        {
            var user =  new CurrentUser { Name = "kulala", Account = "xixi" };
            return user;
        }
    }
}