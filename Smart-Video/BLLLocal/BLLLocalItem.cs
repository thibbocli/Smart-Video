using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALLocal;
using DTO;

namespace BLLLocal
{
    public class BllLocalItem
    {
        private readonly DalLocalItem Instance=DalLocalItem.Instance;
        public int Pagination { get; set; } = 0;

        public List<FilmCompletDTO> SelectAllFilm()
        {
            return (from p in Instance.SelectAllFilms()
                    select new FilmCompletDTO()
                    {
                        Id = p.Id,
                        Title = p.Title,
                        OriginalTitle = p.OriginalTitle,
                        PosterPath = p.PosterPath,
                        Runtime = p.Runtime,
                        GenreList = (from g in Instance.SelectAlGenres()
                                     join fg in Instance.SelectAllFilmGenres() on g.Id equals fg.IdGenre
                                     where fg.IdFilm == p.Id
                                     select new GenreDTO() { Id = g.Id, Name = g.Name }).ToList(),
                        ActorList = (from a in Instance.SelectAllActors()
                                     join fa in Instance.SelectAllFilmActeurs() on a.Id equals fa.IdActor
                                     where fa.IdFilm == p.Id
                                     select new ActorDTO() { Id = a.Id, Name = a.Name, Character = a.Character }).ToList(),
                        RealisateurList = new List<RealisateurDTO>()
                    }).ToList();
        }
        public List<FilmDTO> SelectPaginatesFilm(int page = 0)
        {
            return Instance.SelectAllFilms().Skip(page * 20).Take(20).ToList();
        }
        public FilmCompletDTO SelectFilmComplet(int id)
        {
            return SelectAllFilm().Find(dto => dto.Id == id);
        }

        public void insertFilm(FilmCompletDTO fc)
        {
            Instance.InsertFilm(new FilmDTO()
            {
                Id = fc.Id,
                Title = fc.Title,
                PosterPath = fc.PosterPath,
                Runtime = fc.Runtime,
                OriginalTitle = fc.OriginalTitle
            });
            Instance.InsertListActor(fc.ActorList);
            Instance.InsertListFilmActeur((from a in fc.ActorList select new FilmActeurDTO() {IdFilm = fc.Id,IdActor = a.Id}).ToList());
            Instance.InsertListGenre(fc.GenreList);
            Instance.InsertListFilmGenres((from g in fc.GenreList select new FilmGenreDTO() {IdFilm = fc.Id,IdGenre = g.Id}).ToList());
            Instance.Submit();
        }
    }
}
