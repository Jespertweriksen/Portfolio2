﻿using System.Collections.Generic;
using System.Linq;
using DataService.Objects;

namespace DataService.Services
{
    public interface ITitleDataService
    {
        Genre GetGenre(int id);
        IList<Title_Search> TitleSearches(string titleid);
        Title GetTitle(string id);
        Title getTitleEpisode(string id);
        Title getTitleGenreName(string id);
        IList<Title_Person> getTitlePersons(string id);
        Title getTitlePersonName(string id);

        List<Genre> GetGenres();

        List<Title_Genre> GetGenreTitles(int id);
        

       public IList<Title_Genre> GetTitleGenres(string id);

        public List<Akas> GetTitleAkas(string id);

        public Akas GetAkas(int id);

        public Title_Episode GetTitleEpisode(string id);

        public IList<Title_Episode> GetMoreTitleEpisode(string id);

        public string GetTitleEpisodeParentName(string id);

        public List<Person> GetTitlePersons(string id);

        public Title GetTitleType(string id);

        public List<TitleType> GetAllTypes();

        public List<Title> GetTypeTitles(int id);

        public TitleType GetType(int id);

        public IList<OmdbHolder> GetOmdbDatas();

        public OmdbData GetOmdbData(string id);

        public List<TopPoster> GetTopTenPoster();

        public List<Movies> GetAllMovies(int page, int pageSize);

        public int GetNumberOfMovies();
        IQueryable<Title> GetTitleBySubstring(string substring);

        public List<Movies> GetAllMoviesWithType(string typeName, int page, int pageSize);

        public int GetNumberOfMoviesWithType(string typeName);

        public Title_Rating GetTitleRating(string id);

        public TitleRuntime GetTitleRuntime(string id);

        List<TitlePersonsInMovie> GetPersonsInMovie(string id);
    }
}