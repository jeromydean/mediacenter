using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum VideoType
  {
    [Description("480i")]
    _480i = 1,
    [Description("720p")]
    _720p = 2,
    [Description("1080p")]
    _1080p = 3,
    [Description("2160p")]
    _2160p = 4
  }
}
