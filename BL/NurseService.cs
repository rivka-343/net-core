
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
            return _dataContext.Nursee.ToList();//.Include(u => u.Appointments);
            //.Select(n => new Nurse
            //{
            //    NurseId = n.NurseId,
            //    NurseName = n.NurseName,
            //    Appointments = n.Appointments.Select(a => new Appointment
            //    {
            //        AppointmentId = a.AppointmentId,
            //        BabyId = a.BabyId,
            //        NurseId = a.NurseId,
            //    }).ToList()
            //});
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
        public void ApdateNurse(int id,Nurse nurse)
        {
            try
            {
                var existingBaby = _dataContext.Nursee
                .Include(b => b.Appointments) // טוען את התורים הקשורים
                .FirstOrDefault(b => b.NurseId == id);
                if (existingBaby != null)
                {
                    existingBaby.NurseName = nurse.NurseName; // Update the baby's name
                    existingBaby.experirnse = nurse.experirnse;
                    _dataContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Baby not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the baby: " + ex.Message);
            }

        }
        public void DeletdeNurse(int id)
        {
            try
            {
                var nurse = _dataContext.Nursee
                    .Include(n => n.Appointments)
                    .FirstOrDefault(n => n.NurseId == id);
                if (nurse != null)
                {
                    foreach (var appointment in nurse.Appointments.ToList())
                    {
                        _dataContext.Appointments.Remove(appointment);
                    }
                    _dataContext.Nursee.Remove(nurse);
                    _dataContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Nurse not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the nurse: " + ex.Message);
            }
        }
    }
}
