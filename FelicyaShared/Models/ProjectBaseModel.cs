using System.ComponentModel.DataAnnotations;

namespace FelicyaShared.Models
{
  public class ProjectBaseModel
  {
    [Required(ErrorMessage = "Indtast et projektnavn")]
    [Display(Name = "Projektnavn")]
    public string ProjectName { get; set; }

    [Required(ErrorMessage = "Indtast en projektleder")]
    [Display(Name = "Projektleder")]
    public string ProjectLeader { get; set; }

    [Required(ErrorMessage = "Indtast en projektejer")]
    [Display(Name = "Projektejer")]
    public string ProjectOwner { get; set; }

    [Required(ErrorMessage = "Indtast projektbeskrivelse")]
    [Display(Name = "Projektbeskrivelse")]
    public string ProjectDescription { get; set; }

    [Required(ErrorMessage = "Indtast projektnummer")]
    [Display(Name = "Projektnummer")]
    public int ProjectNumber { get; set; }

    [Required(ErrorMessage = "Indtast budgetnummer")]
    [Display(Name = "Budgetnummer")]
    public int BudgetNumber { get; set; }

    [Required(ErrorMessage = "Indtast byggeleder")]
    [Display(Name = "Byggeleder")]
    public string ConstructionLeader { get; set; }

    [Required(ErrorMessage = "Indtast opsætningsår")]
    [Display(Name = "Opsætningsår")]
    public int YearOfConstruction { get; set; }

    [Required(ErrorMessage = "Indtast festivaldivision")]
    [Display(Name = "Festivaldivision")] 
    public string FestivalDivision { get; set; }

    [Required(ErrorMessage = "Vælg festivalområde")]
    [Display(Name = "Placering")]
    public string Location { get; set; }

    [Required(ErrorMessage = "Indtast opsættelsesformål")]
    [Display(Name = "Formål")] 
    public string ConstructionPurpose { get; set; }

    [Required(ErrorMessage = "Indtast størrelse")]
    [Display(Name = "Størrelse")]
    public int PhysicalSize { get; set; }

    [Required(ErrorMessage = "Indtast kapacitet")]
    [Display(Name = "Kapacitet")]
    public int PhysicalCapacity { get; set; }
  }
}
