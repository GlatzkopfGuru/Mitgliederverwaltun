

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MV.Web.Models
{
  public enum MembershipState
  {
    Active,
    Closed
  }


  public class Membership
  {
    public Membership()
    {
    }

    public int ID { get; set; }

    [DisplayName("Eintritsdatum"), DataType(DataType.Date)]
    public DateTime CreationDate { get; set; }

    [DisplayName("Status")]
    public MembershipState State { get; set; }

    [DisplayName("Mitglieds Nr")]
    public int MembershipNo { get; set; }

    [DisplayName("Mitglieder")]
    public ICollection<Person> Members { get; set; }

  }
}
