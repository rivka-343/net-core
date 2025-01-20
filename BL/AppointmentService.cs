using BL;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DL;

namespace WebApplication2.BL
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IDataContext _dataContext;

        public AppointmentService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Appointment GetAnyValue(Appointment App)
        {
            return _dataContext.Appointments.Where(x => x.Equals(App)).First();
        }

        public IEnumerable<Appointment> GetAppointment()
        {
            return _dataContext.Appointments.Include(u => u.Baby).Include(a => a.Nurse);//.Select(a => new Appointment
            //{
            //    AppointmentId = a.AppointmentId,
            //    BabyId = a.BabyId,
            //    NurseId = a.NurseId
            //});
        }
        public Appointment GetAppointmentById(int id)
        {
            return _dataContext.Appointments.Where(x => x.AppointmentId == id).FirstOrDefault();
        }
        public void AddAppointment(Appointment appointment)
        {
            var existingBaby = _dataContext.Babies.FirstOrDefault(b => b.BabyId == appointment.BabyId);
            if (existingBaby == null)
            {
                throw new Exception("Baby not found");
            }

            // בדוק אם האחות קיימת
            var existingNurse = _dataContext.Nursee.FirstOrDefault(n => n.NurseId == appointment.NurseId);
            if (existingNurse == null)
            {
                throw new Exception("Nurse not found");
            }

            // הוסף את התור
            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();
            //_dataContext.Nursee.ToList().Find(nur => nur.NurseId == appointment.NurseId).Appointments.Add(appointment);
            //_dataContext.Babies.ToList().Find(nur => nur.BabyId == appointment.BabyId).Appointments.Add(appointment); ;
        }
        public void ApdateAppointment(int id, Appointment updatedAppointment)
        {

            try
            {
                // Find the existing appointment
                var existingAppointment = _dataContext.Appointments.Find(id);

                if (existingAppointment != null)
                {
                    existingAppointment.AppointmentDate = updatedAppointment.AppointmentDate;
                    _dataContext.SaveChanges(); // Save changes to the database
                }
                else
                {
                    throw new Exception("Appointment not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the appointment: " + ex.Message);
            }
        }
        public void DeletdeAppointment(int id)
        {
            var appointment = _dataContext.Appointments
        .Include(a => a.Baby)
        .Include(a => a.Nurse)
        .FirstOrDefault(a => a.AppointmentId == id);
            try
            {
                if (appointment != null)
                {
                    // Remove the appointment from the context
                    _dataContext.Appointments.Remove(appointment);
                    // Optionally, remove the appointment reference from Baby and Nurse
                    if (appointment.Baby != null)
                    {
                        appointment.Baby.Appointments.Remove(appointment);
                    }

                    if (appointment.Nurse != null)
                    {
                        appointment.Nurse.Appointments.Remove(appointment);
                    }
                    _dataContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Appointment not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
            

        }
    }
}
