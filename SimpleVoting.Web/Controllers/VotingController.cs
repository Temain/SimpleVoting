using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleVoting.Logic.Interfaces;
using SimpleVoting.Logic.Models;

namespace SimpleVoting.Web.Controllers
{
    [RoutePrefix("api/voting")]
    public class VotingController : ApiController
    {
        private readonly IVotingService _votingService;
        private readonly IDictionaryService _dictionaryService;

        public VotingController(IVotingService votingService, IDictionaryService dictionaryService)
        {
            _votingService = votingService;
            _dictionaryService = dictionaryService;
        }

        // GET: api/voting
        public IHttpActionResult GetVote()
        {
            var vote = new VoteViewModel();

            // Перенести в VotingService
            var genders = _dictionaryService.GetGenders();

            // Тут другие необходимые справочники...

            return Ok(vote);
        }

        // POST: api/voting
        public IHttpActionResult PostVote(VoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Genders.Add(gender);
            //db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = gender.GenderId }, gender);

            return null;
        }
    }
}
