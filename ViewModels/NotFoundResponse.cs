  
using System;

namespace HikingTrailApi.ViewModels
{
  public class NotFoundResponse
  {
    public string Message { get; set; }
    public int QueryId { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
  }
}