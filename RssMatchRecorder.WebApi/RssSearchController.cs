using System;
using System.Collections.Generic;
using System.Web.Http;
using RssMatchRecorder.DataAccess;
using RssMatchRecorder.DataAccess.Entities;

namespace RssMatchRecorder.WebApi
{
    public class RssSearchController : ApiController
    {
        public RssSearchController(IRssRepository rssRepository)
        {
            RssRepository = rssRepository;
        }

        private IRssRepository RssRepository { get; }
        // GET api/<controller>

        [HttpGet]
        public IEnumerable<RssPost> Search([FromUri] int? feedId, [FromUri] string keyword,
            [FromUri] DateTime? startDate, [FromUri] DateTime? endDate)
        {
            if (startDate == null && endDate == null)
            {
                startDate = DateTime.Now.Date;
                endDate = DateTime.Now.Date.AddDays(1);
            }

            var results = RssRepository.Search(feedId, keyword, startDate, endDate);

            return results;
        }
    }
}