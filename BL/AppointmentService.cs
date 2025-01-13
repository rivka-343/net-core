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
            return _dataContext.Appointments.Include(u => u.Baby).Include(a => a.Nurse).Select(a => new Appointment
            {
                AppointmentId = a.AppointmentId,
                BabyId = a.BabyId,
                NurseId = a.NurseId
            });
        }
        public Appointment GetAppointmentById(int id)
        {
            return _dataContext.Appointments.Where(x => x.AppointmentId == id).FirstOrDefault();
        }
        public void AddAppointment(Appointment appointment)
        {
            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();

            //_dataContext.Nursee.ToList().Find(nur => nur.NurseId == appointment.NurseId).Appointments.Add(appointment);
            //_dataContext.Babies.ToList().Find(nur => nur.BabyId == appointment.BabyId).Appointments.Add(appointment); ;
        }
        public void ApdateAppointment(Appointment appointment)
        {
            //Appointment Lastapp = _dataContext.Appointments.ToList().Find(appoint => appoint.AppointmentId == appointment.AppointmentId);

            //_dataContext.Nursee.ToList().Find(nur => nur.NurseId == Lastapp.NurseId).Appointments.Remove(Lastapp);
            //_dataContext.Nursee.ToList().Find(appoint => appoint.NurseId == appointment.NurseId).Appointments.Add(appointment);
            //_dataContext.Babies.ToList().Find(nur => nur.BabyId == Lastapp.BabyId).Appointments.Remove(Lastapp);
            //_dataContext.Babies.ToList().Find(appoint => appoint.BabyId == appointment.BabyId).Appointments.Add(appointment);

            //_dataContext.Appointments.Remove(Lastapp);
            _dataContext.Appointments.Add(appointment);

        }
        public void DeletdeAppointment(int id)
        {
            Appointment appointment = _dataContext.Appointments.ToList().Find(appoint => appoint.AppointmentId == id);
            _dataContext.Appointments.Remove(appointment);
            //Nurse n = _dataContext.Nursee.ToList().Find(nur => nur.NurseId == appointment.NurseId);
            //n.Appointments.Remove(appointment);
            //Baby b = _dataContext.Babies.ToList().Find(nur => nur.BabyId == appointment.BabyId);
            //b.Appointments.Remove(appointment);
        }

        
    }
}
