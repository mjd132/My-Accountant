using System.ComponentModel.DataAnnotations;
using p1.Entities;

namespace p1.DTO
{
    public class UserDto
    {
        public string userName { get; set; }
        public string password { get; set; }
        public long Id { get; set; }
        public string fName { get; set; }
        public int? age { get; set; }
        public string? lName { get; set; }


        //room relationship

        public long? roomId { get; set; }
        public Room? room { get; set; }

        //public DateTime registerDate { get; set; }
        //public string idTelegram { get; set; }
        //public string roomCode { get; set; }

        //public string uid { get; set; }
        //public string phone { get; set; }
        //public string city { get; set; }
        //public ICollection<Friend> friends { get; set; }
    }
    
}

