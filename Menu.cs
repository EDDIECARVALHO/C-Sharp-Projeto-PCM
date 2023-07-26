using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPcm
{
    public partial class FrmMenu : Form
    {
        Conexao con = new Conexao();
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lOGOUTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            pnlTopo.BackColor = Color.FromArgb(230, 230, 230);
            pnlRight.BackColor = Color.FromArgb(170, 170, 170);

            //MessageBox.Show("Program.nomeUsuario");

            lblUsuario.Text = Program.nomeUsuario;
            lblMatricula.Text = Program.matriculaUsuario;
        
        
        }

      

        private void Cadastro_Click(object sender, EventArgs e)
        {
            Cadstro.frmRegistro form = new Cadstro.frmRegistro();
            form.Show();
        }

      

       
        private void planejarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
      
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadstro.frmUsuarios form = new Cadstro.frmUsuarios();
            form.Show();
        }

        private void mATERIAISToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void encerramentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadstro.frmEncerrar form = new Cadstro.frmEncerrar();
            form.Show();
        }

        private void relatorioDeManutençãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Relatorio.FrmRelOrdem form = new Relatorio.FrmRelOrdem();
            form.Show();
        }

        private void equipamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadstro.frmEquipamento form = new Cadstro.frmEquipamento();
            form.Show();
        }

        private void backLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadstro.frmBacklog form = new Cadstro.frmBacklog();
            form.Show();

        }

        private void kanbanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadstro.Peças.frmPeças form = new Cadstro.Peças.frmPeças();
            form.Show();
        }

        private void estoqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
          frmEstoque form = new frmEstoque();
            form.Show();
        }

        private void requisiçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Movimentacoes.frmSaida form = new Movimentacoes.frmSaida();
            form.Show();
        }
    }
}
