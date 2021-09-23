using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Ruanmou.SOA.Web.Controllers
{
    //[RoutePrefix("api/Values/")]//action就可以去掉这一节；如果某个方法又不要了，可以在路由前面加个~  [Route("~api/Values/{id:int}")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> LGet()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [Route("api/Values/{id:int}")]//regex（）
        [HttpGet]
        public string GetById(int id)//Id查询
        {
            return "value";
        }

        //[Route("api/Values/{id:int=10}")]//可空
        //[Route("api/Values/{id:int?}")]//可空
        //public string GetId(int id = 10)//Id查询
        //{
        //    return "value";
        //}

        /// <summary>
        /// get value--value有子表数据--
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("api/Values/{id:int}/Type/{typeId:int}")]
        public string Get(int id, int typeId)//Id查询
        {
            return $"value-Type {id} {typeId}";
        }

        [Route("api/Values/{name}")]
        public string Get(string name)//名称查询
        {
            return $"value {name}";
        }

        [Route("api/Values/{id}/V2")]
        [HttpGet]
        public string LGetV333455(int id)
        {
            return "value V2";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
