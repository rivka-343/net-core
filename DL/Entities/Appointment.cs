using System.Text.Json.Serialization;
using WebApplication2.DL;

namespace WebApplication2.BL
{
    public class Appointment
    {
        [JsonIgnore]
        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }

        public int BabyId { get; set; }
        public int NurseId { get; set; }
        public Baby Baby { get; set; }
        public Nurse Nurse { get; set; }

    }
}
