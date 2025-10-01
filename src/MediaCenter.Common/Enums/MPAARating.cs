using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum MPAARating
  {
    [Description(" ")]
    None = 0,
    [Description("G")]
    G = 1,
    [Description("PG")]
    PG = 2,
    [Description("PG-13")]
    PG13 = 3,
    [Description("R")]
    R = 4,
    [Description("NC-17")]
    NC17 = 5,
    [Description("NR")]
    NR = 6
  }
}
