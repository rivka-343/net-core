using BL;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public  class BabyController : ControllerBase
    {
        private readonly IBabyService _babyService ;

        public BabyController(IBabyService babyService)
        {
            _babyService = babyService;
        }

        // GET: api/<BabyController>
       // [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        /// <summary>
        /// Get baby by Id
        /// </summary>
        /// <param name="id">The id of the baby</param>
        /// <returns>The baby with the given id</returns>
        //[HttpGet("{id}")]
        //public Baby GetBabyById(int id)
        //{
        //    return "value";
        //}

        // POST api/<BabyController>

        [HttpGet]
        public IEnumerable<Baby> Get()
        {
            return _babyService.GetBaby();
        }
        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Baby Get(int id)
        {
            return _babyService.GetBabyById(id);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Baby baby)
        {
            _babyService.AddBaby(baby);
        }
        [HttpPost("{id}")]
        public void Post(int id,[FromBody] Appointment Appointment)
        {
            _babyService.AddBabyAppointment(id, Appointment);
        }
        //35 שחור*2 40 

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Baby baby)
        {
            _babyService.ApdateBaby(baby);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _babyService.DeletdeBaby(id);
        }
    }
}