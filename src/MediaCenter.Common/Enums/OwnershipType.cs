using System.ComponentModel;

namespace MediaCenter.Common.Enums
{
  public enum OwnershipType
  {
    [Description(" ")]
    None = 0,
    [Description("DVD")]
    DVD = 1,
    [Description("BluRay")]
    BluRay = 2,
    [Description("4K")]
    _4K = 3
  }
}
