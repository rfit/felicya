using FelicyaDB.Enums;
using FelicyaDB.Entities.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FelicyaDB.Entities 
{
  public class Material : ICreatedOn, IUpdatedOn
  {
    public int MaterialId { get; set; }

    [ForeignKey(nameof(ProjectId))]
    public Guid ProjectId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    [Required]
    public MaterialTypeEnum Type { get; set; }

    [Required]
    [MaxLength(128)]
    public string MaterialSort { get; set; }

    [Required]
    [MaxLength(128)]
    public string Name { get; set; }

    [Required]
    public double Height { get; set; }

    [Required]
    public double Length { get; set; }

    [Required]
    public double Width { get; set; }

    [Required]
    public int NumberOfUnits { get; set; }

    [Required]
    [MaxLength(64)]
    public string Purpose { get; set; }

    [Required]
    public int CO2Measure { get; set; }

    /// <summary>
    /// TODO: skal checkbokse give andledning til bools?
    /// </summary>
    [Required]
    [MaxLength(64)]
    public string Disposal { get; set; }

    public Project Project { get; set; }

   /* public Material()
    {
      MaterialId = Guid.NewGuid();
    }*/
  }
}


