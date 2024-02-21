using Microsoft.EntityFrameworkCore;
using p1.Entities;
using p1.Intefaces;
using p1.Repository.context;

namespace p1.Repository
{
    public class UserRoomRepository : IUserRoomRepository
    {
        private bool disposedValue;
        private readonly EntitiesDbContext _context;
        public UserRoomRepository(EntitiesDbContext entitiesDbContext) {
            _context = entitiesDbContext;
        }

        

        public bool JoinUserToRoom(string username , string codeRoom)
        {
            

            User user= _context.Users.FirstOrDefault(x => x.userName == username);
            if ( user == null ) { throw new Exception("user not found!"); }
            Room room = _context.Rooms.FirstOrDefault(x => x.code == codeRoom);
            if (room == null) { throw new Exception("Room code is wrong!"); }
            if(room.members == null)
            {
                room.members = new List<User>();
            }
            try
            {
                room.members.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
            
            return true;
        }

        public bool LeaveUserFromRoom(string username)
        {
            User user = _context.Users.Include(u=>u.room).FirstOrDefault(u => u.userName == username);
            Room room = user.room;
            if (room == null) { throw new Exception("User not in any rooms!"); }
            try
            {
                room.members.Remove(user);
                _context.SaveChanges();
            }
            catch(Exception ex) { throw ex; }
            return true;
        }

        public void SaveChange()
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
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
