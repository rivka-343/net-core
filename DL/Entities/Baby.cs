namespace WebApplication2.BL
{
    public class Baby
    {
        public int BabyId { get; set; }
        public string BabyName { get; set; }
       // public int AppointmentId { get; set; }
        //public Appointment Appointment { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
