using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API.Core;
using API.Core.DAL;
using AutoMapper;
using DTO.Verdict;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VerdictController : BaseController
    {
        public VerdictController(IAppContext appContext, IMapper mapper) : base(appContext, mapper)
        {
        }

        [HttpGet]
        public async Task<VerdictDto> Get(string fio, int age)
        {
            var client = new HttpClient();
            var url = $"https://localhost:5001/api/BoysAndGirls?fio={fio}&age={age}";
            var response = await (await client.GetAsync(url)).Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<VerdictDto>(response);
            if (dto == null)
                return null;

            var model = _mapper.Map<VerdictModel>(dto);
            if (_appContext.Verdict.Any(i => i.Id == dto.Id))
                _appContext.Verdict.Update(model);
            else
                await _appContext.Verdict.AddAsync(model);

            _appContext.SaveChanges();
            return dto;
        }

        
    }
}
