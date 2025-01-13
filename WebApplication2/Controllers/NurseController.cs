using BL;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        // GET: api/<NourseController>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        private readonly INurseService _nurseService;

        public NurseController(INurseService nurseService)
        {
            _nurseService = nurseService;
        }

        [HttpGet]
        public IEnumerable<Nurse> Get()
        {
            return _nurseService.GetNurse().ToList();
        }
        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Nurse Get(int id)
        {
            return _nurseService.GetNurseById(id);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Nurse nurse)
        {
            _nurseService.AddNurse(nurse);
        }
        [HttpPost("{id}")]
        public void Post(int id, [FromBody] Appointment Appointment)
        {
            _nurseService.AddNurseAppointment(id, Appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Nurse nurse)
        {
            _nurseService.AddNurse(nurse);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _nurseService.DeletdeNurse(id);
        }
    }
}
