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
  public class RegistrationDetailController : ControllerBase
  {
    private readonly RegistrationDetailContext _context;

    public RegistrationDetailController(RegistrationDetailContext context)
    {
      _context = context;
    }

    //// GET: api/RegistrationDetail
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<RegistrationDetail>>> GetRegistrationDetails()
    //{
    //  return await _context.RegistrationDetails.ToListAsync();
    //}

    //// GET: api/RegistrationDetail
    ////[HttpGet]
    //public IEnumerable<RegistrationDetail> GetRegistrationDetails()
    //{
    //  return _context.RegistrationDetails.ToList();
    //}


    // GET: api/RegistrationDetail
    [HttpGet]
    public ActionResult GetRegistrationDetails()
    {
      var registrationDetails = new List<RegistrationDetail>();
      registrationDetails = _context.RegistrationDetails.ToList();
      return Ok(registrationDetails);
      //return await Task.FromResult(registrationDetails);
      //return await _context.RegistrationDetails.ToListAsync();
    }

    ////GET: api/RegistrationDetail
    //[HttpGet]
    //public IQueryable<RegistrationDetail> GetRegistrationDetails()
    //{
    //  try
    //  {
    //    return _context.RegistrationDetails;
    //  }
    //  catch (Exception)
    //  {
    //    throw;
    //  }
    //}


    // PUT: api/RegistrationDetail/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutRegistrationDetail(int id, RegistrationDetail registrationDetail)
    {
      if (id != registrationDetail.Id)
      {
        return BadRequest();
      }
      _context.Entry(registrationDetail).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RegistrationDetailExists(id))
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

    // GET: api/RegistrationDetail/5
    [HttpGet("{id}")]
    public async Task<ActionResult<RegistrationDetail>> GetRegistrationDetail(int id)
    {
      var registrationDetail = await _context.RegistrationDetails.FindAsync(id);

      if (registrationDetail == null)
      {
        return NotFound();
      }

      return registrationDetail;
    }

    // POST: api/RegistrationDetail
    [HttpPost]
    public async Task<ActionResult<RegistrationDetail>> PostRegistrationDetail(RegistrationDetail registrationDetail)
    {
      var registerData = _context.RegistrationDetails.ToList();
      foreach (var item in registerData)
      {
        if (item.Username == registrationDetail.Username)
        {
          return NoContent();
        }
        
      }
      if (registrationDetail.Password == registrationDetail.ConfirmPassword)
      {
        _context.RegistrationDetails.Add(registrationDetail);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetRegistrationDetail", new { id = registrationDetail.Id }, registrationDetail);
      }
      else
      {
        return NotFound();
      }
      
    }

    // DELETE: api/RegistrationDetail/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<RegistrationDetail>> DeleteRegistrationDetail(int id)
    {
      var registrationDetail = await _context.RegistrationDetails.FindAsync(id);
      if (registrationDetail == null)
      {
        return NotFound();
      }

      _context.RegistrationDetails.Remove(registrationDetail);
      await _context.SaveChangesAsync();

      return registrationDetail;
    }

    private bool RegistrationDetailExists(int id)
    {
      return _context.RegistrationDetails.Any(e => e.Id == id);
    }

  }
}
