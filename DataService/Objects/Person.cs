using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person
    {
        
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string BirthYear { get; set; }
        public string DeathYear { get; set; }
        
        public IList<Person_Bookmark> PersonBookmark { get; set; }
        public IList<Person_Bookmark_list> PersonBookmarkLists { get; set; }

        public IList<Person_Person_Known_Title> PersonPersonKnownTitles { get; set; }

        public IList<Title_Person> TitlePersons { get; set; }

        public IList<Person_Profession> PersonProfessions {get; set;}

        public Person_Rating PersonRating;

    }
}