using MediaCenter.Common.Enums;

namespace MediaCenter.Common.Models
{
  public class MovieModel
  {
    public Movie? Movie { get; set; }
    public List<MovieFile> MovieFiles { get; set; } = new List<MovieFile>();
    public List<MovieCategory> MovieCategories { get; set; } = new List<MovieCategory>();
    public List<MovieCast> MovieCast { get; set; } = new List<MovieCast>();
    public List<MovieGenre> MovieGenres { get; set; } = new List<MovieGenre>();
    public List<MovieLanguage> MovieLanguages { get; set; } = new List<MovieLanguage>();
    public MovieSeries? MovieSeries { get; set; }
    public MovieSeriesPosition? MovieSeriesPosition { get; set; }

    public long Year
    {
      get { return Movie?.year ?? 0; }
    }
    public string Title
    {
      get { return Movie?.unique_movie_title ?? ""; }
    }
    public MPAARating Rating
    {
      get { return (MPAARating)(Movie?.mpaa_rating_id ?? 0); }
    }
    public string ActorList
    {
      get { return string.Join(", ", MovieCast.Select(m => m.actor_name)); }
    }
    public string CategoryList
    {
      get { return string.Join(", ", MovieCategories.Select(m =>(Category)m.category_id)); }
    }
    public string Summary
    {
      get { return Movie?.summary ?? ""; }
    }

    public Uri? ImageUri { get; set; }
    public Uri? MediaUri { get; set; }
    public float Position { get; set; }
  }
}