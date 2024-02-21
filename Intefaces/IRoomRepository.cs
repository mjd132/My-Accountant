using p1.DTO;
using p1.Entities;

namespace p1.Intefaces
{
    public interface IRoomRepository : IDisposable
    {
        List<RoomDto> GetAll();
        Task<RoomDto> Get(long? id,string? code);
        void InsertRoom(string  NameRoom, string admin);
        bool UpdateRoom(Room room);
        bool DeleteRoom(string code);
        bool ExistRoom(long? id, string? code);
        Task<ICollection<GetMembersDto>> GetMembers(long? id, string? code);
        void SaveChange();
        
        
    }
}
