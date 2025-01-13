using BL;
using Microsoft.EntityFrameworkCore;
using WebApplication2.DL;

namespace WebApplication2.BL
{
    public class BabyService : IBabyService
    {
        private readonly IDataContext _dataContext;


        public BabyService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }
        //public Baby GetAnyValue(Baby Baby)
        //{
        //    return _dataContext.Babies.Where(x => x.Equals(Baby)).First();
        //}
        public IEnumerable<Baby> GetBaby()
        {
            return _dataContext.Babies
                .Include(b => b.Appointments) // טוען את רשימת התורים של כל תינוק
                .Select(b => new Baby
                {
                    BabyId = b.BabyId,
                    BabyName = b.BabyName, // כלול את שם התינוק אם זה נדרש
                    Appointments = b.Appointments.Select(a => new Appointment
                    {
                        AppointmentId = a.AppointmentId,
                        BabyId = a.BabyId,
                        NurseId = a.NurseId
                    }).ToList()
                })
                .ToList(); // מבצע את השאילתה למסד הנתונים


        }
        public Baby GetBabyById(int id)
        {
            return _dataContext.Babies.Where(x => x.BabyId == id).FirstOrDefault();
        }
        public void AddBaby(Baby baby)
        {
            _dataContext.Babies.Add(baby);
            _dataContext.SaveChanges();

        }
        public void AddBabyAppointment(int id, Appointment Appointment)
        {
            //Baby ba= _dataContext.Babies.Where(x => x.BabyId ==id).FirstOrDefault();
            //ba.Appointments.Add(Appointment);
            //_dataContext.Nursee.ToList().Find(nur => nur.NurseId == Appointment.NurseId).Appointments.Add(Appointment);
            //_dataContext.Appointments.Add(Appointment);
        }
        public void ApdateBaby(Baby baby)
        {
            //Baby ba = _dataContext.Babies.ToList().Find(bab => bab.BabyId == baby.BabyId);
            //ba.Appointments = baby.Appointments;

        }
        public void DeletdeBaby(int id)
        {
            Baby baby = _dataContext.Babies.ToList().Find(bab => bab.BabyId == id);
            _dataContext.Babies.Remove(baby);

            //כל הרשימה של התורים הזו למחוק
            // _dataContext.Appointments.Where(bab => bab.BabyId == baby.BabyId);

            //איך מוחקים לאחיות את התורים של התינוק הזה?
        }
    }
}
