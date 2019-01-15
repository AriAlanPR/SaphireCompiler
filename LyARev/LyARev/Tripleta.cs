using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyARev
{
    class Tripleta
    {
        List<string> DatoObjeto = new List<string>();
        List<string> DatoFuente = new List<string>();
        List<string> Operador = new List<string>();

        public List<string> datoobjeto
        {
            get 
            {
                return DatoObjeto;
            }           
        }
        public List<string> datofuente
        {
            get 
            {
                return DatoFuente;
            }
            
        }
        public List<string> operador
        {
            get
            {
                return Operador;
            }            
        }

        public void AgregarDO(string dato)
        {
            DatoObjeto.Add(dato);
        }
        public void AgregarDF(string dato)
        {
            DatoFuente.Add(dato);
        }
        public void AgregarOp(string ope)
        {
            Operador.Add(ope);
        }
    }
}
