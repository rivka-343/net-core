
using BL;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DL;

namespace WebApplication2.BL
{
    public class NurseService : INurseService
    {
        private readonly IDataContext _dataContext;

        public NurseService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public IEnumerable<Nurse> GetNurse()
        {
            return _dataContext.Nursee.Include(u => u.Appointments).Select(n => new Nurse
            {
                NurseId = n.NurseId,
                NurseName = n.NurseName,
                // לדוגמה, כלול רק את המידע הרלוונטי של התורים, ולא את כל המידע כדי למנוע לולאות הפניה
                Appointments = n.Appointments.Select(a => new Appointment
                {
                    AppointmentId = a.AppointmentId,
                    BabyId = a.BabyId,
                    NurseId = a.NurseId,
                    // כלול רק את המידע הרלוונטי, בלי הפניות חזרה לנושאים קשורים
                }).ToList()
            });
        }
        public Nurse GetNurseById(int id)
        {
            return _dataContext.Nursee.Where(x => x.NurseId == id).FirstOrDefault();
        }
        public void AddNurse(Nurse nurse)
        {
            _dataContext.Nursee.Add(nurse);
            _dataContext.SaveChanges();
        }
        public void AddNurseAppointment(int id, Appointment Appointment)
        {
        //    Nurse ba = _dataContext.Nursee.Where(x => x.NurseId == id).FirstOrDefault();
        //    ba.Appointments.Add(Appointment);
        //    _dataContext.Babies.ToList().Find(nur => nur.BabyId == Appointment.BabyId).Appointments.Add(Appointment);
        //    _dataContext.Appointments.Add(Appointment);
        }
        public void ApdateNurse(Nurse nurse)
        {
            //Nurse  ba = _dataContext.Nursee.ToList().Find(bab => bab.NurseId == nurse.NurseId);
            //ba.Appointments = nurse.Appointments;

        }
        public void DeletdeNurse(int id)
        {
            Nurse nurse = _dataContext.Nursee.ToList().Find(bab => bab.NurseId == id);
            _dataContext.Nursee.Remove(nurse);
            //כל הרשימה של התורים הזו למחוק
            //IEnumerable<Appointment> appoint = _dataContext.Appointments.Where(nur => nur.NurseId == nurse.NurseId);
          
            //איך מוחקים לתינוקים את התורים של האחות הזה?
        }
    }
}
