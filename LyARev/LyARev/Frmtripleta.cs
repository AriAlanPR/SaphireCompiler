using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LyARev
{
    public partial class Frmtripleta : Form
    {
        public Frmtripleta()
        {
            InitializeComponent();
        }
        //metodo para insertar datos a la tripleta
        public void AgregarFila(string datoobj, string datofuente, string operador)
        {
            dgvtripleta.Rows.Add(datoobj, datofuente, operador);
        }


        private void Frmtripleta_Load(object sender, EventArgs e)
        {

        }
    }
}
