using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPcm.Cadstro.Peças
{
    public partial class frmPeças : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;

        public frmPeças()
        {
            InitializeComponent();
        }
        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "id";
            grid.Columns[1].HeaderText = "Nome da Peça";
            grid.Columns[2].HeaderText = "Estoque";
            grid.Columns[3].HeaderText = "Valor";
            grid.Columns[4].HeaderText = "Fornecedor";
            grid.Columns[5].HeaderText = "Descricao";
            grid.Columns[6].HeaderText = "Local";
            grid.Columns[7].HeaderText = "COD_PEÇAS";
            grid.Columns[8].HeaderText = "Foto";
            grid.Columns[9].HeaderText = "Data";

            grid.Columns[0].Visible = false;
            grid.Columns[8].Visible = false;
            grid.Columns[5].Width = 200;
            grid.Columns[1].Width = 200;
            grid.Columns[6].Width = 200;
            grid.Columns[3].DefaultCellStyle.Format = "C2";

        }
        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  pecas order by nome asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            grid.DataSource = dt;
            con.Fecharcon();
            FormatarDG();


        }


        private void Buscarnome()
        {
            con.AbrirCon();
            sql = "SELECT * FROM  pecas where nome LIKE @nome order by nome asc  ";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtBuscar.Text);
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            grid.DataSource = dt;
            con.Fecharcon();
            FormatarDG();
        }

        private void HabilitarCampos()
        {


            txtNome.Enabled = true;
            //txtEstoque.Enabled = true;
            txtDescricao.Enabled = true;
            txtLocal.Enabled = true;
            txtValor.Enabled = true;
            btnImg.Enabled = true;

            txtNome.Focus();

        }
        private void DesahabilitarCampos()
        {


            txtNome.Enabled = false;
            txtEstoque.Enabled = false;
            txtDescricao.Enabled = false;
            txtValor.Enabled = false;
            txtLocal.Enabled = false;
            btnImg.Enabled = false;




        }

        private void LimparCampos()
        {


            txtNome.Text = "";
            txtEstoque.Text = "";
            txtValor.Text = "";
            txtValor.Text = "";
            txtLocal.Text = "";
            LimparFoto();
        }





        private void LimparFoto()
        {
            img.Image = Properties.Resources.sem_foto;
        }

        private void frmPeças_Load(object sender, EventArgs e)
        {
            Listar();
            LimparFoto();
            DesahabilitarCampos();

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            LimparCampos();
            Listar();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            con.AbrirCon();
            sql = "INSERT INTO pecas(nome, estoque, valor, fornecedor, descricao, local, pecacodigo, data ) VALUES (@nome, @estoque, @valor,@fornecedor, @descricao, @local,@pecacodigo, curDATE())";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@estoque", txtEstoque.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",",".") );
            cmd.Parameters.AddWithValue("@fornecedor", cmbFornecedor.Text);



            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@local", txtLocal.Text);
            cmd.Parameters.AddWithValue("@pecacodigo", txtLocal.Text);





            cmd.ExecuteNonQuery();

            con.Fecharcon();

            MessageBox.Show("Registro Salvo com Sucesso!");
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;


            LimparCampos();
            DesahabilitarCampos();
            Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            con.AbrirCon();
            sql = "UPDATE pecas SET  nome = @nome,  estoque =@estoque, valor = @valor, fornecedor=@fornecedor, descricao=@descricao, local=@local,pecacodigo=@pecacodigo where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@estoque", txtEstoque.Text);
            cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
            cmd.Parameters.AddWithValue("@fornecedor", cmbFornecedor.Text);
            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);
            cmd.Parameters.AddWithValue("@local", txtLocal.Text);
            cmd.Parameters.AddWithValue("@pecacodigo", txtLocal.Text);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
            con.Fecharcon();






            MessageBox.Show("Registro Editado com Sucesso!");
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            LimparCampos();
            DesahabilitarCampos();
            Listar();


        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //codigo para o botão excluir
                con.AbrirCon();
                sql = "DELETE FROM pecas where id = @id";
                cmd = new MySqlCommand(sql, con.con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Fecharcon();
                MessageBox.Show("Registro Excluido com Sucesso!");
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;

                LimparCampos();
                DesahabilitarCampos();
                Listar();
            }
        }



        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            txtNome.Enabled = true;
            //btnRel.Enabled = true;
            HabilitarCampos();
            id = grid.CurrentRow.Cells[0].Value.ToString();
            Program.idcontrole = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtEstoque.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtValor.Text = grid.CurrentRow.Cells[3].Value.ToString();
            cmbFornecedor.Text = grid.CurrentRow.Cells[4].Value.ToString();
            txtDescricao.Text = grid.CurrentRow.Cells[5].Value.ToString();
            txtLocal.Text = grid.CurrentRow.Cells[6].Value.ToString();
            txtCodigo.Text = grid.CurrentRow.Cells[7].Value.ToString();

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscarnome();
        }

        private void btnImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = " Imagens  (*.jpg,*.png)|*.jpg;*.png|Todos os Arquivos(*.*)|*.*";
           if ( dialog.ShowDialog() == DialogResult.OK)
            {
                string foto = dialog.FileName.ToString();
                img.ImageLocation = foto;
            }

        }

        private void grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Program.chamadaPeca == "estoque")
            {
                Program.nomePeca = grid.CurrentRow.Cells[1].Value.ToString();
                Program.estoquePeca = grid.CurrentRow.Cells[2].Value.ToString();
                Program.idPeca = grid.CurrentRow.Cells[0].Value.ToString();
                MessageBox.Show(Program.nomePeca);
                Program.valorPeca = grid.CurrentRow.Cells[3].Value.ToString();
                Close();
            }
        }
    }
}