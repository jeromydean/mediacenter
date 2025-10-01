using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum Viewed
  {
    [Description("All")]
    All = 0,
    [Description("Previously Viewed >")]
    PreviouslyViewedGreater = 1,
    [Description("Previously Viewed <")]
    PreviouslyViewedLess = 2,
    [Description("Previously Viewed =")]
    PreviouslyViewedEqual = 3
  }
}
