using FelicyaDB.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FelicyaClient.Helpers
{
  public class Co2Measure
  {
    #region Constantmeasure co2kg/m3

    public const double Oak = 275.1;
    public const double Ash = 275.1;
    public const double Beech = 287.8;
    public const double Elm = 270.87;
    public const double Larch = 279.34;
    public const double Pine = 288.954291;
    public const double Chips = 40.3671455;
    public const double Fiber = 3.14476;

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="woodName"></param>
    /// <returns></returns>
    public static double GetCo2Measure(WoodTypeEnum woodName)
    {
      switch (woodName)
      {
        case WoodTypeEnum.Oak:
          return Oak;
        case WoodTypeEnum.Ash:
          return Ash;
        case WoodTypeEnum.Beech:
          return Beech;
        case WoodTypeEnum.Elm:
          return Elm;
        case WoodTypeEnum.Larch:
          return Larch;
        case WoodTypeEnum.Pine:
          return Pine;
        case WoodTypeEnum.Chips:
          return Chips;
        case WoodTypeEnum.Fiber:
          return Fiber;
        default:
          throw new Exception($"Name not defined: {woodName}");
      }
    }
  }
}
