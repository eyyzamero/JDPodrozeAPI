using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public interface INewsletterService
    {
        Task EnrollAsync(INewsletterServiceEnrollReq request);
    }
}