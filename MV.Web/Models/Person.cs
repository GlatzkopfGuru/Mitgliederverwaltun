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
    [DisplayName("Nachname")]
    public string Surname { get; set; }

    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd.MM.yy}")]
    [DisplayName("Geburtsdatum")]
    public DateTime DateOfBirth { get; set; }

    // ---- contact ------
    [EmailAddress]
    [DisplayName("E-Mail")]
    public string Email { get; set; }

    [Phone]
    [DisplayName("Mobiltelefon")]
    public string Mobilephone { get; set; }

    [Phone(ErrorMessage = "The fixed line phone number is not well formatted")]
    [DisplayName("Telefon")]
    public string Hometelephone { get; set; }

    // ---- address ------
    [DisplayName("Straße")]
    public string Street { get; set; }

    [StringLength(5)]
    [DisplayName("Hausnummer")]
    public string Housenumber { get; set; }

    [StringLength(3)]
    [DisplayName("Land")]
    public string IsoCountryCode { get; set; }

    [StringLength(10)]
    [DisplayName("PLZ")]
    public string Zipcode { get; set; }

    [StringLength(35)]
    [DisplayName("Stadt")]
    public string City { get; set; }

    public int MembershipID { get; set; }
    public Membership Membership { get; set; }
  }
}
