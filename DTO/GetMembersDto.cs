using System.ComponentModel.DataAnnotations;

namespace p1.DTO
{
    public class GetMembersDto
    {
        
        public string fName { get; set; }
        public int? age { get; set; }
        public string? lName { get; set; }
        
        //public DateTime registerDate { get; set; }
        //public string idTelegram { get; set; }
        //public string roomCode { get; set; }
        
        public string userName { get; set; }
    }
}
