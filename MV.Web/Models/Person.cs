using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MV.Web.Models
{
  public class Person
  {
    public Person()
    {
    }
    public int ID { get; set; }

    [StringLength(25)]
    [DisplayName("Vorname")]
    public string Firstname { get; set; }

    [Required, StringLength(25)]
    public string Surname { get; set; }

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}")]
    public DateTime DateOfBirth { get; set; }

    // ---- contact ------
    [EmailAddress]
    public string Email { get; set; }
    [Phone]
    public string Mobilephone { get; set; }
    [Phone(ErrorMessage = "The fixed line phone number is not well formatted")]
    public string Hometelephone { get; set; }

    // ---- address ------
    public string Street { get; set; }

    [StringLength(5)]
    public string Housenumber { get; set; }

    [StringLength(3)]
    public string IsoCountryCode { get; set; }

    [StringLength(10)]
    public string Zipcode { get; set; }

    [StringLength(35)]
    public string City { get; set; }

    public int MembershipID { get; set; }
    public Membership Membership { get; set; }
  }
}
