using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DALLocal
{
    public class DalLocalItem
    {
        public static DalLocalItem Instance { get; }=new DalLocalItem();
        private readonly FilmBDLocalDataContext _bdLocalData;

        private DalLocalItem()
        {
            //todo change hardcoded connection string
            _bdLocalData=new FilmBDLocalDataContext("Data Source=(localdb)\\ProjectsV12;Initial Catalog=FilmDBLocal;Integrated Security=True" +
            ";Connect Timeout=30;Encrypt=False;TrustServerCertificate=True");
            if(!_bdLocalData.DatabaseExists())
                _bdLocalData.CreateDatabase();
        }

        public List<FilmDTO> SelectAllFilms()
        {
            return (from f in _bdLocalData.Films
                select
                new FilmDTO()
                {
                    Id = f.id,
                    Title = f.title,
                    OriginalTitle = f.original_title,
                    PosterPath = f.posterpath,
                    Runtime = f.runtime??0
                }).ToList();
        }

        public void InsertFilm(FilmDTO f)
        {
            _bdLocalData.Films.InsertOnSubmit(new Film()
            {
                id = f.Id,
                original_title = f.OriginalTitle,
                posterpath = f.PosterPath,
                runtime = f.Runtime,
                title = f.Title
            });
        }

        public List<FilmGenreDTO> SelectAllFilmGenres()
        {
            return
            (from fg in _bdLocalData.FilmGenres
                select new FilmGenreDTO() {Id = fg.id, IdFilm = fg.id_film, IdGenre = fg.id_genre}).ToList();
        }

        public void InsertFilmGenre(FilmGenreDTO fg)
        {
            _bdLocalData.FilmGenres.InsertOnSubmit(new FilmGenre()
            {
                id = fg.Id,
                id_film = fg.IdFilm,
                id_genre = fg.IdGenre
            });
        }

        public void InsertListFilmGenres(List<FilmGenreDTO> lfg)
        {
            _bdLocalData.FilmGenres.InsertAllOnSubmit(from fg in lfg select new FilmGenre() {id_film = fg.IdFilm,id_genre = fg.IdGenre});
        }

        public List<GenreDTO> SelectAlGenres()
        {
            return (from g in _bdLocalData.Genres select new GenreDTO() {Id = g.id, Name = g.name}).ToList();
        }

        public void InsertGenre(GenreDTO g)
        {
            _bdLocalData.Genres.InsertOnSubmit(new Genre() {id = g.Id, name = g.Name});
        }

        public void InsertListGenre(List<GenreDTO> lg)
        {
            _bdLocalData.Genres.InsertAllOnSubmit(from g in lg select new Genre() {id = g.Id,name = g.Name});
        }
        public List<FilmActeurDTO> SelectAllFilmActeurs()
        {
            return
            (from fa in _bdLocalData.FilmActors
                select new FilmActeurDTO() {Id = fa.id, IdFilm = fa.id_film, IdActor = fa.id_actor}).ToList();
        }

        public void InsertFilmActeur(FilmActeurDTO fa)
        {
            _bdLocalData.FilmActors.InsertOnSubmit(new FilmActor()
            {
                id = fa.Id,
                id_actor = fa.IdActor,
                id_film = fa.IdFilm
            });
        }

        public void InsertListFilmActeur(List<FilmActeurDTO> lfa)
        {
            _bdLocalData.FilmActors.InsertAllOnSubmit(from fa in lfa select new FilmActor() {id_actor = fa.IdActor,id_film = fa.IdFilm});
        }

        public List<ActorDTO> SelectAllActors()
        {
            return
                (from a in _bdLocalData.Actors select new ActorDTO() {Id = a.id, Name = a.name, Character = a.character})
                    .ToList();
        }

        public void InsertActor(ActorDTO a)
        {
            _bdLocalData.Actors.InsertOnSubmit(new Actor() {id = a.Id, character = a.Character, name = a.Name});
        }

        public void InsertListActor(List<ActorDTO> la)
        {
            _bdLocalData.Actors.InsertAllOnSubmit(from a in la
                select new Actor() {id = a.Id, character = a.Character, name = a.Name});
        }
    }
}
