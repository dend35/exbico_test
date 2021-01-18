using API.Core.DAL;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BaseController : ControllerBase
    {
        public readonly IAppContext _appContext;
        public readonly IMapper _mapper;

        public BaseController(IAppContext appContext, IMapper mapper)
        {
            _appContext = appContext;
            _mapper = mapper;
        }
    }
}