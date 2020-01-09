using System.Linq;
using apiquestions.Models;
using apiquestions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiquestions.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AnswerController : ControllerBase
  {

    // GET ALL THE Answers

    [HttpGet]
    public ActionResult GetAllAnswers()
    {
      var db = new DatabaseContext();
      return Ok(db.Answers.OrderBy(o => o.AnswerString));
    }


    
    [HttpPost]
    public ActionResult CreateAnswer(NewAnswerViewModel answer)
    {
      var aw = new Answer
      {
        AnswerString = answer.AnswerString,
        QuestionId = answer.QuestionId,
        VoteAnswer = answer.VoteAnswer,
        
      };
      var db = new DatabaseContext();
      db.Answers.Add(aw);
      db.SaveChanges();
      return Ok(aw); 
    }

    // TODO: SEARCH 

    [HttpGet("{id}")]
    public ActionResult GetAnswer(int id)
    {
      var db = new DatabaseContext();
      var answer = db.Answers.Include(i => i.Question).FirstOrDefault(f => f.Id == id);
      if (answer == null)
      {
        return NotFound(new NotFoundResponse
        {
          Message = "A Answer with that id was not found",
          QueryId = id
        });
      }
      else
      {
        return Ok(answer);
      }
    }
  }
}