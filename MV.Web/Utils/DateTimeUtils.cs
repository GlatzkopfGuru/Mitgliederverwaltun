using System;
namespace MV.Web.Utils
{
  public static class DateTimeUtils
  {
    public static double GetAge(this DateTime DateOfBirth)
    {
      int age = DateTime.Now.Year - DateOfBirth.Year;
      if (DateOfBirth > DateTime.Now.AddYears(-age))
        age--;

      return age;
    }
  }
}
