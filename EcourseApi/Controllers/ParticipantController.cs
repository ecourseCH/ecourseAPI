using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcourseApi.Models;
using EcourseApi.Persistence;
using EcourseApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcourseApi.Controllers
{
    [Route("api/[controller]")]
    public class ParticipantController : Controller
    {
        private readonly EcourseDbContext _dbContext;

        public ParticipantController (EcourseDbContext dbContext){
            _dbContext = dbContext;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<ParticipantOverviewViewModel> Get()
        {
            return _dbContext.Participants.Select(p => new ParticipantOverviewViewModel(p));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Participant Get(int id)
        {
          
            return _dbContext.Participants.
                             Include(x => x.Notices)
                             .FirstOrDefault(p => p.Id == id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Participant participant)
        {
            //participants.
            //participants.Add(participant);
            if (participant == null)
            {
                return BadRequest();
            }
            _dbContext.Participants.Add(participant);
            _dbContext.SaveChanges();

            return new NoContentResult();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Participant participant)
        {
            if (participant == null || participant.Id != id)
            {
                return BadRequest();
            }

            var dbParticipant = _dbContext.Participants.FirstOrDefault(t => t.Id == id);
            if (dbParticipant == null)
            {
                return NotFound();
            }

            dbParticipant.PreName = participant.PreName;
            dbParticipant.Name = participant.Name;
            dbParticipant.ScoutName = participant.ScoutName;


            _dbContext.Participants.Update(dbParticipant);
            _dbContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var participant = _dbContext.Participants.Include(p => p.Notices).FirstOrDefault(p => p.Id == id);

            if (participant == null) return NotFound();

            participant.Notices?.ForEach(notice => _dbContext.Notice.Remove(notice));
            _dbContext.Participants.Remove(participant);
            _dbContext.SaveChanges();
            return new NoContentResult();
        }
    }
}
