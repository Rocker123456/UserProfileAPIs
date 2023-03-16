using Microsoft.EntityFrameworkCore;
using UserProfileAPIs.Database;
using UserProfileAPIs.Database.Models;

namespace UserProfileAPIs.Services
{
    public class UserService : IUserService
    {
        private readonly UserProfileContext _userProfileContext;
        public UserService(UserProfileContext userProfileContext) {
            _userProfileContext = userProfileContext;
        }

        public async Task<List<UserData>> GetAllUserData()
        {
            return await _userProfileContext.UserData.ToListAsync();
        }

        public async Task<UserData> GetUserDataById(int id)
        {
            return await _userProfileContext.UserData.FindAsync(id) ?? new UserData();
        }

        public async Task<int> CreateNewUserData(UserData userData)
        {
            var createUserResult = _userProfileContext.UserData.Add(userData);
            return await _userProfileContext.SaveChangesAsync();
        }

        public async Task<bool> DeleteUserData(int id)
        {
            var userExist = await _userProfileContext.UserData.FindAsync(id);

            if (userExist != null)
            {
                _userProfileContext.UserData.Remove(userExist);
                await _userProfileContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<UserData> UpdateUserData(UserData userData)
        {
            var userExit = await _userProfileContext.UserData.FindAsync(userData.Id);

            if (userExit != null)
            {
                _userProfileContext.Entry(userData).State = EntityState.Modified;
                await _userProfileContext.SaveChangesAsync();
            }

            return userData;
        }
    }
}
