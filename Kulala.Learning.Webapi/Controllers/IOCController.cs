using Kulala.WebApi.Interface;
using System.Web.Http;

namespace Kulala.Learning.Webapi.Controllers
{
    public class IOCController : ApiController
    {
        private IUserService _UserService = null;
        public IOCController(IUserService userService)
        {
            this._UserService = userService;
        }

        public string Get(int id)
        {
            //IUserService service = new UserService();
            //IUserService service = ContainerFactory.BuildContainer().Resolve<IUserService>();
            return Newtonsoft.Json.JsonConvert.SerializeObject(this._UserService.Query(id));
        }
    }
}
