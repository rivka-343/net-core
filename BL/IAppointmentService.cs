using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.BL;

namespace BL
{
    public interface IAppointmentService
    {
        public Appointment GetAnyValue(Appointment Appointment);
        public IEnumerable<Appointment> GetAppointment();
        public Appointment GetAppointmentById(int id);
        public void AddAppointment(Appointment appointment);
        public void ApdateAppointment(int id,Appointment appointment);
        public void DeletdeAppointment(int id);

    }
}
