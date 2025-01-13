using BL;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet]
        public IEnumerable<Appointment> Get()
        {
            return _appointmentService.GetAppointment();
        }
        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public Appointment Get(int id)
        {
            return _appointmentService.GetAppointmentById(id);
        }

        /// <summary>
        /// create a new appointment
        /// </summary>
        /// <param name="a"></param>
        [HttpPost]
        public void Post([FromBody] Appointment appointment)
        {
            _appointmentService.AddAppointment(appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Appointment appointment)
        {
            _appointmentService.ApdateAppointment(appointment);
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _appointmentService.DeletdeAppointment(id);
        }
    }
}
