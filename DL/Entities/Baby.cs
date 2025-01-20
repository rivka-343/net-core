using System.Text.Json.Serialization;

namespace WebApplication2.BL
{
    public class Baby
    {
       [JsonIgnore]
        public int BabyId { get; set; }
        public string BabyName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Appointment> Appointments { get; set; }

    }
}
//{
//    "babyId": 0,
//  "babyName": "string",
//  "appointments": [
//    {
//        "appointmentId": 0,
//      "babyId": 0,
//      "nurseId": 0,
//      "baby": {
//            "BabyId":1,
//        "BabyName":"aaaaaa",
//         "appointments": [
//        ]
//       },
//      "nurse": {
//            "nurseId": 0,
//        "nurseName": "string",
//        "experirnse": 0,
//        "appointments": [
//        ]
//      }
//    }
//  ]
//}