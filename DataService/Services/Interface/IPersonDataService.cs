﻿using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface IPersonDataService
    {
        List<Person> GetPerson(string id);
        List<Person> GetPersons();
        Person_known_title GetPersonKnownTitle(string person_id, string title_id);
        Person GetProfessionByPersonId(string id);
        List<Person_Profession> GetProfessionByPersonId2(string id);
        List<Person_known_title> GetPersonKnownTitles(string id);
        List<Person_Profession> GetPersonsByProfession (string profession);
        Person_Profession GetPersonProfession(int id);
        Profession GetProfession(int id);
    }
}