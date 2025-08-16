namespace MediaCenter.Common.Models
{
  public class MovieFile
  {
    public long id { get; set; }
    public long movie_id { get; set; }
    public string folder { get; set; }
    public string filepath { get; set; }
    public long runtime { get; set; }
    public string resolution { get; set; }
    public string aspect_ratio { get; set; }
    public string filesize { get; set; }
    public string? crf { get; set; }
    public string? audio_bitrate { get; set; }
    public string? video_bitrate { get; set; }
    public long video_codec_id { get; set; }
    public long audio_format_id { get; set; }
    public long video_type_id { get; set; }
    public long audio_channel_id { get; set; }
    public long fps_id { get; set; }
  }
}
