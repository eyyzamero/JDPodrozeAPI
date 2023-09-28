using AutoMapper;
using JDPodrozeAPI.Core.Contexts;
using JDPodrozeAPI.Core.DTOs.Newsletter;
using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;

namespace JDPodrozeAPI.Services
{
    public class NewsletterService : INewsletterService
    {
        private readonly IMapper _mapper;
        private readonly NewsletterDbContext _newsletterDbContext;

        public NewsletterService(IMapper mapper, NewsletterDbContext newsletterDbContext)
        {
            _mapper = mapper;
            _newsletterDbContext = newsletterDbContext;
        }

        public void Enroll(INewsletterServiceEnrollReq request)
        {
            NewsletterDTO newsletter = _mapper.Map<NewsletterDTO>(request);
            _newsletterDbContext.Newsletters.Add(newsletter);
            _newsletterDbContext.SaveChanges();
        }
    }
}