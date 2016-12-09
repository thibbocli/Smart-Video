using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL ;
using DTO;

namespace BLL
{
    public class BLL
    {
        private DalItem DALInstance = DalItem.Instance;

        public List<FilmCompletDTO> SelectALLFilm()
        {
            return (from p in DALInstance.SelectAllFilmObject()
                select new FilmCompletDTO()
                {
                    Id = p.Id,
                    Title = p.Title,
                    OriginalTitle = p.OriginalTitle,
                    PosterPath = p.PosterPath,
                    Runtime = p.Runtime,
                    GenreList = (from g in DALInstance.SelectAllGenres()
                        join fg in DALInstance.SelectAllFilmGenres() on g.Id equals fg.IdGenre
                        where fg.IdFilm == p.Id
                        select new GenreDTO() {Id = g.Id, Name = g.Name}).ToList(),
                    ActorList = (from a in DALInstance.SelectAllActors()
                        join fa in DALInstance.SelectAllFilmActors() on a.Id equals fa.IdActor
                        where fa.IdFilm == p.Id
                        select new ActorDTO() {Id = a.Id, Name = a.Name, Character = a.Character}).ToList(),
                    RealisateurList = (from r in DALInstance.SelectAllRealisateurs()
                        join fr in DALInstance.SelectAllFilmRealisateurs() on r.Id equals fr.IdRealisateur
                        where fr.IdFilm == p.Id
                        select new RealisateurDTO() {Id = r.Id, Name = r.Name}).ToList()

                }).ToList();
        }

        public FilmCompletDTO SelectFilmComplet(int id)
        {
            return SelectALLFilm().Find(dto => dto.Id == id);
        }
    }
}
