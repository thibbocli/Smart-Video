using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ComparatorActorDto:IEqualityComparer<ActorDTO>
    {
        public bool Equals(ActorDTO x, ActorDTO y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(ActorDTO obj)
        {
            return obj.Id;
        }
    }
}
