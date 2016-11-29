using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class DAL
    {
        public static DAL ContextDal=new DAL();
        private FilmBDDataContext dbDataContext;

        private DAL()
        {
            dbDataContext = new FilmBDDataContext();
        }

        public List<Film> SelectAllFilmObject()
        {
            return dbDataContext.Films.ToList();
        }
    }
}
