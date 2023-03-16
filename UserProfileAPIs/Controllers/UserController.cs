using Microsoft.AspNetCore.Mvc;
using UserProfileAPIs.Database.Models;
using UserProfileAPIs.Services;

namespace UserProfileAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("alluser")]
        public async Task<ActionResult<List<UserData>>> GetAllUserData()
        {
            try
            {
                var allUserData = await _userService.GetAllUserData();

                if (allUserData != null && !allUserData.Any())
                    return Ok("No UserData exist");

                return allUserData;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("user")]
        public async Task<ActionResult<UserData>> GetUserDataById(int id)
        {
            var userData = await _userService.GetUserDataById(id);

            if (userData == null)
                return Ok("No UserData exist");

            return userData;
        }

        [HttpPost]
        [Route("createuser")]
        public async Task<ActionResult<UserData>> CreateUserProfile(UserData userData)
        {
            var userDataId = await _userService.CreateNewUserData(userData);

            if (userDataId == 0)
                return Ok("No new user created");

            return userData;
        }

        [HttpDelete]
        [Route("deleteuser")]
        public async Task<ActionResult<UserData>> DeleteUserProfile(int id)
        {
            var userDeleted = await _userService.DeleteUserData(id);

            if (!userDeleted)
                return Ok("User does not exist");

            return Ok("User deleted successfully");
        }

        [HttpPut]
        [Route("updateuser")]
        public async Task<ActionResult<UserData>> UpdateUserProfile(UserData userData)
        {
            await _userService.UpdateUserData(userData);

            return Ok("User updated successfully");
        }
    }
}
