﻿using System.Collections;
using System.Collections.Generic;
using DataService.Objects;

namespace DataService.Services
{
    public interface IUserDataService
    {
        User GetUser(int id);
        User CreateUser(string surname, string lastname, int age, string email);
        bool UpdateUser(int id, string surname, string lastname, int age, string email);
        bool DeleteUser(int id);
        Person_Bookmark_list NewPersonBookmarkList(int userid, string listName);
        Title_Bookmark_List NewTitleBookmarkList(int userid, string listName);
        Person_Bookmark NewPersonBookmark(int listid, string personid);
        Title_Bookmark NewTitleBookmark(int listid, string titleid);
        IList<Rating> GetRatingFromUsers(int userid);
        Title_Bookmark GetTitleBookmark(int id);
        List<Title_Bookmark> GetTitleBookmarks(int id);
        IList<Search_History> GetSearchHistories(int userid);
        List<Person_Bookmark_list> GetUsersPersonBookmarkLists(int userid);
        List<Person_Bookmark_list> GetPersonBookmarkList(int id);
        List<Title_Bookmark_List> GetTitleBookmarkLists(int id);
        //Person_Bookmark GetPersonBookmark(int id);
        IList<Person_Bookmark> GetPersonBookmarks(int listid);
        bool deletePersonBookmarkList(int listid);
        bool deleteTitleBookmarkList(int listid);
        bool deletePersonBookmarks(int id);
        bool deletePersonBookmark(int id);
        bool deleteTitleBookmark(int id);
        bool deleteTitleBookmarks(int id);
    }
}