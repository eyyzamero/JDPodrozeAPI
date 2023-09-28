using AutoMapper;
using JDPodrozeAPI.Core.DTOs.Newsletter;
using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;

namespace JDPodrozeAPI.Services.Newsletter.Profiles
{
    public class NewsletterServiceRequestsProfile : Profile
    {
        public NewsletterServiceRequestsProfile()
        {
            CreateMap<NewsletterServiceEnrollReq, NewsletterDTO>();
        }
    }
}