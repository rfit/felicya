using System.ComponentModel.DataAnnotations;

namespace FelicyaDB.Enums
{
  /// <summary>
  /// Enum for different sorts of wood.
  /// </summary>
  public enum WoodTypeEnum
  {
    Unknown = 0,

    [Display(Name = "Eg")]
    Oak = 1,

    [Display(Name = "Ask")]
    Ash = 2,

    /* [Display(Name = "Gran")]
     Fir = 3,*/

    [Display(Name = "Bøg")]
    Beech = 3,

    [Display(Name = "Elm")]
    Elm = 4,

    [Display(Name = "Lærk")]
    Larch = 5,

    [Display(Name = "Fyr")]
    Pine = 6,

    [Display(Name = "Flis")]
    Chips = 7, //TODO: Korrekt navn?

    [Display(Name = "Fiberdug PE/PP(flis underlag)")]
    Fiber = 8,
  }
}
