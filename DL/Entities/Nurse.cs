namespace WebApplication2.BL
{
    public class Nurse
    {
        public int NurseId { get; set; }
        public string NurseName { get; set; }
        public int experirnse { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
