namespace p1.Intefaces
{
    public interface IUserRoomRepository :IDisposable
    {
        bool JoinUserToRoom(string username , string codeRoom);
        bool LeaveUserFromRoom( string username );
        void SaveChange();

    }
}
