using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public interface INewsletterService
    {
        void Enroll(INewsletterServiceEnrollReq request);
    }
}