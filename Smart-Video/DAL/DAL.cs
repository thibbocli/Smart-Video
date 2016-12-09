using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DAL
    {
        public static DAL ContextDal=new DAL();
        private readonly FilmBDDataContext _dbDataContext;

        private DAL()
        {
            _dbDataContext = new FilmBDDataContext();
        }

        public List<FilmDTO> SelectAllFilmObject()
        {
            return (from p in _dbDataContext.Films
                select new FilmDTO() {Id = p.id, PosterPath = p.posterpath, Runtime = p.runtime??0, Title = p.title}).ToList();
        }

        public List<FilmActeurDTO> SelectAllFilmActors()
        {
            return (from p in _dbDataContext.FilmActors
                select new FilmActeurDTO() {Id = p.id, IdActor = p.id_actor, IdFilm = p.id_film}).ToList();
        }

        public List<ActorDTO> SelectAllActors()
        {
            return (from p in _dbDataContext.Actors
                select new ActorDTO() {Id = p.id, Character = p.character, Name = p.name}).ToList();
        }

        public List<FilmGenreDTO> SelectAllFilmGenres()
        {
            return (from p in _dbDataContext.FilmGenres
                select new FilmGenreDTO() {Id = p.id, IdFilm = p.id_film, IdGenre = p.id_genre}).ToList();
        }

        public List<GenreDTO> SelectAllGenres()
        {
            return (from p in _dbDataContext.Genres select new GenreDTO() {Id = p.id, Name = p.name}).ToList();
        }

        public List<FilmRealisateurDTO> SelectAllFilmRealisateurs()
        {
            return (from p in _dbDataContext.FilmRealisateurs
                    select new FilmRealisateurDTO() {Id = p.id, IdFilm = p.id_film, IdRealisateur = p.id_realisateur})
                .ToList();
        }

        public List<RealisateurDTO> SelectAllRealisateurs()
        {
            return
                (from p in _dbDataContext.Realisateurs select new RealisateurDTO() {Id = p.id, Name = p.name}).ToList();
        }
    }
}
