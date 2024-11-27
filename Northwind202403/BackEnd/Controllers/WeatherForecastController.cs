using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
     
        ISingleton _singleton;

        IScope _scope;
        IScope _scope2;

        ITransient _transient;
        ITransient _transient2;
      
        public WeatherForecastController(ISingleton singleton,
            IScope scope, ITransient transient, IScope scope2, ITransient transient2)
        {
            _singleton = singleton;
            _scope = scope;
            _transient = transient;
            _scope2 = scope2;
            _transient2 = transient2    ;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var response = new ResponseDTO
            {
                SingletonValue = _singleton.Value,
                ScopeValue = _scope.Value,
                ScopeValue2 = _scope2.Value,
                TransientValue = _transient.Value,
                               TransientValue2 = _transient2.Value

                
            };
            return Ok(response);
        }
    }
}
