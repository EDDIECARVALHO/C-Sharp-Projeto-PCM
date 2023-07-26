using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjetoPcm.Cadstro
{
    public partial class frmUsuarios : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;
        string usuarioAntigo;

        public frmUsuarios()
        {
            InitializeComponent();
        }
       



        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "id";
            grid.Columns[1].HeaderText = "Nome";
            grid.Columns[2].HeaderText = "Usuario";
            grid.Columns[3].HeaderText = "Matricula";
            grid.Columns[4].HeaderText = "Senha";
       
            grid.Columns[5].HeaderText = "Data";
            
            grid.Columns[0].Visible = false;


        }



        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  usuarios order by nome asc  ";
            cmd = new MySqlCommand(sql, con.con);
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
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
           
            txtMatricula.Enabled = true;

            txtNome.Focus();

        }
        private void DesahabilitarCampos()
        {



            txtNome.Enabled = false;
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;

            txtMatricula.Enabled = false;


        }
        private void LimparCampos()
        {


            txtNome.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtMatricula.Text = "";




        }

        private void BuscarMatricula()
        {
            con.AbrirCon();
            sql = "SELECT * FROM  usuarios where matricula LIKE @matricula order by matricula asc  ";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@matricula", txtBuscarMatricula.Text + "%");
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            grid.DataSource = dt;
            con.Fecharcon();
            FormatarDG();
        }
        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            Listar();
            
            

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
           
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            LimparCampos();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Campo Nome");
                txtNome.Focus();
                return;
            }

            con.AbrirCon();
            sql = "INSERT INTO usuarios(nome, usuario, matricula, senha, data) VALUES (@nome, @usuario, @matricula, @senha, curDATE())";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);



            cmd.Parameters.AddWithValue("@matricula", txtMatricula.Text);

            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);
            // verificar se nome de usuario já existe no banco

            MySqlCommand cmdVerificar;
            
            cmdVerificar = new MySqlCommand("SELECT * FROM  usuarios where usuario = @usuario", con.con);
            cmdVerificar.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Usuário já Registrado!", "ERRO AO SALVAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }
            
         





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
            if (txtNome.Text.ToString().Trim() == "")
            {
                txtNome.Text = "";
                MessageBox.Show("Preencha o Campo Nome");
                txtNome.Focus();
                return;
            }
            //codigo para o botão editar
            con.AbrirCon();
            sql = "UPDATE usuarios  SET nome = @nome, usuario = @usuario, matricula = @matricula, senha = @senha  where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@nome", txtNome.Text);
            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);



            cmd.Parameters.AddWithValue("@matricula", txtMatricula.Text);

            cmd.Parameters.AddWithValue("@senha", txtSenha.Text);

            cmd.Parameters.AddWithValue("@id", id);
            //codigo para verificar  se usuario já existe no banco de dados 
            if (txtUsuario.Text != usuarioAntigo)
            {
                MySqlCommand cmdVerificar;

                cmdVerificar = new MySqlCommand("SELECT * FROM  usuarios  where usuario = @usuario", con.con);
                cmdVerificar.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                MySqlDataAdapter ta = new MySqlDataAdapter();
                ta.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                ta.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Usuario  já Registrado!", "DADOS SALVOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Text = "";
                    txtUsuario.Focus();
                    return;
                }
            }

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

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            HabilitarCampos();
            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtUsuario.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtBuscarMatricula.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtSenha.Text = grid.CurrentRow.Cells[4].Value.ToString();
            usuarioAntigo = grid.CurrentRow.Cells[2].Value.ToString();






        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //codigo para o botão excluir
                con.AbrirCon();
                sql = "DELETE FROM usuarios where id = @id";
                cmd = new MySqlCommand(sql, con.con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Fecharcon();
                MessageBox.Show("Registro Excluido com Sucesso!");
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                txtNome.Enabled = false;
                LimparCampos();
                DesahabilitarCampos();
                Listar();


            }
        }

        private void txtBuscarMatricula_TextChanged(object sender, EventArgs e)
        {
            BuscarMatricula();
        }
    }
}
