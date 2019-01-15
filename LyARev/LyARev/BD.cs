using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyARev
{
    class BD
    {
        //constructores de la clase BDOLEDB
        public BD(string ruta)
        {//cambiado Jet por ACE, 4 por 12, 8 por 15.
            cc = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + ruta + "; Persist Security Info=False;";
            this.Con = new OleDbConnection(cc);
            con.Close();
        }

        //cadena de conexion
        private string cc;

        public string CadenaConexion
        {
            get { return cc; }
            set { cc = value; }
        }

        //consulta a realizar
        private string consulta;

        public string Consulta
        {
            get { return consulta; }
            set { consulta = value; }
        }

        //variables y propiedades para conexion a excel(en este caso) mediante OLEDB
        private OleDbConnection con = null;

        public OleDbConnection Con
        {
            get { return con; }
            set { con = value; }
        }

        private OleDbCommand com;

        public OleDbCommand Com
        {
            get { return com; }
            set { com = value; }
        }

        private OleDbDataAdapter da;

        public OleDbDataAdapter Da
        {
            get { return da; }
            set { da = value; }
        }

        private OleDbDataReader dr;

        public OleDbDataReader DataReader
        {
            get { return dr; }
            set { dr = value; }
        }

        //metodos para abrir y cerrar la conexion por el usuario
        public void Abrir()
        {
            if (con != null)
                con.Open();
        }

        public void Cerrar()
        {
            if (con != null)
                con.Close();
        }

        //metodos para hacer recorrido e identificar la palabra reservada

        //recorre e identifica el tipo de transicion de lo recibido o su estado de aceptacion/error
        public string Buscar(string query)
        {
            //variable auxiliar que contiene el resultado de la consulta
            string res;
            //se genera la consulta 
            Consulta = query;
            Con.Open(); //se abre la conexion de datos
            Com = new OleDbCommand(Consulta, con); //se prepara la cosulta
            DataReader = Com.ExecuteReader(); //se ejecuta la consulta
            if (DataReader.HasRows)
            {
                DataReader.Read(); //se leen los resultados
                res = DataReader[0].ToString(); //se guarda en la variable auxiliar el resultado de la consulta
            }
            else
                res = " ";
            Con.Close(); //se cierra la conexion
            return res;  //se envia como valor el resultado de la variable
        }
        //sin resultados
        public int QueryconResultado(string query)
        {
            con.Open();
            da = new OleDbDataAdapter(query, con);
            //constructor = new SqlCommandBuilder(adaptador);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            return ds.Rows.Count;
        }

        //metodo para eliminar los datos de la tabla de simbolos
        public void Eliminar()
        {
            Consulta = "Delete from TABLAID";
            Con.Open();
            com = new OleDbCommand(Consulta, con);
            com.ExecuteNonQuery();
            Con.Close();
        }
    }
}
