using System;
using System.ComponentModel;

namespace MV.Web.Models
{
  public class Person
  {
    public Person()
    {
    }
    public int ID { get; set; }
    [DisplayName("Vorname")]
    public string Firstname { get; set; }
    public string Surname { get; set; }
    public DateTime DateOfBirth { get; set; }

    // ---- contact ------
    public string Email { get; set; }
    public string Mobilephone { get; set; }
    public string Hometelephone { get; set; }

    // ---- address ------
    public string Street { get; set; }
    public string Housenumber { get; set; }
    public int Zipcode { get; set; }
    public string City { get; set; }

    public int MembershipID { get; set; }
    public Membership Membership { get; set; }
  }
}
