using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DTO;
using BLL;

namespace SmartWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        private BllItem BLLobj=new BllItem();
        public List<FilmDTO> GetPaginatedFilm(int page=0)
        {
            return BLLobj.SelectPaginatesFilm(page);
        }

        public FilmCompletDTO GetFilm(int id)
        {
            return BLLobj.SelectFilmComplet(id);
        }
    }
}
