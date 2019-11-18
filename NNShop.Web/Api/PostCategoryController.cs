using AutoMapper;
using NNShop.Model.Models;
using NNShop.Service;
using NNShop.Web.Infrastructure.Core;
using NNShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NNShop.Web.Infrastructure.Extensions;

namespace NNShop.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private readonly IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) :
            base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        public HttpResponseMessage Create(HttpRequestMessage request, PostCategoryViewModel postcategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    PostCategory newpost = new PostCategory();
                    newpost.UpdatePostCategory(postcategoryVM);
                    var category = _postCategoryService.Add(newpost);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK, category);
                }
                return response;
            });
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var lstCategory = _postCategoryService.GetAll();
                var lstCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(lstCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, lstCategoryVm);
                return response;
            });
        }

        [Route("Update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postcategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var postCategory = Mapper.Map<PostCategory>(postcategoryVM);
                    _postCategoryService.Update(postCategory);
                    _postCategoryService.Save();
                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                return response;
            });
        }
    }
}