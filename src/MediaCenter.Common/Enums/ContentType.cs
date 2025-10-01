using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum ContentType
  {
    [Description("Movies")]
    Movies = 0,
    [Description("TV Shows")]
    TVShows = 1,
    [Description("Both")]
    Both = 2
  }
}
