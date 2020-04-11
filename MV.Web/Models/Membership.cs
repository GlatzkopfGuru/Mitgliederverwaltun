

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using MV.Web.ModelBinder;
using MV.Web.Validation;

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

    [DataType(DataType.Date, ErrorMessage = "This is wrong"), DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true, NullDisplayText = "dd/MM/yyyy"), Required, DisplayName("Eintrittsdatum")]
    [ModelBinder(typeof(DateTimeModelBinder))]
    public DateTime CreationDate { get; set; }

    [DisplayName("Status")]
    public MembershipState State { get; set; }

    [DisplayName("Mitglieds Nr"), Required]
    public int MembershipNo { get; set; }

    [DisplayName("Mitglieder"), PersonRestriction]
    public ICollection<Person> Members { get; set; }

    public int MembershipTypeID { get; set; }
    public MembershipType MembershipType { get; set; }
  }
}
