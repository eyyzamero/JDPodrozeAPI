using JDPodrozeAPI.Services.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;

namespace JDPodrozeAPI.Services.Excursions
{
    public interface IExcursionsService
    {
        public Task<IExcursionsServiceGetImageRes> GetImage(int fileId);
        public IExcursionsServiceGetItemRes? GetItem(int id);
        public IExcursionsServiceGetListRes GetList();
        public IExcursionsServiceGetListShortRes GetListShort();
        public void Add(ExcursionsServiceAddReq request);
        public void Edit(ExcursionsServiceEditReq request);
        public void Delete(int id);
        public Guid? Enroll(IExcursionsServiceEnrollReq request);
    }
}