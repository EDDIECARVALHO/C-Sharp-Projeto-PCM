using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPcm.Cadstro
{
    public partial class frmEquipamento : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;
        public frmEquipamento()
        {
            InitializeComponent();
        }

        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "id";
            grid.Columns[1].HeaderText = "Equipamento";
            grid.Columns[0].Visible = false;
            grid.Columns[1].Width = 200;




        }

        private void Listar() 
        {
           
            con.AbrirCon();
            sql = "SELECT * FROM  maquinas order by Equipamento asc ";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            grid.DataSource = dt;
            con.Fecharcon();
            FormatarDG();
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            txtNumero.Enabled = true;
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNumero.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.ToString().Trim() == "")
            {
                txtNumero.Text = "";
                MessageBox.Show("Preencha o Campo Serviço Solicitado");
                txtNumero.Focus();
                return;
            }
            //PROGRAMANDO O BOTÃO SALVAR
            con.AbrirCon();
             sql = "INSERT INTO maquinas(Equipamento ) VALUES (@Equipamento)";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@Equipamento", txtNumero.Text);
            cmd.ExecuteNonQuery();
            con.Fecharcon();
           
            MessageBox.Show("Registro Salvo Com Sucesso!");
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            txtNumero.Text = "";
            Listar();
        }

      

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtNumero.Text.ToString().Trim() == "")
            {
                txtNumero.Text = "";
                MessageBox.Show("Preencha o Campo Editar");
                txtNumero.Focus();
                return;
            }
            //codigo para o botão editar
            con.AbrirCon();
            sql = "UPDATE maquinas SET Equipamento = @Equipamento where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@Equipamento", txtNumero.Text);
            cmd.Parameters.AddWithValue("@id", id);
           

            cmd.ExecuteNonQuery();
            con.Fecharcon();
            MessageBox.Show("Registro Editado com Sucesso!");
            btnNovo.Enabled = true;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNumero.Text = "";
            txtNumero.Enabled = false;
            Listar();



        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //codigo para o botão excluir
                con.AbrirCon();
                sql = "DELETE FROM maquinas where id = @id";
                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Equipamento", txtNumero.Text);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Fecharcon();

                MessageBox.Show("Registro Excluido com Sucesso!");
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                txtNumero.Text = "";
                txtNumero.Enabled = false;
                Listar();

            }

            }

        private void frmEquipamento_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnSalvar.Enabled = false;
            txtNumero.Enabled = true;
            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtNumero.Text = grid.CurrentRow.Cells[1].Value.ToString();
       
        }
    }
    }
