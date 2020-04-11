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

    public int? MinAge { get; set; }
    public int? MaxAge { get; set; }

    public int MembershipTypeID { get; set; }
  }
}
