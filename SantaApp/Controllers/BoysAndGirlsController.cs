using API.Core;
using API.Core.DAL;
using Common.Enum;
using DTO.Verdict;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace SantaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoysAndGirlsController : BaseController
    {
        public BoysAndGirlsController(IAppContext appContext) : base(appContext)
        {
        }

        [HttpGet]
        public VerdictDto Get(string fio, int age)
        {
            return new VerdictDto();
        }

        [HttpGet("test")]
        public string Test()
        {
            var dto = new VerdictModel
            {
                Fio = "1 2 3",
                Age = 111,
                Verdict = VerdictEnum.Bad
            };
            _appContext.Verdict.Add(dto);
            _appContext.SaveChanges();
            return "Ok";
        }
        
        [HttpGet("fake")]
        public string GenerateFakeValues()
        {
            for (var i = 0; i < 10000; i++)
            {
                _appContext.Verdict.Add(new VerdictModel
                {
                    Fio = i.ToString(),
                    Age = i / 3 % 100,
                    Verdict = (VerdictEnum)(i%2)
                });
            }
            
            _appContext.SaveChanges();
            return "Ok";
        }
    }
}