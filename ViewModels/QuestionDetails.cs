
using System.Collections.Generic;


namespace apiquestions.ViewModels
{

  public class QuestionDetails
  {
    public int Id { get; set; }




    public string QuestionString { get; set; }


    public decimal VoteQuestion { get; set; }


    public List<CreatedAnswer> Answers { get; set; }
      = new List<CreatedAnswer>();

  }

}