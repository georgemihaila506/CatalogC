using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface Repository<E,ID>
    {
        E save(E element);
        E delete(ID id);
        E findOne(ID id);
        void update(E element);
        List<E> get_all();
    }
}
