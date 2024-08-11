using AutoMapper;
using JDPodrozeAPI.Core.DTOs.Newsletter;
using JDPodrozeAPI.Core.Repositories;
using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly IMapper _mapper;
        private readonly INewsletterRepository _newsletterRepository;

        public NewsletterService(IMapper mapper, INewsletterRepository newsletterRepository)
        {
            _mapper = mapper;
            _newsletterRepository = newsletterRepository;
        }

        public Task EnrollAsync(INewsletterServiceEnrollReq request)
        {
            NewsletterDTO newsletter = _mapper.Map<NewsletterDTO>(request);
            return _newsletterRepository.AddNewsletterAsync(newsletter);
        }
    }
}