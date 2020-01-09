using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace apiquestions.Models
{

  public class Question
  {
    public int Id { get; set; }

    [Required]
    public string QuestionString { get; set; }


    public decimal VoteQuestion { get; set; }


    public List<Answer> Answers { get; set; }
      = new List<Answer>();

  }

}