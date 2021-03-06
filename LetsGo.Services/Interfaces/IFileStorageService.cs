using System.Collections.Generic;
using LetsGo.Models.Requests;
using LetsGo.Models.ViewModels;
using LetsGo.Models.Domain;

namespace LetsGo.Services.Interfaces
{
    public interface IFileStorageService
    {
        int Create(FileStorageAddRequest fileStorageAddRequest);
        void Delete(int Id);
        FileStorageDomain SelectByIdDelete(int Id);
        List<FileStorageViewModel> SelectAll();
        List<FileStorageViewModel> SelectByUserId(int userId);
        FileStorageViewModel SelectById(int Id);
        void Update(FileStorageUpdateRequest model);
    }
}
