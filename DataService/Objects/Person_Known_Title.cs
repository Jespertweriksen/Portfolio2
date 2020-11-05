using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataService.Objects
{
    public class Person_known_title
    {
        [Key]
        public int Id { get; set; }
        public string TitleName { get; set; }

        public IList<Person_Person_Known_Title> PersonPersonKnownTitles = new List<Person_Person_Known_Title>();
        
        //public Person_Person_Known_Title PersonPersonKnownTitle;
    }
}