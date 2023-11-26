using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using GreenHarborApi.Models;
using GreenHarborApi.Interfaces;

namespace GreenHarborApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CompostsController : ControllerBase
  {
    private readonly GreenHarborApiContext _db;
    private readonly ICompostRepository _repository;

    public CompostsController(GreenHarborApiContext db, ICompostRepository repository)
    {
      _db = db;
      _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Compost>>> GetComposts(string city, string zip)
    {
      IQueryable<Compost> query = _db.Composts.AsQueryable();

      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }

      if (zip != null)
      {
        query = query.Where(entry => entry.Zip == zip);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Compost>> GetCompost(int id)
    {
      Compost compost = await _db.Composts.FindAsync(id);

      if (compost == null)
      {
        return NotFound();
      }
      return compost;
    }
    
    [HttpGet]
    [Route("paging-filter")]
    public IActionResult GetCompostPagingData ([FromQuery] PagedParameters compostParameters)
    {
       var compost = _repository.GetComposts(compostParameters);

       var metadata = new
       {
          compost.TotalCount,
          compost.PageSize,
          compost.CurrentPage,
          compost.TotalPages,
          compost.HasNext,
          compost.HasPrevious
       };
       
       Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

       return Ok(compost);
    }
    
    [HttpGet]
    [Route("getpaging-by-param")]
    public async Task<ActionResult<IEnumerable<Compost>>> GetCompostsByFilter(PagedParameters compostParameters)
    {
        if (_db.Composts == null)
        {
            return NotFound();
        }
          return await _db.Composts.OrderBy(on => on.CompostId)
          .Skip((compostParameters.PageNumber -1) * compostParameters.PageSize)
          .Take(compostParameters.PageSize).ToListAsync();
    }
    
    [HttpPost]
    public async Task<ActionResult<Compost>> Post(Compost compost)
    {
      _db.Composts.Add(compost);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetCompost), new { id = compost.CompostId }, compost);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Compost compost)
    {
      if (id != compost.CompostId)
      {
        return BadRequest();
      }
      
      _db.Composts.Update(compost);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CompostExists(id))
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
  
    private bool CompostExists(int id)
    {
      return _db.Composts.Any(e => e.CompostId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompost(int id)
    {
      Compost compost = await _db.Composts.FindAsync(id);
      if (compost == null)
      {
        return NotFound();
      }
      
      _db.Composts.Remove(compost);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}