using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FilmCompletDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string OriginalTitle { get; set; }
        public int Runtime { get; set; }
        public string PosterPath { get; set; }
        public List<ActorDTO> ActorList { get; set; }
        public List<GenreDTO> GenreList { get; set; }
        public List<RealisateurDTO> RealisateurList { get; set; }
    }
}
