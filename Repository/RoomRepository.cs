using AutoMapper;
using Microsoft.EntityFrameworkCore;
using p1.DTO;
using p1.Entities;
using p1.Intefaces;
using p1.Repository.context;
using p1.Utilities;

namespace p1.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly EntitiesDbContext _context;
        private readonly IMapper _mapper;
        private bool disposedValue;
        public RoomRepository(EntitiesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool DeleteRoom(string code)
        {
            try
            {
                var room = _context.Rooms.Include(u=> u.members).FirstOrDefault(r => r.code == code);
                if (room != null)
                {
                    if(room.members != null)
                    {
                        foreach (var user in room.members)
                        {
                            user.roomId = null;
                            user.room = null;
                        }

                    }
                    _context.Rooms.Remove(room);
                    _context.SaveChanges();
                    return true;
                }
                else
                    throw new Exception("Room not found!");
            }
            catch (Exception ex){ throw ex; }
        }

        public bool ExistRoom(long? id, string? code)
        {
            throw new NotImplementedException();
        }

        public Task<RoomDto> Get(long? id, string? code)
        {
            throw new NotImplementedException();
        }

        public List<RoomDto> GetAll()
        {
            var rooms = _context.Rooms.AsQueryable();
            var roomsdto = rooms.Select(u => new RoomDto {
                id = u.id,
                name = u.name,
                usernameAdmin = u.usernameAdmin,
                code = u.code,
                members = u.members,
            }).ToList();
            return roomsdto;
        }

        public async Task<ICollection<GetMembersDto>> GetMembers(long? id, string? code)
        {


            ICollection<User> users;

            if (code != null)
            {
                var room = _context.Rooms.Include(r => r.members).FirstOrDefault(u => u.code == code);
                if (room == null)
                {
                    throw new Exception("Room with the specified code not found.");
                }

                users = room.members;
                
            }
            else if (id != null)
            {
                var room = _context.Rooms.Include(r => r.members).FirstOrDefault(u => u.id == id);
                if (room == null)
                {
                    throw new Exception("Room with the specified ID not found.");
                }

                users = room.members;
            }
            else
            {
                throw new Exception("Null args get members in room repository");
            }
            
            if (users == null)
            {
                throw new Exception("No members found in the specified room.");
            }
            
            var userDtos = _mapper.Map<ICollection<GetMembersDto>>(users);
            
            return await Task.FromResult(userDtos);

        }

        public void InsertRoom(string nameRoom,string admin)
        {
            Room room;
            if (!_context.Users.Any(u=>u.userName == admin))
            {
                throw new Exception("username is empty!");
            }
            room = new Room()
            {
                code = RandomCodeGenerator.generate(),
                name = nameRoom,
                usernameAdmin = admin
            };
            try
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        public bool UpdateRoom(Room room)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();

                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RoomRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
