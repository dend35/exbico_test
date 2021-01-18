using API.Core.DAL;
using Microsoft.AspNetCore.Mvc;

namespace SantaApp.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly IAppContext _appContext;

        public BaseController(IAppContext appContext)
        {
            _appContext = appContext;
        }
    }
}