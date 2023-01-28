using DataTransferObject;
using DataTransferObject.EnumAndLabels;
using HuuzaAPI.Models;
using HuuzaAPI.Service;
using Microsoft.AspNetCore.Mvc;

namespace HuuzaAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost]
        [Route("Login")]
        public ReturnDTO<LoggedDTO> Authenticate([FromBody] LoginDTO login)
        {

            var result = new ReturnDTO<LoggedDTO>();

            var loginModel = new AuthenticationModel();

            var loginAuthenticated = loginModel.Authenticate(login, EnumAndLabels.ID_USER_TYPE_ADMINISTRADOR);

            if (loginAuthenticated.Result != null)
            {

                var permission = loginModel.GetPermissionUser(loginAuthenticated.Result.IdPermission);

                if (permission.Result != null)
                {

                    var userModel = new UserModel();

                    var userAuthenticated = userModel.Find(loginAuthenticated.Result.IdUser);

                    if (userAuthenticated.Result != null)
                    {

                        var tokenString = TokenService.GenerateToken(userAuthenticated.Result, permission.Result);

                        var logged = new LoggedDTO()
                        {
                            Success = true,
                            Message = string.Empty,
                            Token = tokenString,
                            IdUser = userAuthenticated.Result.Id,
                            IdLogin = loginAuthenticated.Result.Id,
                            User = userAuthenticated.Result.Name,
                            Username = login.UserName
                        };

                        result.Result = logged;
                        result.Success = true;

                        return result;

                    }

                }

            }

            result.Result = null;
            result.Message = loginAuthenticated.Message;
            result.Success = false;

            return result;
        }

        [HttpPost]
        [Route("AuthenticateHuuza")]
        public ReturnDTO<LoggedDTO> AuthenticateHuuza([FromBody] LoginDTO login)
        {

            var result = new ReturnDTO<LoggedDTO>();

            var loginModel = new AuthenticationModel();

            var loginAuthenticated = loginModel.Authenticate(login, EnumAndLabels.ID_USER_TYPE_CLIENTE);

            if (loginAuthenticated.Result != null)
            {

                var permission = loginModel.GetPermissionUser(loginAuthenticated.Result.IdPermission);

                if (permission.Result != null)
                {

                    var userModel = new UserModel();

                    var userAuthenticated = userModel.Find(loginAuthenticated.Result.IdUser);

                    if (userAuthenticated.Result != null)
                    {

                        var tokenString = TokenService.GenerateToken(userAuthenticated.Result, permission.Result);

                        var logged = new LoggedDTO()
                        {
                            Success = true,
                            Message = string.Empty,
                            Token = tokenString,
                            IdUser = userAuthenticated.Result.Id,
                            IdLogin = loginAuthenticated.Result.Id,
                            User = userAuthenticated.Result.Name,
                            Username = login.UserName
                        };

                        result.Result = logged;
                        result.Success = true;

                        return result;

                    }

                }

            }

            result.Result = null;
            result.Message = loginAuthenticated.Message;
            result.Success = false;

            return result;
        }

    }
}
