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
    public partial class frmBacklog : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;



        public frmBacklog()
        {
            InitializeComponent();
        }



        private void CarregarCombobox()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  controle order by om asc ";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbBacklog.DataSource = dt;

            // cmbEquipamento.ValueMember = id;

            cmbBacklog.DisplayMember = "om";


            con.Fecharcon();


        }
        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "id";
            grid.Columns[1].HeaderText = "backlog";
            grid.Columns[2].HeaderText = "status";
            grid.Columns[3].HeaderText = "comentario";
            grid.Columns[4].HeaderText = "Data";

            grid.Columns[0].Visible = false;

        }
        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  status order by backlog asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            grid.DataSource = dt;
            con.Fecharcon();
            FormatarDG();


        }


        private void Buscarom()
        {
            con.AbrirCon();
            sql = "SELECT * FROM  status where backlog LIKE @backlog order by backlog asc  ";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@backlog", txtBuscar.Text + "%");
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


            cmbBacklog.Enabled = true;
            cmbStatus.Enabled = true;
            txtComentario.Enabled = true;


            cmbBacklog.Focus();

        }
        private void DesahabilitarCampos()
        {


            cmbBacklog.Enabled = false;
            cmbStatus.Enabled = false;
            txtComentario.Enabled = false;



        }

        private void LimparCampos()
        {


            cmbBacklog.Text = "";
            cmbStatus.Text = "";
            txtComentario.Text = "";
        }


        private void frmBacklog_Load(object sender, EventArgs e)
        {

            Listar();
            CarregarCombobox();
            DesahabilitarCampos();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {

            con.AbrirCon();
            sql = "INSERT INTO status(backlog, status, comentario, data ) VALUES (@backlog, @status, @comentario,curDATE())";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@backlog", cmbBacklog.Text);
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);




            cmd.Parameters.AddWithValue("@comentario", txtComentario.Text);






            cmd.ExecuteNonQuery();

            con.Fecharcon();

            MessageBox.Show("Registro Salvo com Sucesso!");
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;


            LimparCampos();
            DesahabilitarCampos();
            Listar();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            cmbBacklog.Text = (" 0");
            LimparCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            con.AbrirCon();
            sql = "UPDATE status SET  status = @status,comentario = @comentario where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@status", cmbStatus.Text);
            cmd.Parameters.AddWithValue("@comentario", txtComentario.Text);


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
                sql = "DELETE FROM status where id = @id";
                cmd = new MySqlCommand(sql, con.con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Fecharcon();
                MessageBox.Show("Registro Excluido com Sucesso!");
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                cmbBacklog.Enabled = false;
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
            btnRel.Enabled = true;
            HabilitarCampos();
            id = grid.CurrentRow.Cells[0].Value.ToString();
            Program.idcontrole = grid.CurrentRow.Cells[0].Value.ToString();
            cmbStatus.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtComentario.Text = grid.CurrentRow.Cells[3].Value.ToString();
           
          
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscarom();
        }
    }
}