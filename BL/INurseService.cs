using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.BL;

namespace BL
{
    public interface INurseService
    {
        //public Nurse GetAnyValue(Nurse Nurse);
        public IEnumerable<Nurse> GetNurse();
        public Nurse GetNurseById(int id);
        public void AddNurse(Nurse nurse);
        public void AddNurseAppointment(int id, Appointment Appointment);
        public void ApdateNurse(Nurse nurse);
        public void DeletdeNurse(int id);
    }

}