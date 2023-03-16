using UserProfileAPIs.Database.Models;

namespace UserProfileAPIs.Services
{
    public interface IUserService
    {
        Task<List<UserData>> GetAllUserData();

        Task<UserData> GetUserDataById(int id);

        Task<int> CreateNewUserData(UserData userData);

        Task<UserData> UpdateUserData(UserData userData);

        Task<bool> DeleteUserData(int id);

    }
}
