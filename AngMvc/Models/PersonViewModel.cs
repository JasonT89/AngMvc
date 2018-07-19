using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngMvc.Models
{
    public class PersonViewModel
    {
        public int PersonId { get; set; }

        public int ProfilePictureId { get; set; }
        public string ProfilePicture { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public PersonViewModel()
        {

        }
        public PersonViewModel(Person person)
        {
           
            PersonId = person.PersonId;
            ProfilePictureId = person.ProfilePictureId;
            ProfilePicture = Convert.ToBase64String(person.ProfilePicture.Image);
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            CountryId = person.CountryId;
            Country = person.Country;
        }
    }
}