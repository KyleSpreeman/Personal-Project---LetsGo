using LetsGo.Models.Domain;
using System.Collections.Generic;

namespace LetsGo.Services.Services
{
    public interface IParksService
    {
        ParkDomain savePark(ParkDomain ParkDomain);
        List<ParkDomain> SelectAllByUserId();
        void DeleteSavedPark(string ParkCode);
    }
}
