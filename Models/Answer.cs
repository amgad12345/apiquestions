using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace apiquestions.Models
{

  public class Answer
  {
    public int Id { get; set; }


    public string AnswerString { get; set; }

    public decimal VoteAnswer { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; }


  }


}