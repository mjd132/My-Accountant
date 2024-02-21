using p1.DTO;

namespace p1.Intefaces
{
    public interface ITokenHandler
    {
        Task<string> CreateToken(UserDto user);

    }
}
