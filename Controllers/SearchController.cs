using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiquestions.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiquestions.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SearchController : ControllerBase
  {
    private readonly DatabaseContext db;

    public SearchController(DatabaseContext context)
    {
      this.db = context;
    }

    [HttpGet]
    public async Task<ActionResult> SearchQuestions([FromQuery]string searchTerm)
    {

      var results = db.Questions
        .Where(question =>
            question.QuestionString.ToLower().Contains(searchTerm.ToLower()) 
          //  question.VoteQuestion.Contains(searchTerm) 
            
            
        );
      var query = new SearchQuery
      {
        SearchTerm = searchTerm
      };
      db.SearchQueries.Add(query);
      //   db.SaveChanges();
      await db.SaveChangesAsync();
      return Ok(results);
    }


    [HttpGet("queries")]
    public async Task<ActionResult> GetRecentSearchQueries()
    {
      var queries = db.SearchQueries.OrderByDescending(o => o.Timestamp).Take(10);
      return Ok(queries);
    }
  }
}