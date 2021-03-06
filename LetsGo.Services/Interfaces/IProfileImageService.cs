using System.Collections.Generic;
using LetsGo.Models.Domain;
using LetsGo.Models.Requests;

namespace LetsGo.Services.Services
{
    public interface IProfileImageService
    {
        int Create(ProfileImageAddRequest profileImageAddRequest);
        void Delete(int id);
        List<ProfileImageDomain> SelectAll();
        ProfileImageDomain SelectById(int Id);
        List<ProfileImageDomain> SelectByProfileId(int profileId);
        void Update(ProfileImageUpdateRequest model);
    }
}
