using System.ComponentModel.DataAnnotations;

namespace FelicyaDB.Enums
{
  public enum FestivalDivisionEnum
  {
    Unknown = 0,

    [Display(Name = "Byplan og produktion")]
    CityPlanAndProduktion = 1,

    [Display(Name = "Handel")]
    Trading = 2,

    [Display(Name = "Partnerskab")]
    Partnership = 3,

    [Display(Name = "Organisation og kultur")]
    OrganisationAndCulture = 4,

    [Display(Name = "Deltagere")]
    Participants = 5,

    [Display(Name = "Program")]
    Program = 6,
  }
}
