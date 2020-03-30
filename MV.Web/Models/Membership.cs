

using System.Collections.Generic;
using System.ComponentModel;

namespace MV.Web.Models
{
  public class Membership
  {
    public Membership()
    {
    }

    public int ID { get; set; }

    [DisplayName("Mitglieds Nr")]
    public int MembershipNo { get; set; }

    [DisplayName("Mitglieder")]
    public ICollection<Person> Members { get; set; }

  }
}
