using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AngMvc.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [ForeignKey("ProfilePicture")]
        public int ProfilePictureId { get; set; }
        public MyImage ProfilePicture { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}