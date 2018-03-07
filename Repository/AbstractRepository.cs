using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Validatoare;
namespace Repository
{
    abstract class  AbstractRepository<E,ID>
    {
        protected Validator<E> validator;
         public AbstractRepository(Validator<E> validator)
        { this.validator = validator; }
        abstract public E save(E element);
        abstract public E delete(ID id);
        abstract public E findOne(ID id);
        abstract public void update(E element);
        abstract public List<E> get_all();
    }
}
