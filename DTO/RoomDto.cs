using p1.Entities;

namespace p1.DTO
{
    public class RoomDto
    {
        
        public long id { get; set; }
        public string name { get; set; }
        //public string description { get; set; }
        //public string type { get; set; }
        //public int level { get; set; }

        public string code { get; set; }

        //define admin
        public string usernameAdmin { get; set; }

        // members of room
        public ICollection<User>? members { get; set; }

    }
}
