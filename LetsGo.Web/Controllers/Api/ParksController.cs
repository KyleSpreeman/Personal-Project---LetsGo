using HtmlAgilityPack;
using LetsGo.Data.Providers;
using LetsGo.Models.Domain;
using LetsGo.Models.Responses;
using LetsGo.Services;
using LetsGo.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LetsGo.Web.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/parks")]
    public class ParksController : ApiController
    {
        public ParksController(IUserService UserService, IAuthenticationService authenticationService, IDataProvider dataProvider, IParksService parksService)
        {
            _userService = UserService;
            _authenticationService = authenticationService;
            _dataProvider = dataProvider;
            _parksService = parksService;
        }

        private IUserService _userService;
        private IAuthenticationService _authenticationService;
        private IDataProvider _dataProvider;
        private IParksService _parksService;


        [HttpGet]
        [Route("scrape")]
        public HttpResponseMessage WebScraper()
        {
            try { 
                var html = @"https://rootsrated.com/stories/a-beginner-s-guide-to-camping-gear";

                HtmlWeb web = new HtmlWeb();

                var htmlDoc = web.Load(html);

                var node = htmlDoc.DocumentNode.SelectSingleNode("/html/body/div[1]/div/div[2]/div/main/div[3]/article/div/div[1]/div[1]/div[2]/div");

                var resp = (node.OuterHtml);

                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpPost]
        [Route("")]
        public  HttpResponseMessage insertPark(ParkDomain model)
        {
            try
            {
                _parksService.savePark(model);
                SuccessResponse resp = new SuccessResponse();
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage SelectAllByUserId()
        {
            try
            {
                ItemsResponse<ParkDomain> resp = new ItemsResponse<ParkDomain>();
                resp.Items = _parksService.SelectAllByUserId();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
              return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        [Route("{ParkCode}")]
        public HttpResponseMessage DeleteSavedPark(string ParkCode)
        {
            try
            {
                _parksService.DeleteSavedPark(ParkCode);
                SuccessResponse resp = new SuccessResponse();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
