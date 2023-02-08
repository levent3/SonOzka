using BusinessLayer.Abstract;
using Entites;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UlkeController : ControllerBase
    {
        private readonly IUlkeManager ulkeManager;

        public UlkeController(IUlkeManager ulkeManager)
        {
            this.ulkeManager = ulkeManager;
        }



        // GET: api/<UlkeController>
        [HttpGet]
        public async Task<ActionResult<ICollection<Ulke>>> Get()
        {





            var result = await ulkeManager.FindAllAsnyc(null);

            var sonuc = result.ToList();
            if (sonuc != null)
            {
                return Ok(sonuc);
            }
            else
            {
                return NotFound();

            }

        }

        // GET api/<UlkeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UlkeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UlkeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UlkeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
