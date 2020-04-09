using System.Collections.Generic;

namespace MV.Web.Models
{
  public class MembershipType
  {


    public int ID { get; set; }

    public string Name { get; set; }

    public ICollection<MembershipTypePersonRestriction> PersonRestrictions { get; set; }

    public double Price { get; set; }

    public double PaymentInterval { get; set; }
  }
}