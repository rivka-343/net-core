using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.BL;

namespace WebApplication2.DL
{
    public class DataContext : DbContext, IDataContext
    {
        //public static List<Appointment> _Appointments = new List<Appointment>
        //{
        //    new Appointment()
        //    {
        //        AppointmentId=1,

        //    }
        //};

        //public static List<Nurse> _Nursee = new List<Nurse>
        //{
        //    new Nurse()
        //    {
        //        NurseId = 1,
        //        Appointments = new List<Appointment>()
        //    }
        //};

        //public static List<Baby> _Babies = new List<Baby>
        //{
        //    new Baby()
        //    {
        //        BabyId = 1,
        //        Appointments = new List<Appointment>()
        //        {

        //        }
        //    }
        //};

        //public DbSet<Appointment> Appointments
        //{
        //    get => _Appointments;
        //    set => _Appointments = Appointments;
        //}
        //public DbSet<Nurse> Nursee {
        //    get => _Nursee;
        //    set => _Nursee = Nursee;
        //}

        //public DbSet<Baby> Babies {
        //    get => _Babies;
        //    set => _Babies = Babies;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=new_db_good");
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Nurse> Nursee { get; set; }
        public DbSet<Baby> Babies { get; set; }


        public void SaveChanges()
        {
            base.SaveChanges();
        }



    }
}
