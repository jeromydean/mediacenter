using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum Sort
  {
    [Description(" ")]
    None = 0,
    [Description("Title")]
    Title = 1,
    [Description("Rating")]
    Rating = 2,
    [Description("Votes")]
    Votes = 3,
    [Description("Year")]
    Year = 4,
    [Description("RunTime")]
    RunTime = 5
  }
}
