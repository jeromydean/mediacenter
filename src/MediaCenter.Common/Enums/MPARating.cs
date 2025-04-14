using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum MPARating
  {
    [Description("General Audiences")]
    G,
    [Description("Parental Guidance Suggested")]
    PG,
    [Description("Parents Strongly Cautioned")]
    PG13,
    [Description("Restricted")]
    R,
    [Description("Adults Only")]
    NC17,
    [Description("Unrated")]
    Unrated
  }
}
