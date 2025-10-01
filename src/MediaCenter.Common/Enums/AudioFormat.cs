using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum AudioFormat
  {
    [Description("AAC")]
    AAC = 1,
    [Description("AC3")]
    AC3 = 2,
    [Description("DTS")]
    DTS = 3,
    [Description("FLAC")]
    FLAC = 4,
    [Description("MP3")]
    MP3 = 5,
    [Description("PCM")]
    PCM = 6,
    [Description("TrueHD")]
    TrueHD = 7,
    [Description("Vorbis")]
    Vorbis = 8,
    [Description("WMA")]
    WMA = 9,
    [Description("MPEG Audio")]
    MPEG = 10
  }
}
