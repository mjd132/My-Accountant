using Microsoft.EntityFrameworkCore;
using p1.DTO;
using p1.Entities;
using p1.Intefaces;
using p1.Repository.context;
using p1.Utilities;

namespace p1.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly EntitiesDbContext _context;
        private bool disposed = false;
        public UserRepository(EntitiesDbContext context)
        {
            _context = context;
        }
        public bool DeleteById(long id)
        {
            try
            {
                User? user = _context.Users.Find(id);
                if (user != null)
                {
                    _context.Users.Remove(user);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("User not found!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public UserDto GetById(long id)
        {

            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            UserDto userdto = new UserDto()
            {
                Id = user.Id,
                fName = user.fName,
                lName = user.lName,
                userName = user.userName,
            };
            return userdto;
        }


        public IEnumerable<UserDto> GetUsers()
        {
            var users = _context.Users.AsQueryable();
            var listUsers = users.Select(u => new UserDto
            {
                Id = u.Id,
                fName = u.fName,
                lName = u.lName,
                userName = u.userName,
                room = u.room

            }).ToList();
            return listUsers;

        }

        public void InsertUser(UserDto user)
        {
            //var USer = new User {
            //    fName = user.fName,
            //    lName = user.lName,
            //    password = user.password,
            //    userName = user.userName
            //};
            //_context.Users.Add(USer);
            throw new NotImplementedException();
        }

        public async Task<UserDto> GetUserByUsername(string username)

        {
            //User user = new User();
            //user = _context.Users.AsQueryable();
            var user = _context.Users.FirstOrDefault(u => u.userName == username);
             
            UserDto userdto = new UserDto()
            {
                userName = user.userName,
                age = user.age,
                fName = user.fName,
                lName = user.lName,
                password = user.password

            };
            return await Task.FromResult(userdto);
        }

        public void RegisterUser(UserDto request)
        {
            _context.Users.Add(new User
            {
                fName = request.fName,
                lName = request.lName,
                userName = request.userName,
                password = Hashing.MD5Hashing(request.password),

            });
            _context.SaveChanges();
        }

        public void SaveDataBase()
        {
            _context.SaveChanges();
        }

        public bool UpdateUser(UserDto user)
        {

            //check duplicate username
            UserDto userMain = GetById(user.Id);
            if (userMain != null && userMain.userName != user.userName)
            {
                if (ExistUserName(user.userName)) throw new Exception("Username is Exist!");
            }
            //instance User model
            User user1 = new User()
            {
                userName = user.userName,
                age = user.age,
                Id = user.Id,
                password = user.password,
                fName = user.fName,
                lName = user.lName
            };
            //try to update
            try
            {
                _context.Users.Entry(user1).State = EntityState.Modified;
                _context.SaveChanges();

            }
            catch
            {
                throw;
            }

            return true;
        }

        public bool ExistUserName(string userName)
        {
            return _context.Users.Any(u => u.userName.ToLower() == userName.ToLower());
        }
        public bool ExistUser(long id)
        {
            return _context.Users.Any(u => u.Id == id);
        }
    }
}
