using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL ;
using DTO;

namespace BLL
{
    public class BllItem
    {
        private readonly DalItem _dalInstance = DalItem.Instance;

        public int Pagination { get; set; } = 0;

        public List<FilmCompletDTO> SelectAllFilm()
        {
            return (from p in _dalInstance.SelectAllFilmObject()
                select new FilmCompletDTO()
                {
                    Id = p.Id,
                    Title = p.Title,
                    OriginalTitle = p.OriginalTitle,
                    PosterPath = p.PosterPath,
                    Runtime = p.Runtime,
                    GenreList = (from g in _dalInstance.SelectAllGenres()
                        join fg in _dalInstance.SelectAllFilmGenres() on g.Id equals fg.IdGenre
                        where fg.IdFilm == p.Id
                        select new GenreDTO() {Id = g.Id, Name = g.Name}).ToList(),
                    ActorList = (from a in _dalInstance.SelectAllActors()
                        join fa in _dalInstance.SelectAllFilmActors() on a.Id equals fa.IdActor
                        where fa.IdFilm == p.Id
                        select new ActorDTO() {Id = a.Id, Name = a.Name, Character = a.Character}).ToList(),
                    RealisateurList = (from r in _dalInstance.SelectAllRealisateurs()
                        join fr in _dalInstance.SelectAllFilmRealisateurs() on r.Id equals fr.IdRealisateur
                        where fr.IdFilm == p.Id
                        select new RealisateurDTO() {Id = r.Id, Name = r.Name}).ToList()

                }).ToList();
        }

        public List<FilmCompletDTO> SelectPaginatesFilm(int page = 0)
        {
            return SelectAllFilm().Skip(page*20).Take(20).ToList();
        }

        public FilmCompletDTO SelectFilmComplet(int id)
        {
            return SelectAllFilm().Find(dto => dto.Id == id);
        }
    }
}
