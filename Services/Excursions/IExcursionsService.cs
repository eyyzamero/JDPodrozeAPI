using JDPodrozeAPI.Controllers.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Requests;
using JDPodrozeAPI.Services.Excursions.Contracts.Responses;

namespace JDPodrozeAPI.Services.Excursions
{
    public interface IExcursionsService
    {
        public Task<byte[]> GetImageNew(int fileId, string resolution, string extension);
        public Task<IExcursionsServiceGetItemRes?> GetItem(int id, bool images);
        public IExcursionsServiceGetListRes GetList(IExcursionsGetListReq request);
        public IExcursionsServiceGetListShortRes GetListShort();
        public Task Add(ExcursionsServiceAddReq request);
        public Task Edit(ExcursionsServiceEditReq request);
        public Task ChangeToTemplate(int id);
        public void Delete(int id);
        public Guid? Enroll(IExcursionsServiceEnrollReq request);
    }
}