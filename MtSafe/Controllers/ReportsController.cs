using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MtSafe.Models;
using Microsoft.EntityFrameworkCore;

namespace MtSafe.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReportsController : ControllerBase
  {
    private MtSafeContext _db; 
    public ReportsController(MtSafeContext db)
    {
      _db = db; 
    }
    //GET api/reports
    [HttpGet]
    public ActionResult<IEnumerable<Report>> Get()
    {
      return _db.Reports.ToList();
    }
    //POST api/reports
    [HttpPost]
    public void Post([FromBody] Report report)
    {
      _db.Reports.Add(report);
      _db.SaveChanges();
    }
    //GET api/reports/{id}
    [HttpGet("{id}")]
    public ActionResult<Report> Get(int id)
    {
      return _db.Reports.FirstOrDefault(e => e.ReportId == id);
    }
    // PUT api/reports/{id}
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Report report)
    {
      report.ReportId = id;
      _db.Entry(report).State = EntityState.Modified;
      _db.SaveChanges(); 
    }
    // DELETE api/reports/{id}
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var reportToDelete = _db.Reports.FirstOrDefault(e => e.ReportId == id);
      _db.Reports.Remove(reportToDelete);
      _db.SaveChanges();
    }
  }
}