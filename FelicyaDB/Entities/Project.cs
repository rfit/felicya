using FelicyaDB.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FelicyaDB.Entities
{
  public class Project : ICreatedOn, IUpdatedOn
  {
    public Guid ProjectId { get; set; }

    public DateTime CreatedOn { get; set; }

    public DateTime UpdatedOn { get; set; }

    [Required]
    [MaxLength(128)]
    public string ProjectName { get; set; }

    [Required]
    [MaxLength(128)]
    public string ProjectLeader { get; set; }

    [Required]
    [MaxLength(128)]
    public string ProjectOwner { get; set; }

    [Required]
    [MaxLength(128)]
    public string ProjectDescription { get; set; }

    [Required]
    public int ProjectNumber { get; set; } 

    [Required]
    public int BudgetNumber { get; set; }

    [Required]
    [MaxLength(128)]
    public string ConstructionLeader { get; set; }

    [Required]
    public int YearOfConstruction { get; set; }

    [Required]
    [MaxLength(128)]
    public string FestivalDivision { get; set; }

    [Required]
    [MaxLength(128)]
    public string Location { get; set; }

    [Required]
    [MaxLength(128)]
    public string ConstructionPurpose { get; set; }

    [Required]
    public int PhysicalSize { get; set; }

    [Required]
    public int PhysicalCapacity { get; set; }

    public ICollection<Material> Materials { get; set; }

    public Project()
    {
      ProjectId = Guid.NewGuid();
      Materials = new List<Material>();
    }
  }
}

