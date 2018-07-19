using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngMvc.Models
{
    public static class Search
    {

        public static List<PersonViewModel> FindPeople(string url)
        {
            PeopleListDb _db = new PeopleListDb();

            string searchCriteria = null;
            var strings = url.Split('/');

            url = null;

            foreach (var item in strings)
            {
                if (item != "Home" && item != "SearchPeople" && item != "")
                {
                    if (item.Contains("?"))
                    {
                        var change = item.Split('?');
                        if (change[0] == "undefined")
                            change[0] = null;

                        if (change.Count() < 2)
                        {
                            searchCriteria = change[0];
                        }
                        else
                        {
                            url = change[0];
                            searchCriteria = change[1];
                        }
                    }
                    else
                    {
                        url = item;
                    }
                }
            }


            var result = new List<Person>();

            if (url == null)
            {
                if (searchCriteria == "Country")
                {
                    result = _db.People.Include("ProfilePicture")
                                           .Include("Country").OrderBy(x => x.Country.CountryName).ToList();
                }
                else if (searchCriteria == "LastName")
                {
                    result = _db.People.Include("ProfilePicture")
                                       .Include("Country").OrderBy(x => x.LastName).ToList();
                }
                else
                {
                    result = _db.People.Include("ProfilePicture")
                                       .Include("Country").OrderBy(x => x.FirstName).ToList();
                }
            }
            else
            {
                url.ToLower();

                if (searchCriteria != null)
                {
                    if (searchCriteria == "LastName")
                    {
                        result = _db.People.Include("ProfilePicture")
                                           .Include("Country")
                                           .OrderBy(x => x.LastName)
                                           .Where(x => x.FirstName.Contains(url) || x.LastName.Contains(url))
                                           .ToList();
                    }
                    else if (searchCriteria == "Country")
                    {
                        result = _db.People.Include("ProfilePicture")
                                           .Include("Country")
                                           .OrderBy(x => x.Country.CountryName).ThenBy(x => x.FirstName)
                                           .Where(x => x.Country.CountryName.Contains(url))
                                           .ToList();
                    }
                    else
                    {
                        result = _db.People.Include("ProfilePicture")
                       .Include("Country")
                       .OrderBy(x => x.FirstName)
                       .Where(x => x.FirstName.Contains(url) || x.LastName.Contains(url))
                       .ToList();
                    }
                }
            }

            var model = new List<PersonViewModel>();

            foreach (var item in result)
            {
                model.Add(new PersonViewModel(item));
            }

            return model;
        }

        public static void IfEmptyPeopleDatabase()
        {
            PeopleListDb _db = new PeopleListDb();
            var countries = _db.Countries.ToList();
            var images = _db.Images.ToList();

            List<Person> people = new List<Person>
            {
                new Person
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "John@Smith.com"
                }
            };
            people[0].Country = countries.First(x => x.CountryName == "Denmark");
            people[0].CountryId = countries.First(x => x.CountryName == "Denmark").CountryId;
            people[0].ProfilePicture = images.First(x => x.ImageName == "Img3");
            people[0].ProfilePictureId = images.First(x => x.ImageName == "Img3").ImageId;

            people.Add(new Person
            {
                FirstName = "Jane",
                LastName = "Smith",
                Email = "Jane@Smith.com"
            });
            people[1].Country = countries.First(x => x.CountryName == "Denmark");
            people[1].CountryId = countries.First(x => x.CountryName == "Denmark").CountryId;
            people[1].ProfilePicture = images.First(x => x.ImageName == "Img5");
            people[1].ProfilePictureId = images.First(x => x.ImageName == "Img5").ImageId;

            people.Add(new Person
            {
                FirstName = "Happy",
                LastName = "Hogan",
                Email = "Hogan@Hogan.com"
            });
            people[2].Country = countries.First(x => x.CountryName == "Denmark");
            people[2].CountryId = countries.First(x => x.CountryName == "Denmark").CountryId;
            people[2].ProfilePicture = images.First(x => x.ImageName == "Img6");
            people[2].ProfilePictureId = images.First(x => x.ImageName == "Img6").ImageId;

            people.Add(new Person
            {
                FirstName = "Olaf",
                LastName = "Snowman",
                Email = "KillMe@Faster.com"
            });
            people[3].Country = countries.First(x => x.CountryName == "Norway");
            people[3].CountryId = countries.First(x => x.CountryName == "Norway").CountryId;
            people[3].ProfilePicture = images.First(x => x.ImageName == "Img4");
            people[3].ProfilePictureId = images.First(x => x.ImageName == "Img4").ImageId;


            foreach (var item in people)
            {
                _db.People.Add(item);
            };

            _db.SaveChanges();
        }
    }
}