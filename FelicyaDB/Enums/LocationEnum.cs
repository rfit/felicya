using System.ComponentModel.DataAnnotations;

namespace FelicyaDB.Enums
{
  public enum LocationEnum
  {
    Unknown = 0,

    [Display(Name = "AV")]
    AV = 1,

    [Display(Name = "Avalon")]
    Avalon = 2,

    [Display(Name = "Arena")]
    Arena = 3,

    [Display(Name = "Stables")]
    Stables = 4,

    [Display(Name = "BV")]
    BV = 5,

    [Display(Name = "VV")]
    VV = 6,

    [Display(Name = "Orange")]
    Orange = 7,

    [Display(Name = "Central Park")]
    CentralPark = 8,

    [Display(Name = "Camping W")]
    CampingW = 9,

    [Display(Name = "Camping E")]
    CampingE = 10,

    [Display(Name = "Camping C")]
    CampingC = 11,

    [Display(Name = "Special Camping")]
    SpecialCamping = 12
  }
}

