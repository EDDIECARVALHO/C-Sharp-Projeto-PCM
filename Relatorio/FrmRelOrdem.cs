using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPcm.Relatorio
{
    public partial class FrmRelOrdem : Form
    {
        public FrmRelOrdem()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
           

            // TODO: esta linha de código carrega dados na tabela 'sistemapcmDataSet.controle'. Você pode movê-la ou removê-la conforme necessário.
            this.controleporidTableAdapter.Fill(this.sistemapcmDataSet.controleporid, Convert.ToInt32(Program.idcontrole));

            this.reportViewer1.RefreshReport();
        }
    }
}
