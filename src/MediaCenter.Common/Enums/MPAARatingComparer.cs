using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum MPAARatingComparer
  {
    [Description("All")]
    All = 0,
    [Description("MPAA Rating >")]
    MPAARatingGreaterThan = 1,
    [Description("MPAA Rating <")]
    MPAARatingLessThan = 2,
    [Description("MPAA Rating =")]
    MPAARatingEqual = 3
  }
}
