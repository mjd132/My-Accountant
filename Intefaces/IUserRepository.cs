using p1.DTO;

namespace p1.Intefaces
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<UserDto> GetUsers();
        UserDto GetById(long id);
        bool ExistUserName(string userName);
        bool DeleteById(long id);
        void InsertUser(UserDto user);
        bool UpdateUser(UserDto user);
        bool ExistUser(long id);
        //Accounting (Login)

        Task<UserDto> GetUserByUsername(string username);
        void RegisterUser(UserDto request);
        //Save Database
        void SaveDataBase();
    }
}
