using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace apiquestions.Models
{

  public class Question
  {
    public int Id { get; set; }

    public string QuestionTitle { get; set; }

    [Required]
    public string QuestionString { get; set; }


    public decimal VoteQuestion { get; set; }

[JsonIgnore]
    public List<Answer> Answers { get; set; }
      = new List<Answer>();

  }

}