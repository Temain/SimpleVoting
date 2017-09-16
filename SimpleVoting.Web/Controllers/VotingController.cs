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
        private readonly IReportingService _reportingService;

        public VotingController(IVotingService votingService, IReportingService reportingService)
        {
            _votingService = votingService;
            _reportingService = reportingService;
        }

        // GET: api/voting
        public IHttpActionResult GetVote()
        {
            var vote = _votingService.GetVote();

            return Ok(vote);
        }

        // POST: api/voting
        public IHttpActionResult PostVote(VoteViewModel viewModel)
        {
            if (!ModelState.IsValid | !IsValidVote(viewModel))
            {
                return BadRequest(ModelState);
            }

            _votingService.SaveVote(viewModel);

            return Ok();
        }

        private bool IsValidVote(VoteViewModel viewModel)
        {
            _votingService.ValidateVote(viewModel, out List<string> errorMessages);

            if (errorMessages.Any())
            {
                foreach (var errorMessage in errorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }

                return false;
            }

            return true;
        }

        [HttpGet]
        [Route("results")]
        public IHttpActionResult Results()
        {
            var numberOfVoters = _reportingService.GetNumberOfVoters();

            return Ok(numberOfVoters);
        }
    }
}
