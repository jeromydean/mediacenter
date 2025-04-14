using LibVLCSharp.Shared;

namespace MediaCenter
{
  public interface IVLCProvider
  {
    LibVLC Instance { get; }
  }
  public class VLCProvider : IVLCProvider
  {
    public LibVLC Instance { get; private set; }

    public VLCProvider()
    {
      Instance = new LibVLC();
    }
  }
}
