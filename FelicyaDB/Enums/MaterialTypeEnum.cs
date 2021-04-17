using System.ComponentModel.DataAnnotations;

namespace FelicyaDB.Enums
{
  /// <summary>
  /// Enum for different sorts of material.
  /// </summary>
  public enum MaterialTypeEnum
  {
    Unknown = 0,

    [Display(Name = "Træ")]
    Wood = 1,

    [Display(Name = "Plastik")]
    Plastic = 2,

    [Display(Name = "Metal")]
    Metal = 3,

    [Display(Name = "Teknik")]
    Technique = 4,

    [Display(Name = "Other")]
    Other = 5,
  }
}

