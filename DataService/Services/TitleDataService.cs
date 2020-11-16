using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataService.Objects;
using Microsoft.EntityFrameworkCore;

namespace DataService.Services
{
    public class TitleDataService : ITitleDataService
    {
        public TitleDataService()
        {
            using var ctx = new ImdbContext();
        }

        public Genre GetGenre(int id)
        {
            using var ctx = new ImdbContext();
            return ctx.genre.Find(id);
        }

        public List<Genre> GetGenres()
        {
            using var ctx = new ImdbContext();
            return ctx.genre.ToList();
        }

        public IList<Title_Search> TitleSearches(string titleid)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title_search
                .Where(s => s.Id.Equals(titleid));
            return query.ToList();
        }

        public Title getTitle(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title.Find(id);
            return query;
        }

        public Title getTitleEpisode(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title.Where(x => x.Id == id)
                .Include(x => x.TitleEpisode).FirstOrDefault();
            return query;
        }


        public IList<Title> GetTitles()
        {
            using var ctx = new ImdbContext();
            var query = ctx.title.ToList();
            return query;
        }

        public IList<Title_Genre> GetTitleGenres(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title_genre
                .Include(x => x.Genre)
                .Where(x => x.TitleId == id)
                .ToList();
            return query;
        }

        public Title getTitleGenreName(string id)
        {
            using var ctx = new ImdbContext();

            // Denne title har 3 genre derfor er den udvalgt.

            var query = ctx.title
                .Include(x => x.TitleGenres)
                .ThenInclude(o => o.Genre)
                .AsSingleQuery()
                .FirstOrDefault(o => o.Id == id);

            return query;
        }


        public IList<Title_Person> getTitlePersons(string id)
        {
            using var ctx = new ImdbContext();

            var query = ctx.TitlePersons
                .Where(x => x.TitleId == id)
                .ToList();
            return query;
        }

        public Title getTitlePersonName(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title
                .Include(x => x.TitlePersons)
                .ThenInclude(x => x.Person)
                .FirstOrDefault(x => x.Id == id);
            return query;
        }

        public List<Title_Genre> getGenreTitles(int id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.title_genre
                .Include(x => x.Title)
                .Include(x => x.Genre)
                .Where(x => x.GenreId == id)
                .ToList();
                
            return query;
        }

        public List<Akas> GetTitleAkas(string id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.akas
                .Where(x => x.TitleId == id)
                .ToList();

            return query;
        }

        public Akas GetAkas(int id)
        {
            using var ctx = new ImdbContext();
            var query = ctx.akas
                .Where(x => x.Id == id)
                .Include(x => x.AkasType)
                .FirstOrDefault();

            return query;
        }

        public Title_Episode GetTitleEpisode(string id)
        {
            using var  ctx = new ImdbContext();
            var query = ctx.title_episode
                .Where(x => x.TitleId == id)
                .FirstOrDefault();
            return query;
        }

        public IList<Title_Episode> GetMoreTitleEpisode(string id)
        {
            using var ctx = new ImdbContext();
            
            var query = ctx.title_episode
                .Where(x => x.TitleId == id)
                .ToList();

            var query2 = ctx.title_episode
                .Where(x => x.ParentId == ctx.title_episode.First().ParentId)
                .Include(x => x.Title)
                .ToList();
            
            return query2;
        }
    }
}