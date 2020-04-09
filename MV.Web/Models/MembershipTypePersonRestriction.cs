using System;
using System.ComponentModel.DataAnnotations;

namespace MV.Web.Models
{
  public class MembershipTypePersonRestriction
  {
    public MembershipTypePersonRestriction()
    {
    }

    public int ID { get; set; }
    public string PersonGroupName { get; set; }

    public int? MinCount { get; set; }
    public int? MaxCount { get; set; }

    public double? MinAge { get; set; }
    public double? MaxAge { get; set; }

    public int MembershipTypeID { get; set; }
  }
}
