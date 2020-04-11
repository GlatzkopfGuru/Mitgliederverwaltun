using System;
using System.Collections.Generic;
using System.Linq;
using MV.Web.Models;

namespace MV.Web.Data
{
  public static class DBInitializer
  {
    public static void InitializeDatabaseTest(MembershipsContext Context)
    {
      Context.Database.EnsureCreated();

      if (Context.Memberships.Any())
        return;

      var MembershipType1 = new MembershipType() { Name = "Solo Mitgliedschaft", Price = 55.0, PaymentInterval = 12, PersonRestrictions = new List<MembershipTypePersonRestriction> { new MembershipTypePersonRestriction { MinAge = 18, MinCount = 1, MaxCount = 1, PersonGroupName = "Erwachsener" } } };
      var MembershipType2 = new MembershipType() {
        Name = "Familien Mitgliedschaft",
        Price = 95.0,
        PaymentInterval = 12,
        PersonRestrictions = new List<MembershipTypePersonRestriction>
        {
          new MembershipTypePersonRestriction{PersonGroupName = "Erwachsener", MaxCount = 2, MinCount = 1, MinAge = 18},
          new MembershipTypePersonRestriction{PersonGroupName = "Kind", MaxCount = 2, MaxAge = 18}
        }
      };

      Context.MembershipTypes.Add(MembershipType1);
      Context.MembershipTypes.Add(MembershipType2);
      Context.SaveChanges();

      var Membership1 = new Membership { MembershipNo = 10001, MembershipType = MembershipType1 };
      var Membership2 = new Membership { MembershipNo = 10002, MembershipType = MembershipType1 };

      Context.Memberships.Add(Membership1);
      Context.Memberships.Add(Membership2);

      Context.SaveChanges();


      var Person1 = new Person { Firstname = "Hannes", Surname = "Wohlram", MembershipID = 1, DateOfBirth = new DateTime(1980,5,2) };
      var Person2 = new Person { Firstname = "Annabel", Surname = "Stogel", MembershipID = 2, DateOfBirth = new DateTime(1992, 1, 17) };

      Context.Persons.Add(Person1);
      Context.Persons.Add(Person2);

      Context.SaveChanges();

      
    }
  }
}
