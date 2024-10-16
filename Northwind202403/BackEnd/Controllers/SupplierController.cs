using BackEnd.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        ISupplierService _SupplierService;

        public SupplierController(ISupplierService supplierService)
        {
                this._SupplierService = supplierService;
        }
        // GET: api/<SupplierController>
        [HttpGet]
        public ActionResult Get()
        {
            var result = _SupplierService.Get();
            return Ok(result);
        }

        // GET api/<SupplierController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var result = _SupplierService.Get(id);
            return Ok(result);
        }

        // POST api/<SupplierController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
