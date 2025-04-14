using MediaCenter.Common.Enums;

namespace MediaCenter.Common.Models
{
  public class MovieModel
  {
    public DateTime ReleaseDate { get; set; }
    public string Description { get; set; }
    public MPARating? Rating { get; set; }
    public Uri ImageUri { get; set; }
    public Uri MediaUri { get; set; }
    public float Position { get; set; }
  }
}