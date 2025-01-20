//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.BL;

namespace BL
{
    public interface IBabyService
    {
       // public Baby GetAnyValue(Baby Baby);
        public IEnumerable<Baby> GetBaby();
        public Baby GetBabyById(int id);
        public void AddBaby(Baby baby);
        public void AddBabyAppointment(int id, Appointment Appointment);
        public void ApdateBaby(int id ,Baby baby);
        public void DeletdeBaby(int id);
    }
}
