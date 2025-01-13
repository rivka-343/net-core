using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.BL;

namespace WebApplication2.DL
{
    public interface IDataContext
    {
        public  DbSet<Appointment> Appointments { get; set; }

        public  DbSet<Nurse> Nursee { get; set; }

        public  DbSet<Baby> Babies { get; set; }
        public void SaveChanges();
    }
}
