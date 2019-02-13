using LetsGo.Models.Domain;
using LetsGo.Models.Requests;
using LetsGo.Models.ViewModels;
using LetsGo.Services.Interfaces;
using LetsGo.Data;
using LetsGo.Data.Providers;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LetsGo.Services.FileStorage
{
    public class FileStorageService : IFileStorageService
    {
        IDataProvider _dataProvider;

        public int Create(FileStorageAddRequest fileStorageAddRequest)
        {
            int returnVal = 0;
            _dataProvider.ExecuteNonQuery(
                "file_storage_create",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    SqlParameter parm = new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };
                    paramCol.Add(parm);
                    paramCol.AddWithValue("@UserFileName", fileStorageAddRequest.UserFileName);
                    paramCol.AddWithValue("@BasePath", fileStorageAddRequest.BasePath);
                    paramCol.AddWithValue("@SystemFileName", fileStorageAddRequest.SystemFileName);
                    paramCol.AddWithValue("@UserId", fileStorageAddRequest.UserId);
                    paramCol.AddWithValue("@ModifiedBy", fileStorageAddRequest.ModifiedBy);
                },
                returnParameters: delegate (SqlParameterCollection paramCol)
                {
                    returnVal = (int)paramCol["@Id"].Value;
                }
            );
            return returnVal;
        }

        public FileStorageViewModel SelectById(int Id)
        {
            FileStorageDomain rawData = new FileStorageDomain();
            _dataProvider.ExecuteCmd(
                "file_storage_select_by_id",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", Id);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int idx = 0;
                    rawData.Id = reader.GetSafeInt32(idx++);
                    rawData.UserFileName = reader.GetSafeString(idx++);
                    rawData.BasePath = reader.GetSafeString(idx++);
                    rawData.SystemFileName = reader.GetSafeString(idx++);
                    rawData.UserId = reader.GetSafeInt32(idx++);
                    rawData.CreatedDate = reader.GetSafeDateTime(idx++);
                    rawData.ModifiedDate = reader.GetSafeDateTime(idx++);
                    rawData.ModifiedBy = reader.GetSafeString(idx++);
                }
            );

            FileStorageViewModel viewModelResp = new FileStorageViewModel
            {
                    Id = rawData.Id,
                    UserFileName = rawData.UserFileName,
                    Url = "https://LetsGo-training.s3.us-west-2.amazonaws.com/" + rawData.BasePath + rawData.SystemFileName,
                    UserId = rawData.UserId,
                    ModifiedDate = rawData.ModifiedDate,
                    ModifiedBy = rawData.ModifiedBy
            };


            return viewModelResp;
        }

        public List<FileStorageViewModel> SelectByUserId(int userId)
        {
            List<FileStorageDomain> rawData = new List<FileStorageDomain>();
            _dataProvider.ExecuteCmd(
                "file_storage_select_by_user_id",
                inputParamMapper: delegate(SqlParameterCollection paramCol) {
                    paramCol.AddWithValue("@UserId", userId);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    FileStorageDomain model = new FileStorageDomain();
                    int idx = 0;
                    model.Id = reader.GetSafeInt32(idx++);
                    model.UserFileName = reader.GetSafeString(idx++);
                    model.BasePath = reader.GetSafeString(idx++);
                    model.SystemFileName = reader.GetSafeString(idx++);
                    model.UserId = reader.GetSafeInt32(idx++);
                    model.CreatedDate = reader.GetSafeDateTime(idx++);
                    model.ModifiedDate = reader.GetSafeDateTime(idx++);
                    model.ModifiedBy = reader.GetSafeString(idx++);
                    rawData.Add(model);
                }
            );

            List<FileStorageViewModel> viewModelResp = new List<FileStorageViewModel>();
            for (int i = 0; i < rawData.Count; i++)
            {
                viewModelResp.Add(new FileStorageViewModel
                {
                    Id = rawData[i].Id,
                    UserFileName = rawData[i].UserFileName,
                    Url = "https://LetsGo-training.s3.us-west-2.amazonaws.com/" + rawData[i].BasePath + rawData[i].SystemFileName,
                    UserId = rawData[i].UserId,
                    ModifiedDate = rawData[i].ModifiedDate,
                    ModifiedBy = rawData[i].ModifiedBy
                });
            };


            return viewModelResp;
        }
               
        public List<FileStorageViewModel> SelectAll()
        {
            List<FileStorageDomain> rawData = new List<FileStorageDomain>();
            _dataProvider.ExecuteCmd(
                "file_storage_select_all",
                inputParamMapper: null,
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    FileStorageDomain model = new FileStorageDomain();
                    int idx = 0;
                    model.Id = reader.GetSafeInt32(idx++);
                    model.UserFileName = reader.GetSafeString(idx++);
                    model.BasePath = reader.GetSafeString(idx++);
                    model.SystemFileName = reader.GetSafeString(idx++);
                    model.UserId = reader.GetSafeInt32(idx++);
                    model.CreatedDate = reader.GetSafeDateTime(idx++);
                    model.ModifiedDate = reader.GetSafeDateTime(idx++);
                    model.ModifiedBy = reader.GetSafeString(idx++);
                    rawData.Add(model);
                }
            );

            List<FileStorageViewModel> viewModelResp = new List<FileStorageViewModel>();
            for (int i = 0; i < rawData.Count; i++)
            {
                viewModelResp.Add(new FileStorageViewModel
                {
                    Id = rawData[i].Id,
                    UserFileName = rawData[i].UserFileName,
                    Url = "https://LetsGo-training.s3.us-west-2.amazonaws.com/" + rawData[i].BasePath + rawData[i].SystemFileName,
                    UserId = rawData[i].UserId,
                    ModifiedDate = rawData[i].ModifiedDate,
                    ModifiedBy = rawData[i].ModifiedBy
                });
            };


            return viewModelResp;
        }

        public void Update(FileStorageUpdateRequest model)
        {
            _dataProvider.ExecuteNonQuery(
                "file_storage_update",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", model.Id);
                    paramCol.AddWithValue("@UserFileName", model.UserFileName);
                    paramCol.AddWithValue("@BasePath", model.BasePath);
                    paramCol.AddWithValue("@SystemFileName", model.SystemFileName);
                    paramCol.AddWithValue("@UserId", model.UserId);
                    paramCol.AddWithValue("@ModifiedBy", model.ModifiedBy);
                }
            );
        }

        public void Delete(int Id)
        {
            _dataProvider.ExecuteNonQuery(
                "file_storage_delete",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", Id);
                }
            );
        }


        public FileStorageDomain SelectByIdDelete(int Id)
        {
            FileStorageDomain rawData = new FileStorageDomain();
            _dataProvider.ExecuteCmd(
                "file_storage_select_by_id",
                inputParamMapper: delegate (SqlParameterCollection paramCol)
                {
                    paramCol.AddWithValue("@Id", Id);
                },
                singleRecordMapper: delegate (IDataReader reader, short set)
                {
                    int idx = 0;
                    rawData.Id = reader.GetSafeInt32(idx++);
                    rawData.UserFileName = reader.GetSafeString(idx++);
                    rawData.BasePath = reader.GetSafeString(idx++);
                    rawData.SystemFileName = reader.GetSafeString(idx++);
                    rawData.UserId = reader.GetSafeInt32(idx++);
                    rawData.CreatedDate = reader.GetSafeDateTime(idx++);
                    rawData.ModifiedDate = reader.GetSafeDateTime(idx++);
                    rawData.ModifiedBy = reader.GetSafeString(idx++);
                }
            );
        
            return rawData;
        }



        public FileStorageService(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
    }
}
