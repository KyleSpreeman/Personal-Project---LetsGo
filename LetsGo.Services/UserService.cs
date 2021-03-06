using LetsGo.Data;
using LetsGo.Data.Providers;
using LetsGo.Models;
using LetsGo.Models.Domain;
using LetsGo.Models.Requests;
using LetsGo.Services;
using LetsGo.Services.Cryptography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace letsgo.Services
{
    public class UserService : IUserService
    {
        private IAuthenticationService _authenticationService;
        private ICryptographyService _cryptographyService;
        private IDataProvider _dataProvider;
        private const int HASH_ITERATION_COUNT = 1;
        private const int RAND_LENGTH = 15;

        public UserService(IAuthenticationService authSerice, ICryptographyService cryptographyService, IDataProvider dataProvider)
        {
            _authenticationService = authSerice;
            _dataProvider = dataProvider;
            _cryptographyService = cryptographyService;
        }


        public bool LogIn(string email, string password)
        {
            bool isSuccessful = false;

            string salt = GetSalt(email);

            if (!String.IsNullOrEmpty(salt))
            {
                string passwordHash = _cryptographyService.Hash(password, salt, HASH_ITERATION_COUNT);

                IUserAuthData response = Get(email, passwordHash);

                if (response != null)
                {
                    _authenticationService.LogIn(response);
                    isSuccessful = true;
                }
            }

            return isSuccessful;

        }


        public bool LogInTest(string email, string password, int id, string[] roles = null)
        {
            bool isSuccessful = false;
            var testRoles = new[] { "User", "Super", "Content Manager" };

            var allRoles = roles == null ? testRoles : testRoles.Concat(roles);

            IUserAuthData response = new UserBase
            {
                Id = id
                ,
                Name = "FakeUser" + id.ToString()
                ,
                Roles = allRoles
            };

            Claim tenant = new Claim("Tenant", "Acme Corp");
            Claim fullName = new Claim("CustomClaim", "letsgo Bootcamp");

            //Login Supports multiple claims
            //and multiple roles a good an quick example to set up for 1 to many relationship
            _authenticationService.LogIn(response, new Claim[] { tenant, fullName });

            return isSuccessful;

        }


        public int Create(object userModel)
        {
            int userId = 0;
            string salt;
            string passwordHash;

            string password = "Get from user model when you have a concreate class";

            salt = _cryptographyService.GenerateRandomString(RAND_LENGTH);
            passwordHash = _cryptographyService.Hash(password, salt, HASH_ITERATION_COUNT);

            //DB provider call to create user and get us a user id

            //be sure to store both salt and passwordHash
            //DO NOT STORE the original password value that the user passed us


            return userId;
        }

        public int Register(UserRegisterRequest userRegisterRequest)
        {
            int userId = 0;
            string salt;
            string passwordHash;

            string password = userRegisterRequest.Password;

            salt = _cryptographyService.GenerateRandomString(RAND_LENGTH);
            passwordHash = _cryptographyService.Hash(password, salt, HASH_ITERATION_COUNT);

            //DB provider call to create user and get us a user id
            _dataProvider.ExecuteNonQuery(
              "user_register",
              inputParamMapper: delegate (SqlParameterCollection paramCol)
              {
                  var parm = new SqlParameter();
                  parm.ParameterName = "@Id";
                  parm.SqlDbType = System.Data.SqlDbType.Int;
                  parm.Direction = System.Data.ParameterDirection.Output;
                  paramCol.Add(parm);
                  paramCol.AddWithValue("@FirstName", userRegisterRequest.FirstName);
                  paramCol.AddWithValue("@LastName", userRegisterRequest.LastName);
                  paramCol.AddWithValue("@Email", userRegisterRequest.Email);
                  paramCol.AddWithValue("@Salt", salt);
                  paramCol.AddWithValue("@PasswordHash", passwordHash);
                  paramCol.AddWithValue("@EmailConfirmed", true);
              },
              returnParameters: delegate (SqlParameterCollection paramCol)
              {
                  userId = (int)paramCol["@Id"].Value;
              }
              );
            //be sure to store both salt and passwordHash
            //DO NOT STORE the original password value that the user passed us


            return userId;
        }

        public bool Logout()
        {
            _authenticationService.LogOut();
            return true;
        }

        public IUserAuthData ActualLogin(UserLoginRequest userLoginRequest)
        {
            bool isSuccessful = false;

            UserAccountDomain user = new UserAccountDomain();

            this._dataProvider.ExecuteCmd(
                "user_select_by_email",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Email", userLoginRequest.Email);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int idx = 0;
                    user.Id = reader.GetSafeInt32(idx++);
                    user.FirstName = reader.GetSafeString(idx++);
                    user.LastName = reader.GetSafeString(idx++);
                    user.Email = reader.GetSafeString(idx++);
                    user.Salt = reader.GetSafeString(idx++);
                    user.PasswordHash = reader.GetSafeString(idx++);
                    user.EmailConfirmed = reader.GetBoolean(idx++);
                }
            );

            var roles = new[] { "User", "Super", "Content Manager" };

            IUserAuthData response = new UserBase
            {
                Id = user.Id,
                Name = user.Email,
                Roles = roles
            };

            if (!string.IsNullOrEmpty(user.Salt))
            {
                string goodSalt = $"{user.Salt}=";
                string passwordHash = _cryptographyService.Hash(userLoginRequest.Password, goodSalt, HASH_ITERATION_COUNT);

                _authenticationService.LogIn(response);
                isSuccessful = passwordHash == user.PasswordHash;
            }

            return response;
        }

        /// <summary>
        /// Gets the Data call to get a give user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        private IUserAuthData Get(string email, string passwordHash)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Dataprovider call to get the Salt for User with the given UserName/Email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private string GetSalt(string email)
        {
            //DataProvider Call to get Salt
            throw new NotImplementedException();
        }
    }
}
