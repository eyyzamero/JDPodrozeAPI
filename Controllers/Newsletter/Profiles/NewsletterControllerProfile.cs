﻿using AutoMapper;
using JDPodrozeAPI.Controllers.Newsletter.Contracts.Requests;
using JDPodrozeAPI.Services.Newsletter.Contracts.Requests;

namespace JDPodrozeAPI.Controllers.Newsletter.Profiles
{
    public class NewsletterControllerProfile : Profile
    {
        public NewsletterControllerProfile()
        {
            CreateMap<NewsletterEnrollReq, NewsletterServiceEnrollReq>();
            CreateMap<NewsletterEnrollReq, INewsletterServiceEnrollReq>().AsProxy()
                .ConvertUsing((src, dest, context) => context.Mapper.Map<NewsletterServiceEnrollReq>(src));
        }
    }
}