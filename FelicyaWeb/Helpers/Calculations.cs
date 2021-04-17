using FelicyaDB.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace FelicyaClient.Helpers
{
  public class Calculations
  {
    public static double GetTotalCo2Pressure(double height, double length, double width, int numberOfUnits, WoodTypeEnum woodName)
    {
      double totalCubicMeters = numberOfUnits * height * length * width / 1000000000;
      var co2Measure = Co2Measure.GetCo2Measure(woodName);

      return totalCubicMeters * co2Measure;
    }
  }
}
