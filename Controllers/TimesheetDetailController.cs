using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimesheetApplication.Models;

namespace TimesheetApplication.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TimesheetDetailController : Controller
  {
    private readonly RegistrationDetailContext _context;

    public TimesheetDetailController(RegistrationDetailContext context)
    {
      _context = context;
    }


    // GET: api/TimesheetDetail
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TimesheetDetail>>> GetTimesheetDetails()
    {
      return await _context.TimesheetDetails.ToListAsync();
    }
        
    // PUT: api/TimesheetDetail/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTimesheetDetail(int id, TimesheetDetail timesheetDetail)
    {
      if (id != timesheetDetail.Id)
      {
        return BadRequest();
      }
      _context.Entry(timesheetDetail).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TimesheetDetailExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    // GET: api/TimesheetDetail/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TimesheetDetail>> GetTimesheetDetail(int id)
    {
      var timesheetDetail = await _context.TimesheetDetails.FindAsync(id);

      if (timesheetDetail == null)
      {
        return NotFound();
      }

      return timesheetDetail;
    }

    // POST: api/TimesheetDetail
    [HttpPost]
    public async Task<ActionResult<TimesheetDetail>> PostTimesheetDetail(TimesheetDetail timesheetDetail)
    {
      _context.TimesheetDetails.Add(timesheetDetail);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetTimesheetDetail", new { id = timesheetDetail.Id }, timesheetDetail);
    }

    // DELETE: api/TimesheetDetail/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<TimesheetDetail>> DeleteTimesheetDetail(int id)
    {
      var timesheetDetail = await _context.TimesheetDetails.FindAsync(id);
      if (timesheetDetail == null)
      {
        return NotFound();
      }

      _context.TimesheetDetails.Remove(timesheetDetail);
      await _context.SaveChangesAsync();

      return timesheetDetail;
    }

    private bool TimesheetDetailExists(int id)
    {
      return _context.TimesheetDetails.Any(e => e.Id == id);
    }
  }
}
