using System;
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

      var Membership1 = new Membership { MembershipNo = 10001 };
      var Membership2 = new Membership { MembershipNo = 10002 };

      Context.Memberships.Add(Membership1);
      Context.Memberships.Add(Membership2);

      Context.SaveChanges();


      var Person1 = new Person { Firstname = "Hannes", Surname = "Wohlram", MembershipID = 1 };
      var Person2 = new Person { Firstname = "Annabel", Surname = "Stogel", MembershipID = 2 };

      Context.Persons.Add(Person1);
      Context.Persons.Add(Person2);

      Context.SaveChanges();

      var MembershipType1 = new MembershipType() { Name = "Solo Mitgliedschaft", Price = 55.0, PaymentInterval = 12 };
      var MembershipType2 = new MembershipType() { Name = "Familien Mitgliedschaft", Price = 95.0, PaymentInterval = 12 };

      Context.MembershipTypes.Add(MembershipType1);
      Context.MembershipTypes.Add(MembershipType2);
      Context.SaveChanges();
    }
  }
}
