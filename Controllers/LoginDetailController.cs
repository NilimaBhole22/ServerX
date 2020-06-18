using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimesheetApplication.Models;

namespace TimesheetApplication.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class LoginDetailController : ControllerBase
  {
    private readonly RegistrationDetailContext _context;

    public LoginDetailController(RegistrationDetailContext context)
    {
      _context = context;
    }


    // GET: api/LoginDetail
    [HttpGet]
    public ActionResult GetLoginDetails()
    {
      var loginDetails = new List<LoginDetail>();
      loginDetails = _context.LoginDetails.ToList();
      return Ok(loginDetails);

    }


    //// GET: api/TimesheetDetail
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<TimesheetDetail>>> GetTimesheetDetails()
    //{
    //  return await _context.TimesheetDetails.ToListAsync();
    //}



    //// Post: api/LoginDetail
    //[HttpPost]
    //public async Task<ActionResult<LoginDetail>> PostLoginDetail(LoginDetail model)
    //{
    //  var loginResults = false;
    //  if (ModelState.IsValid)
    //  {

    //    var registerData = await _context.RegistrationDetails.ToListAsync();
    //    foreach(var item in registerData)
    //    {
    //      if(item.Username == model.Username && item.Password == model.Password)
    //      {
    //        loginResults = true;
    //        return RedirectToAction("Index", "LoggedIn");
    //      }
    //      else
    //      {
    //        //return RedirectToAction("Index", "LoggedIn");
    //      }
    //    }

    //  }
    //  return model;
    //}



    // Post: api/LoginDetail
    [HttpPost]
    public Boolean PostLoginDetail(LoginDetail model)
    {
      var loginResults = false;
      if (ModelState.IsValid)
      {

        var registerData = _context.RegistrationDetails.ToList();
        foreach (var item in registerData)
        {
          if (item.Username == model.Username && item.Password == model.Password)
          {
            var loginDetail = _context.LoginDetails.FirstOrDefault();
            if(loginDetail != null)
            {
              _context.LoginDetails.Remove(loginDetail);
            }
            _context.LoginDetails.Add(model);
            _context.SaveChanges();
            loginResults = true;
            return loginResults;
            //return RedirectToAction("Index", "LoggedIn");
          }
          else
          {
            loginResults = false;
            //return RedirectToAction("Index", "LoggedIn");
          }
        }

      }
      return loginResults;
    }


  }
}
