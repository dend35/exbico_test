using System.Threading.Tasks;
using API.Core;
using API.Core.DAL;
using AutoMapper;
using Common.Enum;
using DTO.Verdict;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SantaApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoysAndGirlsController : BaseController
    {
        public BoysAndGirlsController(IAppContext appContext, IMapper mapper) : base(appContext, mapper)
        {
        }

        [HttpGet]
        public async Task<VerdictDto> Get(string fio, int age)
        {
            var model = await _appContext.Verdict.FirstOrDefaultAsync(i=> i.Fio == fio && i.Age == age);
            return _mapper.Map<VerdictDto>(model);
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