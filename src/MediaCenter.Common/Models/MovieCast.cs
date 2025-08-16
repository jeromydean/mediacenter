namespace MediaCenter.Common.Models
{
  public class MovieCast
  {
    public long movie_cast_id  { get; set; }
    public long movie_id { get; set; }
    public string actor_name { get; set; }
  }
}