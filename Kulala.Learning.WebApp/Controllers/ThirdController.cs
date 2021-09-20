using Kulala.EF.Model;
using Kulala.Learning.Common;
using Kulala.Learning.Common.Encrypt;
using Kulala.Learning.Common.ExtendExpression;
using Kulala.Learning.Common.Model;
using Kulala.Learning.Interface;
using Kulala.Learning.Service;
using Kulala.Learning.WebApp.Utility.CustomResult;
using Kulala.Learning.WebApp.Utility.Filter;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Kulala.Learning.WebApp.Controllers
{
    public class ThirdController : Controller
    {
        private IUserService _iUserService;
        private int pageSize = 3;
        /// <summary>
        /// 构造函数注入---控制器得由容器来构造
        /// </summary>
        /// <param name="userService"></param>
        public ThirdController(IUserService userService)
        {
            this._iUserService = userService;
        }

        // GET: Third
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]

        public ActionResult Index(string searchString, int? pageIndex)
        {
            //User user = _iUserService.Find<User>(3);
            //return View();
            Expression<Func<User, bool>> funcWhere = null;

            #region 查询条件
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                funcWhere = funcWhere.And(c => c.Name.Contains(searchString));
            }
            #endregion

            #region 排序
            Expression<Func<User, int>> funcOrderby = c => c.Id;
            #endregion

            int index = pageIndex ?? 1;

            PageResult<User> userList = this._iUserService.QueryPage(funcWhere, pageSize, index, funcOrderby, true);

            StaticPagedList<User> pageList = new StaticPagedList<User>(userList.DataList, index, pageSize, userList.TotalCount);

            return View(pageList);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = _iUserService.Find<User>(id ?? -1);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                throw new Exception("Not Found");
            }
            User user = this._iUserService.Find<User>(id ?? -1);
            if (user == null)
            {
                throw new Exception("Not Found");
            }
            else
            {
                this._iUserService.Delete(user);
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            User user = _iUserService.Find<User>(id);
            if (user == null)
            {
                throw new Exception("Not Found");
            }
            _iUserService.Delete<User>(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult AjaxDelete(int id)
        {
            _iUserService.Delete<User>(id);
            AjaxResult ajaxResult = new AjaxResult()
            {
                Result = DoResult.Success,
                PromptMsg = "删除成功"
            };
            return Json(ajaxResult);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                throw new Exception("need commodity id");
            }
            User user = _iUserService.Find<User>(id ?? -1);
            if (user == null)
            {
                throw new Exception("Not Found");
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id, Name, Phone, Address, Email, Password")] User user)
        {
            if (ModelState.IsValid)
            {
                User _user = _iUserService.Find<User>(user.Id);
                _user.Name = user.Name;
                _user.Phone = user.Phone;
                _user.Address = user.Address;
                _user.Email = user.Email;
                this._iUserService.Update(_user);
                return RedirectToAction("Index");
            }
            else
                throw new Exception("ModelState未通过检测");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Put)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Phone, Address, Email, Password")] User user)
        {

            if (ModelState.IsValid)//数据校验
            {
                user.Password = MD5Encrypt.Encrypt(user.Password);
                user.CreateTime = DateTime.Now;
                user.CreateId = 123;

                user = this._iUserService.Insert(user);
                return RedirectToAction("Index");
            }
            else
            {
                throw new Exception("ModelState未通过检测");
            }
        }

        /// <summary>
        /// 不是ActionResult---直接当结果写入stream，默认的contenttype是html
        /// </summary>
        /// <returns></returns>
        public string StringResult()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new 
                {
                    Name="kulala",
                    Value="1987"
                });
        }

        /// <summary>
        /// 几乎所有的result都是指定response  de ContentType类型，然后写入response
        /// Http请求：
        /// 不同的类型其实处理方式是一样的，只不过contenttype的差别
        /// html---text/html
        /// json---application/json
        /// xml---application/xml
        /// js----application/javascript
        /// ico----image/x-icon
        /// image/gif   image/jpeg   image/png
        /// 这个contenttype 等于是http协议的约定，web框架和浏览器共同支持的
        /// 其实服务器告诉浏览器如何处理这个数据
        /// 从页面下载pdf： application/pdf
        /// 页面展示pdf 靠的application/octet-stream
        /// 
        /// MVC 各result的事
        /// JSON方法实际上是new JSONRESULT 然后excuteresult
        /// 指定contentype application/json, 然后讲data序列化成字符串写入steam
        /// 可以随意扩展，只需要吧数据放入response，指定contenttype
        /// 
        /// </summary>
        public void JsonVoidResult()
        {
            HttpResponseBase httpResponse = base.HttpContext.Response;
            httpResponse.ContentType = "application/json";
            httpResponse.Write(
                Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    Name = "kulala",
                    Value = "1987"
                })
                );
        }

        public NewtonJsonResult NewtonResult()
        {
            return new NewtonJsonResult(new
            {
                Name = "kulala",
                Value = "1987"
            });
        }

        public XmlResult XmlResult()
        {
            return new  XmlResult(new AjaxResult()
            {
                Result = DoResult.Success,
                DebugMessage = "这里是JsonResult"
            });
        }

        public JsonResult JsonResult()
        {
            return Json(new
            {
                Name = "kulala",
                Value = "1987"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}