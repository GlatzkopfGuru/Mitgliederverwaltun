using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using MV.Web.Data;
using MV.Web.Models;
using MV.Web.Utils;

namespace MV.Web.Validation
{
  public class PersonRestrictionAttribute : ValidationAttribute
  {
    public PersonRestrictionAttribute()
    {
    }


    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      var membership = validationContext.ObjectInstance as Membership;
      if (membership.MembershipTypeID == 0)
        return ValidationResult.Success;

      var databaseContext = validationContext.GetService(typeof(MembershipsContext)) as MembershipsContext;
      var membershipType = databaseContext.MembershipTypes.Include(memT => memT.PersonRestrictions).FirstOrDefault(t => t.ID == membership.MembershipTypeID);
      var Restrictions = membershipType.PersonRestrictions;
      var persons = value as ICollection<Person>;
      var errorMessages = new List<string>();

      if (persons == null)
        return new ValidationResult("The persons list is null!");

      foreach (var restriction in Restrictions)
      {
        var count = persons.Count(pers =>
        {
          var age = pers.DateOfBirth.Value.GetAge();

          return (restriction.MinAge == null || age >= restriction.MinAge) && (restriction.MaxAge == null || age < restriction.MaxAge);

        });

        if (restriction.MinCount != null && count < restriction.MinCount)
          errorMessages.Add($"The membershiptype {membershipType.Name} needs at least {restriction.MinCount} {restriction.PersonGroupName}.");
        else if (restriction.MaxCount != null && count > restriction.MaxCount)
          errorMessages.Add($"The membershiptype {membershipType.Name} allows at most {restriction.MaxCount} {restriction.PersonGroupName}");


      }

      if (errorMessages.Count == 0)
        return ValidationResult.Success;

      return new ValidationResult(string.Join("\r\n", errorMessages));
    }
  }
}
