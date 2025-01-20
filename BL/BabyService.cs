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
            return _dataContext.Babies.Include(a => a.Appointments).ThenInclude(a => a.Nurse);
                //.Include(b => b.Appointments);// טוען את רשימת התורים של כל תינוק
                //.Select(b => new Baby
                // {
                //     BabyId = b.BabyId,
                //     BabyName = b.BabyName, // כלול את שם התינוק אם זה נדרש
                //     Appointments = b.Appointments.Select(a => new Appointment
                //     {
                //         AppointmentId = a.AppointmentId,
                //         BabyId = a.BabyId,
                //         NurseId = a.NurseId
                //     }).ToList()
                // })
                //.ToList(); // מבצע את השאילתה למסד הנתונים
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

        }
        public void ApdateBaby(int id,Baby updatedBaby)
        {
            try
            {
                var existingBaby = _dataContext.Babies
                .Include(b => b.Appointments) // טוען את התורים הקשורים
                .FirstOrDefault(b => b.BabyId == id);
                if (existingBaby != null)
                {
                    existingBaby.BabyName = updatedBaby.BabyName; // Update the baby's name
                    existingBaby.BirthDate = updatedBaby.BirthDate;
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
        public void DeletdeBaby(int id)
        {
            try
            {
                // Retrieve the baby to be deleted along with its appointments
                var baby = _dataContext.Babies
                    .Include(b => b.Appointments)
                    .FirstOrDefault(b => b.BabyId ==id);

                if (baby != null)
                {
                    // Remove all appointments associated with this baby
                    foreach (var appointment in baby.Appointments.ToList())
                    {
                        _dataContext.Appointments.Remove(appointment);
                    }

                    // Remove the baby from the context
                    _dataContext.Babies.Remove(baby);

                    // Save changes to the database
                    _dataContext.SaveChanges();
                }
                else
                {
                    // Handle the case where the baby was not found
                    throw new Exception("Baby not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the baby: " + ex.Message);
            }
        }
    }
}
