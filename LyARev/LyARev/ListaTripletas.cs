using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyARev
{
    class ListaTripletas
    {
        List<Tripleta> Lista = new List<Tripleta>();
        public List<Tripleta> lista
        {
            get 
            { return Lista; 
            }
        }

        public void AgregarTripleta(Tripleta tr)
        {
            Lista.Add(tr);
        }
        
    }
}
