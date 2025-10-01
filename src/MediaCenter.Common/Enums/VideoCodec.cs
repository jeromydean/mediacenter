using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum VideoCodec
  {
    [Description("DivX")]
    DivX = 1,
    [Description("x264")]
    X264 = 2,
    [Description("XviD")]
    XviD = 3,
    [Description("MPEG")]
    MPEG = 4,
    [Description("x265")]
    X265 = 5
  }
}
