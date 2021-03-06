using LetsGo.Models.Domain;
using LetsGo.Models.Requests;
using LetsGo.Data;
using LetsGo.Data.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetsGo.Services.Services
{
    public class ProfileImageService : IProfileImageService
    {
        IDataProvider _dataProvider;

        public int Create(ProfileImageAddRequest profileImageAddRequest)
        {
            int returnVal = 0;
            _dataProvider.ExecuteNonQuery(
                "profile_image_create",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    SqlParameter parm = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    paramCol.Add(parm);
                    paramCol.AddWithValue("@ProfileId", profileImageAddRequest.ProfileId);
                    paramCol.AddWithValue("@FileStorageId", profileImageAddRequest.FileStorageId);
                },
                returnParameters: delegate (SqlParameterCollection paramCol)
                {
                    returnVal = (int)paramCol["@Id"].Value;
                }
            );
            return returnVal;
        }

        public ProfileImageDomain SelectById(int Id)
        {
            ProfileImageDomain returnVal = new ProfileImageDomain();
            _dataProvider.ExecuteCmd(
                "profile_image_select_by_id",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", Id);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int idx = 0;
                    returnVal.Id = reader.GetSafeInt32(idx++);
                    returnVal.ProfileId = reader.GetSafeInt32(idx++);
                    returnVal.FileStorageId = reader.GetSafeInt32(idx++);
                }
                );
            return returnVal;
        }

        public List<ProfileImageDomain> SelectByProfileId(int profileId)
        {
            List<ProfileImageDomain> returnVal = new List<ProfileImageDomain>();
            _dataProvider.ExecuteCmd(
                "profile_image_select_by_profileId",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@ProfileId", profileId);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    ProfileImageDomain model = new ProfileImageDomain();
                    int idx = 0;
                    model.Id = reader.GetSafeInt32(idx++);
                    model.ProfileId = reader.GetSafeInt32(idx++);
                    model.FileStorageId = reader.GetSafeInt32(idx++);
                    returnVal.Add(model);
                }
                );
            return returnVal;
        }

        public List<ProfileImageDomain> SelectAll()
        {
            List<ProfileImageDomain> result = new List<ProfileImageDomain>();
            _dataProvider.ExecuteCmd(
                "profile_image_select_all",
                inputParamMapper: null,
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    ProfileImageDomain model = new ProfileImageDomain();
                    int idx = 0;
                    model.Id = reader.GetSafeInt32(idx++);
                    model.ProfileId = reader.GetSafeInt32(idx++);
                    model.FileStorageId = reader.GetSafeInt32(idx++);
                    result.Add(model);
                }
            );
            return result;
        }

        public void Update(ProfileImageUpdateRequest model)
        {
            _dataProvider.ExecuteNonQuery(
                "profile_image_update",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", model.Id);
                    paramCol.AddWithValue("@ProfileId", model.ProfileId);
                    paramCol.AddWithValue("@FileStorageId", model.FileStorageId);
                }
            );
        }

        public void Delete(int id)
        {
            _dataProvider.ExecuteNonQuery(
                "profile_image_delete",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", id);
                }
            );
        }

        public ProfileImageService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
