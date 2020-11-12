﻿using System;
using System.Linq;
using DataService.Services;
using Xunit;



namespace PortFolio2.Tests
{
    public class UserDataServiceTest
    {
        [Fact]
        public void GetUser()
        {
            var service = new UserDataService();
            var users = service.GetUser(1);
            Assert.Equal(1, users.Id);
            Assert.Equal("TestSurname", users.Surname);
        }

        [Fact]
        public void GetRatingFromUser()
        {
            var service = new UserDataService();
            var rating = service.GetRatingFromUsers(1);
            Assert.Equal(2, rating.Count);
            Assert.Equal("tt0052520", rating.First().Title_Id);
            Assert.Equal(8, rating.Last().Rating_);
        }

        [Fact]
        public void GetPersonBookmarkLists()
        {
            var service = new UserDataService();
            var personBookmarkList = service.GetUsersPersonBookmarkLists(1);
            Assert.Equal(1, personBookmarkList.Count);
            Assert.Equal("My test list1", personBookmarkList.First().List_Name);
            Assert.Equal("My test list1", personBookmarkList.Last().List_Name);
        }

        
        
        [Fact]
        public void GetPersonBookmark()
        {
            var service = new UserDataService();
            var personBookmark = service.GetPersonBookmark(19);
            Assert.Equal(19,personBookmark.Id);
            Assert.Equal("nm0000001",personBookmark.Person_Id);
        }


        [Fact]
        public void GetTitleBookmarks()
        {
            var service = new UserDataService();
            var titleBookmarks = service.GetTitleBookmarks(2);
            Assert.Equal(2, titleBookmarks.First().Id);
            Assert.Equal(1, titleBookmarks.First().ListId);
            Assert.Equal("tt0734773", titleBookmarks.First().TitleId);
        }
        
    }
}