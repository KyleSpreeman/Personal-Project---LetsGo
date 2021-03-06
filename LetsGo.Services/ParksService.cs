using LetsGo.Models.Domain;
using LetsGo.Data;
using LetsGo.Data.Providers;
using LetsGo.Models;
using LetsGo.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Services.Services
{
    public class ParksService : IParksService
    {
        IDataProvider _dataProvider;
        private IAuthenticationService _authService;

        public ParkDomain savePark(ParkDomain model)
        {
            IUserAuthData currentUser;
            currentUser = _authService.GetCurrentUser();
            _dataProvider.ExecuteNonQuery(
                "save_park_upsert",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {

                    paramList.AddWithValue("@UserId", currentUser.Id);
                    paramList.AddWithValue("@ParkCode", model.ParkCode);
                });
            return model;
        }

        public List<ParkDomain> SelectAllByUserId()
        {
            IUserAuthData currentUser;
            currentUser = _authService.GetCurrentUser();
            List<ParkDomain> newModel = new List<ParkDomain>();
            _dataProvider.ExecuteCmd(
                "select_all_saved_parks",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    paramList.AddWithValue("@userId", currentUser.Id);
                },
               singleRecordMapper: delegate (IDataReader reader, short set)
               {
                   ParkDomain model = new ParkDomain();
                   int idx = 0;
                   model.UserId = reader.GetSafeInt32(idx++);
                   model.FirstName = reader.GetSafeString(idx++);
                   model.ParkCode = reader.GetSafeString(idx++);
                   newModel.Add(model);
               });
            return newModel;
        }

        public void DeleteSavedPark(string ParkCode)
        {
            IUserAuthData currentUser;
            currentUser = _authService.GetCurrentUser();
            _dataProvider.ExecuteNonQuery(
                "delete_saved_park",
                inputParamMapper: delegate (SqlParameterCollection paramList)
                {
                    paramList.AddWithValue("@UserId", currentUser.Id);
                    paramList.AddWithValue("@ParkCode", ParkCode);
                });
        }


        public ParksService(IDataProvider dataProvider, IAuthenticationService authService)
        {
            _dataProvider = dataProvider;
            _authService = authService;
        }

    }
}
