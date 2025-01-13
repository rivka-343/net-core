using WebApplication2.BL;
using WebApplication2.Controllers;
using WebApplication2.DL;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
                //var baby = new Baby { BabyName = "John Doe" };
                //bool result = IsTwoWords(baby.BabyName);
                //Assert.IsTrue(result, "The baby's name should consist of two words.");
            ////// var id = "va";
            //var dataContext = new DataContext();
            ////dataContext.Appointments = new List<Appointment> { new Appointment() { AppointmentId = 1, BabyId = 1, NurseId = 1 } };
            //var serv = new AppointmentService(dataContext);
            //var cont = new AppointmentController(serv);
            //var result = cont.Get(1);
            //Assert.NotNull(result);
            // Arrange       
        }
        private bool IsTwoWords(string name)
        {
           return !string.IsNullOrWhiteSpace(name) && name.Split(' ').Length == 2;
        }
    }
}