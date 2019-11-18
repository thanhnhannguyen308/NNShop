using AutoMapper;
using NNShop.Model.Models;
using NNShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NNShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Post, PostViewModel>();
                cfg.CreateMap<PostCategory, PostCategoryViewModel>();
                cfg.CreateMap<PostTag, PostTagViewModel>();
                cfg.CreateMap<Tag, TagViewModel>();
            });
        }
    }
}