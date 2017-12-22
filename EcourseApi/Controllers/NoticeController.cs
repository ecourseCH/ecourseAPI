using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EcourseApi.Models;
using EcourseApi.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace EcourseApi.Controllers
{
    [Route("api/[controller]")]
    public class NoticeController : Controller
    {
        private readonly EcourseDbContext _dbContext;

        public NoticeController(EcourseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST api/values
        [HttpPost("{participantId}")]
        public IActionResult Post(int participantId, [FromBody]Notice notice)
        {
            var participant = _dbContext.Participants.FirstOrDefault(p => p.Id == participantId);

            if (participant == null) return NotFound();
            participant.Notices.Add(notice);
            _dbContext.SaveChanges();
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Notice notice)
        {
            if (notice == null || notice.Id != id)
            {
                return BadRequest();
            }

            var dbNotice = _dbContext.Notice.FirstOrDefault(t => t.Id == id);
            if (dbNotice == null)
            {
                return NotFound();
            }

            dbNotice.Text = notice.Text;

            _dbContext.Notice.Update(dbNotice);
            _dbContext.SaveChanges();
            return new NoContentResult();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var notice = _dbContext.Notice.FirstOrDefault(n => n.Id == id);
            _dbContext.Notice.Remove(notice);

        }
    }
}
