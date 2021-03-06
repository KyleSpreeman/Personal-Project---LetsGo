using LetsGo.Data.Providers;
using LetsGo.Models;
using LetsGo.Models.Domain;
using LetsGo.Models.Requests;
using LetsGo.Models.Responses;
using LetsGo.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LetsGo.Web.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/account")]
    public class UserServiceController : ApiController
    {
        public UserServiceController(IUserService UserService, IAuthenticationService authenticationService, IDataProvider dataProvider)
        {
            _userService = UserService;
            _authenticationService = authenticationService;
            _dataProvider = dataProvider;
        }

        private IUserService _userService;
        private IAuthenticationService _authenticationService;
        private IDataProvider _dataProvider;

        [HttpPost]
        [Route("register")]
        public HttpResponseMessage Register(UserRegisterRequest model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = new ItemResponse<int>();
                    resp.Item = _userService.Register(model);
                    //log.Info("Register successful");
                    //_sendgridservice.SendAccountConfirmation(model);
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                //log.Warn("Registration failed", ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("login")]
        public HttpResponseMessage Login(UserLoginRequest model)
        {
            UserAccountDomain user = new UserAccountDomain();
            this._dataProvider.ExecuteCmd(
                "user_select_by_email",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Email", model.Email);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int idx = 0;
                    user.Id = reader.GetInt32(idx++);
                    user.FirstName = reader.GetString(idx++);
                    user.LastName = reader.GetString(idx++);
                    user.Email = reader.GetString(idx++);
                    user.Salt = reader.GetString(idx++);
                    user.PasswordHash = reader.GetString(idx++);
                    user.EmailConfirmed = reader.GetBoolean(idx++);
                }
            );
            try
            {
                if (ModelState.IsValid && user.EmailConfirmed)
                {
                    var resp = new ItemResponse<IUserAuthData>();
                    resp.Item = _userService.ActualLogin(model);
                    //log.Info("Login successful");
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                //log.Warn("Login failed", ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("logout")]
        public HttpResponseMessage Logout()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var resp = new ItemResponse<bool>();
                    resp.Item = _userService.Logout();
                    //log.Info("Logout successful");
                    return Request.CreateResponse(HttpStatusCode.OK, resp);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
            }
            catch (Exception ex)
            {
                //log.Warn("Logout failed", ex);
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

    }
}
