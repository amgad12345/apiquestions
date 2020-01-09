using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiquestions.Models;
using apiquestions.ViewModels;

namespace apiquestions.Controllers
{

  [ApiController]
  [Route("api/[controller]")]
  public class QuestionController : ControllerBase
  {

    [HttpGet("GetAllQuestions")]
    public ActionResult GetAllQuestions()
    {
      
      var db = new DatabaseContext();
      return Ok(db.Questions.OrderBy(question => question.QuestionString));
    }


    [HttpGet("getQuest-Answer/{id}")]
    public ActionResult GetOneQuestion2(int id)
    {
      var db = new DatabaseContext();
      var question = db.Questions.Include(i => i.Answers).FirstOrDefault(qu => qu.Id == id);
      if (question == null)
      {
        return NotFound();
      }
      else
      {
        // create our json object///////////////////
        var rv = new QuestionDetails
        {
          Id = question.Id,
          QuestionString = question.QuestionString,
          VoteQuestion = question.VoteQuestion,

          Answers = question.Answers.Select(af => new CreatedAnswer
          {

            AnswerString = af.AnswerString,
            VoteAnswer = af.VoteAnswer,
     //       QuestionId = af.QuestionId,
            Id = af.Id
          }).ToList()
        };
        return Ok(rv);
      }
    }




    [HttpGet("getQuestionString/{QuestionString}")]
    public ActionResult GetByType(string QuestionString)
    {
      var db = new DatabaseContext();
      var questions = db.Questions.Where(it => it.QuestionString == QuestionString);
      if (questions == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(questions);
      }
    }

    [HttpGet("{id}")]
    public ActionResult GetOneQuestion(int id)
    {
      var db = new DatabaseContext();
      var question = db.Questions.FirstOrDefault(it => it.Id == id);
      if (question == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(question);
      }
    }

    [HttpPost]
    public ActionResult CreateQuestion(Question question)
    {
      var db = new DatabaseContext();
      question.Id = 0;
      db.Questions.Add(question);
      db.SaveChanges();
      return Ok(question);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateQuestion(Question question)
    {
      var db = new DatabaseContext();
      var prevQuestion = db.Questions.FirstOrDefault(que => que.Id == question.Id);
      if (prevQuestion == null)
      {
        return NotFound();
      }
      else
      {
        prevQuestion.QuestionString = question.QuestionString;
        prevQuestion.VoteQuestion = question.VoteQuestion;

        db.SaveChanges();
        return Ok(prevQuestion);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteQuestion(int id)
    {
      var db = new DatabaseContext();
      var question = db.Questions.FirstOrDefault(st => st.Id == id);
      if (question == null)
      {
        return NotFound();
      }
      else
      {
        db.Questions.Remove(question);
        db.SaveChanges();
        return Ok();
      }
    }

  }
}