using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum AudioChannel
  {
    [Description("Mono")]
    Mono = 1,
    [Description("Stereo")]
    Stereo = 2,
    [Description("3 Channel (Left, Center, Right)")]
    _3CH = 3,
    [Description("4 Channel (Left, Center, Right, Back Center)")]
    _4CH = 4,
    [Description("5.1 Surround")]
    _51 = 5,
    [Description("7.1 Surround")]
    _71 = 6,
    [Description("8.1 Surround")]
    _81 = 7
  }
}
