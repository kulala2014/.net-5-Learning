    1 MVC5：Controller、Action、View
    2 IIS部署，Global、Log4
    3 数据传值的多种方式
    4 Route使用和扩展，Area
    
    
    广义MVC(Model--View-Controller)，
    V是界面  M是数据和逻辑  C是控制，把M和V链接起来
    程序设计模式，一种设计理念，可以有效的分离界面和业务
    
    狭义MVC，是web开发框架， 
    V--Views   用户看到的视图内容
    C---Controllers  决定用户使用哪个视图，还能调用逻辑计算 
    方法Action
    M--Models  数据传递模型，普通的实体
    
    MVC就是返回页面？ 不是的
    返回html--string---json--xml--file--图片
    
    WebApi是返回数据的，为啥不都用MVC算了
    其实不管是aspx/ashx/webapi/mvc,都是使用Http协议
    所以一切的请求都可以实现的！ 
    Aspx：属于比较重的，默认有页面的生命周期---前后融合，viewstate---跟cs是一一对应
    Ashx: 属于轻量级的，没有页面的概念
    MVC：前后分离的，C可以任意指定视图，可以一套后台多套UI
    WepApi:专人做专事儿，管道都是独立的；RESTful，没有action
            .net core二者又融合管道了
            
    ViewData字典传值，里面是object，需要类型转换
    ViewBag dynamic传值，可以随便属性访问，运行时检测
    以上二者是会覆盖的，后者为准
    model--适合复杂数据的传递,强类型
    TempData--临时数据，可以跨action后台传递，存在session里面，用一次就清理掉
    
    Views--Web.Config是配置视图文件
    
    masterpage--layout  默认是_layout  可以自行指定
    Global.asax--全局式 
    Application_Start 全局启动时执行，且只执行一次，非常适合做初始化---也可以静态构造函数
    还可以有很多别的，下回分解
    
    dynamic是个动态类型--运行时检测--编译时随便你写
    利用委托的，性能比反射高，可以提供便利
    弱类型语言的特点，方便做一些特殊处理
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    
    
     /// 1 Route使用和扩展，Area
    /// 2 Razor语法，前后端语法混编
    /// 3 Html扩展控件，后端封装前端
    /// 4 模板页Layout,局部页PartialView 
    /// 
    /// MvcApplication--Application_Start--RegisterRoutes--给RouteCollection添加规则
    /// 请求进到网站--X--请求地址被路由按顺序匹配--遇到一个吻合的结束---就到对应的控制器和action
    /// 
    /// 因为一个Web项目可以非常大非常复杂，多人合作开发，命名就成问题了，Area可以把项目拆分开，方便团队合作；演变到后面可以做成插件式开发：
    /// MvcApplication--Application_Start--AreaRegistration.RegisterAllAreas()---其实就是把SystemAreaRegistration给注册下---添加URL地址规则--请求来了就匹配(area在普通的之前)
    /// 
    /// 众所周知，MVC请求的最后是反射调用的controller+action，信息来自于url+route，路由匹配时，只能找到action和controller，  其实还有个步骤，扫描+存储，在bin里面找Controller的子类，然后把命名空间--类名称+全部方法都存起来
    /// 
    /// a 控制器类可以出现在MVC项目之外，唯一的规则就是继承自Controller
    /// b Area也可以独立开，规则是必须有个继承AreaRegistration
    /// 增加区域后需要指定命名空间
    /// 
    /// Razor语法：cshtml本质是一个类文件，混编了html+cs代码
    /// 写后台代码：行内--单行--多行--关键字
    /// 后台代码写html：@:   闭合的html标签  <text></text>
    /// 
    /// Html扩展控件：封装个方法，自动生成html
    ///               后端一次性完成全部内容，而且html标签闭合
    ///               我们还可以自行封装这种扩展方法
    ///     但是这个已经不流行了，就是UI改动需要重新发布
    ///     更多应该是前后分离，写前端的人是不会懂后端的写法
    ///     
    /// Layout
    /// Masterpage--layout  默认是_layout  可以自行指定
    ///   @Styles.Render("~/Content/css") 使用样式包
    ///   @Scripts.Render("~/bundles/modernizr") 使用js包
    ///   @RenderBody() 就是页面的结合点
    ///   @RenderSection("scripts", required: false)
    ///   
    /// partialPage局部页---ascx控件,是没有自己的ACTION
    /// @{ Html.RenderPartial("PartialPage", "这里是Html.RenderPartial"); }
    ///  @Html.Partial("PartialPage", "这里是Html.Partial")
    /// 
    /// 子请求
    /// @Html.Action("ChildAction", "Second", new { name = "Html.Action" })
    /// @{Html.RenderAction("ChildAction", "Second", new { name = "Html.RenderAction" });}
    /// 有action,也可以传参数
    /// [ChildActionOnly]//只能被子请求访问  不能独立访问
    
    
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    
    /// 1 IOC和MVC的结合，工厂的创建和Bussiness初始化
    /// 2 WCF搜索引擎的封装调用和AOP的整合
    /// 3 HTTP请求的本质，各种ActionResult扩展订制
    /// 
    /// MVC使用EF6：
    /// 完成EF6引入和数据访问
    /// 依赖的EF需要引入--数据库连接需要配置
    /// 
    /// 当然不是的，一直推崇IOC，
    /// 
    /// 
    /// MVC请求进来---路由匹配---找到控制器和Action---控制器是个普通的类，Action是个普通的实例方法
    /// ---是不是一定有个过程，叫实例化控制器---但是现在希望通过容器来实例化这个控制器
    /// 
    /// 路由匹配后得到控制器名称---MVCHandler---ControllerBuilder.GetControllerFactory()---然后创建的控制器的实例
    /// 
    /// DefaultControllerFactory默认的控制器工厂---把工厂换成自己实现的不就可以了？---ControllerBuilder有个SetControllerFactory
    /// 
    /// 1 继承DefaultControllerFactory
    /// 2 SetFactory----实例化控制器会进到这里
    /// 3 引入第三方容器--将控制器的实例化换成容器操作
    /// 完成了MVC+IOC+ORM的结合
    /// 
    /// 这个适合全部的控制器吗？ 控制器不是用的抽象-实例的配置，
    /// 是直接构造类型的实例
    
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    /// 1 列表绑定、增删改查
    /// 2 WCF搜索引擎的封装调用和AOP的整合
    /// 3 Ajax删除、Ajax表单提交、Ajax列表、Ajax三级联动
    /// 4 Http请求的本质，各种ActionResult扩展订制
    /// 
    /// 怎么样完成一个功能：
    /// a Bussiness增加接口+实现
    /// b IOC配置文件
    /// c 注入到控制器
    /// d 查询数据库，传递到前端，绑定一下
    /// e 接受参数,拼装参数----
    /// f 参数ViewBag传递到前端再绑定
    /// g 分页使用pagedlist---返回数据用StaticPagedList--前端分页url带上参数--接受分页参数
    /// h 分页点击后重置页码数，就是设置表单的action
    /// 
    /// 接口服务查询，建议封装一下；
    /// 建议跟数据库查询独立分开；
    /// 也是接口+实现+model,然后就IOC
    /// 应用程序的配置文件需要加上服务相关
    /// 
    /// Ruanmou.Framework：通用的帮助类库，这里面放的是任何一个项目都可能用上的，这个类库可以被任何类库引用，但是自身不引用任何类库；只要是我用的东西，都得写在我自己里面；如果必须用到别的类库的东西，可以通过委托传递进来；
    /// Ruanmou.Web.Core：专门为MVC网站服务的通用的帮助
    /// 
    /// 1 增删改一览，Ajax删除、Ajax表单提交、Ajax列表、Ajax三级联动
    /// 2 HttpGet HttpPost Bind ChildActionOnly特性解读
    /// 3 Http请求的本质，各种ActionResult扩展订制
    /// 4 用户登录/退出功能实现
    /// 
    /// Create时，会有两次请求，地址都是一个，也就是Action相同，
    /// 一个HttpGet  一次HttpPost
    /// MVC怎么识别呢？不能依赖于参数识别(参数来源太多不稳定)
    /// 必须通过HttpVerbs来识别，
    /// 如果没有标记，那么就用方法名称来识别
    /// [ChildActionOnly] 用来指定该Action不能被单独请求，只能是子请求
    /// [Bind]指定只从前端接收哪些字段，其他的不要，防止数据的额外提交
    /// [ValidateAntiForgeryToken] 防重复提交，在cookie里加上一个key，提交的时候先校验这个
    /// 。。。filter特性
    /// MVC支持了非常多的特性，靠的全部是反射，就能额外的去识别特性，去做点有意义的事儿
    /// 
    /// Ajax请求数据响应格式：
    /// 一个项目组必须是统一的，前端才知道怎么应付
    /// 还有很多其他情况，比如异常了--exceptionfilter--按照固定格式返回
    ///                   比如没有权限--authorization--按照固定格式返回
    ///                   
    /// Http请求的本质：
    /// 请求--应答式，响应可以那么丰富？
    /// 不同的类型其实方式一样的，只不过有个contenttype的差别
    /// html---text/html
    /// json---application/json
    /// xml---application/xml
    /// js----application/javascript
    /// ico----image/x-icon
    /// image/gif   image/jpeg   image/png
    /// 
    /// 这个等于是Http协议的约定，Web框架和浏览器共同支持的
    /// 其实是服务器告诉浏览器如何处理这个数据
    /// 从页面下载pdf  或者页面展示pdf 靠的就是contenttype
    /// application/pdf     application/octet-stream
    /// 
    /// MVC各种Result的事儿
    /// Json方法实际上是new JsonResult 然后ExecuteResult
    /// 指定ContentType-application/json  然后将Data序列化成字符串写入stream
    /// 我们可以随意扩展的，只需要把数据放入response  指定好contenttype
    /// 
    /// 到底该怎么样看源码？
    /// 自上而下，先看流程，再看细节，剥洋葱式，一层层深入
    /// 先看流程--找入口--只找节点--不深入细节(看名字猜意思)--搞定过程
    /// 深入一个点的时候也不钻牛角尖--还是一层层的看---
    /// 熟知常规套路----看懂命名----了解常规的设计模式
    /// 耐心
    
    
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    /// 1 用户登录/退出功能实现
    /// 2 AuthorizeAttribute权限验证
    /// 3 Filter注册和匿名支持
    /// 4 解读Filter生效机制
    /// 
    /// 登陆后有权限控制，有的页面的是需要用户登录后才能访问的
    /// 需要在访问页面时增加登陆验证
    /// 也不能每个action都来一遍
    /// 
    /// 自定义CustomAuthorizeFilter，
    /// 1 方法注册----单个方法生效
    /// 2 控制器注册--控制器全部方法生效
    /// 3 全局注册--全部控制器的全部方法生效
    /// 
    /// AllowAnonymous匿名，单独加特性是没用的
    /// 其实需要验证时支持，甚至说可以自定义一些特性一样可以生效
    /// 
    /// a 用户访问A页面--没有权限--去登陆--成功跳回A页面
    ///   前端更多加个参数    
    ///   用session,验证失败记录url，登陆成功使用url
    ///   
    /// b 如果是ajax请求时没登录，需要返回规定格式的Ajax数据
    /// 
    /// c 特性使用范围
    ///   希望特性通用在不同的系统，不同的登陆地址
    ///   
    /// Filter生效机制：
    /// 控制器已经实例化了-- ExecuteCore--找到方法名字--ControllerActionInvoker.InvokeAction
    /// ---找到全部的Filter特性---InvokeAuthorize--result不为空，直接InvokeActionResult
    /// --为空就正常执行Action
    /// 
    /// 有了一个类型实例，有一个方法名称，希望你反射执行
    /// 在找到方法后，执行方法前---可以检测下特性
    /// （1 来自全局  2 找控制器 3 找方法的）
    /// ---特性是我预定义--只找这三类---按类执行
    /// ---定个标识，为空正常，不为空就跳转--正常就继续执行方法

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
    /// 1 Filter原理和AOP面向切面编程
    /// 2 全局异常处理：HandleErrorAttribute
    /// 3 IActionFilter IResultFilter扩展订制
    /// 4 Filter全总结，实战框架中AOP解决方案
    /// 
    /// AOP面向切面编程
    /// Filter原理：控制器实例化之后---ActionInvoke前后---通过检测预定义Filter并且执行它---达到AOP的目的
    /// 
    /// 开发日常工作：查bug 解决bug 写bug
    /// 
    /// HandleErrorAttribute+Application_Error(粒度不一样)
    /// 
    /// 
    /// IActionFilter&IResultFilter
    /// 
    /// 
    /// a 避免UI直接看到异常
    /// 
    /// 
    /// 
    /// Global OnActionExecuting
    /// Controller OnActionExecuting
    /// Action OnActionExecuting
    /// Action真实执行
    /// Action OnActionExecuted
    /// Controller OnActionExecuted
    /// Global OnActionExecuted
    /// 
    /// 不同注册位置生效顺序--全局/控制器/Action
    /// 同一位置按照先后顺序生效
    /// (不设置Order默认是1) 设置后是按照从小到大执行
    /// 俄罗斯套娃
    /// 
    /// ActionFilter能干啥？
    /// 日志  参数检测-过滤参数  缓存  重写视图 压缩 
    /// 防盗链  统计访问量--限流
    /// 不同的客户端跳转不同的页面
    /// 异常--权限：当然可以做，但是不合适，专业的对口
    /// 
    /// filter真的这么厉害，有没有什么局限性？？！！
    /// 虽然很丰富，但是只能是以Action为单位
    /// Action内部调用别的类库，加操作，做不到！
    /// 这种就得靠IOC+AOP扩展
    /// 
    /// ActionFilter 即使Action返回string 甚至Null  
    /// 4个方法都是会生效的

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
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
    /// 
    /// 解决方案：
    /// a 覆写的是FindView而不是CreateView(迟了),而且一定得set回去
    /// b CreateView时直接修改path(狠人)
    /// 注意不同的路径如_ViewStart
    /// 
    /// 
    /// 1 Asp.Net六大内置对象：Response，Request，Application，Server，Session，Cookie
    /// 2 HTTP协议理解，请求/响应
    /// 3 盘点MVC全扩展
    /// 
    /// Asp.Net有个大佬，HttpContext:http请求的上下文，任何一个环节其实都是需要httpcontext，需要的参数信息，处理的中间结果，最终的结果，都是放在httpcontext，是一个贯穿始终的对象
    /// 所谓6大对象，其实就是HttpContext的属性
    /// Request：url参数 form参数 url地址 urlreferer content-encoding，就是http请求提供的各种信息,后台里面都是可以拿到的context.Request.Headers["User-Agent"]；包括自定义的--BasicAuth; 请求信息的解读是asp.net_isapi按照http协议解析出来的
    /// Response：响应， Response.Write   各种result扩展就是序列化+response，验证码；都是给客户端响应内容，除了body(json/html/file)，其实还有很多东西，各种header，反正都是交给浏览器去用的
    /// Application：全局的东西，多个用户共享，  统计一下网站的请求数
    /// Server：也就是个帮助类库
    /// Session:用户登录验证，登录时写入，验证时获取；验证码；跳转当前页；一个用户一个Session，字典式
    /// Cookie:用户登录验证，登录时写入，验证时获取；ValidateAntiForgeryToken；保存用户数据(记住账号；购物车；访问过那几个页面；)；一个用户一个Cookie,字典式；
    /// 
    /// 协议：就是一个约定，保证多方的信息传输(中文也是一种约定)
    /// Http协议：超文本传输协议，也就是个文本传输的规范
    ///           浏览器/客户端遵循；服务端也遵循，那么就可以发起交互了
    /// 文本有啥：
    /// 
    /// cookie: 存在客户端--不能有敏感信息-推荐加密
    ///         每次请求都提交--不能太大--jd多个域名
    ///         可以存浏览器内存没有指定expiretime--关闭浏览器就丢失了
    ///         想存在硬盘就指定expiretime---想清空就修改有效期--不会丢失
    ///         同一个浏览器登陆覆盖的问题---一个浏览器cookie只有一个地方存储
    ///         不同的浏览器登陆就不会覆盖----无痕模式是不会覆盖的
    ///         
    /// session：服务器内存(sessionstateserver/SQLServer)---体积不要太大，可以存敏感信息--重启丢失    
    ///          一个用户一条，经常做传值(tempdata)
    ///          负载均衡下session怎么处理？会话粘滞/session共享
    ///          
    /// 如果浏览器禁用了cookie,还能用session吗?
    /// 不能的，可以通过url地址传递sessionid
    /// 
    /// 浏览器关闭，登陆就失效了，这是为什么呢？
    /// 因为cookie存在浏览器内存，关闭浏览器后cookie没了，再次打开分配了新的sessionid，所以没有登陆，但是之前登陆的那个session还是在内存里面的
    /// 如果希望重新打开用户还在登陆状态，就是在硬盘上存储cookie(expiretime)，后台要检测cookie，认可cookie的有效性(第一次检查cookie，然后还是写入session，每次还是checksession)



----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
