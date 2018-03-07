using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface Services<E,ID>
    {
        E add(E element);
        void update(E element);
        E delete(ID id);
        E findOne(ID id);
        List<E> get_all();
    }
}
