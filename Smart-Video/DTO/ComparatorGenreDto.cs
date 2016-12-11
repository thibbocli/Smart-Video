using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ComparatorGenreDto:IEqualityComparer<GenreDTO>
    {
        public bool Equals(GenreDTO x, GenreDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(GenreDTO obj)
        {
            return obj.Id;
        }
    }
}
