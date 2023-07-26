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
    public partial class frmEncerrar : Form
    {
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string id;

        string omAntiga;

        public frmEncerrar()
        {
            InitializeComponent();
        }
        private void CarregarCombobox()

        {

           // con.AbrirCon();
           // sql = "SELECT * FROM  encerrar order by Ordem asc ";
           // cmd = new MySqlCommand(sql, con.con);
           // MySqlDataAdapter da = new MySqlDataAdapter();
           // da.SelectCommand = cmd;
           // DataTable dt = new DataTable();
           // da.Fill(dt);
           // cmbConcluido.DataSource = dt;

            // cmbEquipamento.ValueMember = id;

           // cmbConcluido.DisplayMember = "Ordem De Serviço";


            con.Fecharcon();




        }
        private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "id";
            grid.Columns[1].HeaderText = "Ordem";
            grid.Columns[2].HeaderText = "Serv/Concluido";
            grid.Columns[3].HeaderText = "Tempo";
            grid.Columns[4].HeaderText = "Executante";
            grid.Columns[5].HeaderText = "Comentarios";
       
            grid.Columns[6].HeaderText = "Data";
            grid.Columns[2].Width = 150;
            grid.Columns[3].Width = 80;

            grid.Columns[0].Visible = false;


        }
        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  encerrar order by Ordem asc  ";
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
            sql = "SELECT * FROM  encerrar where Ordem LIKE @ordem order by Ordem asc  ";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@ordem", txtBuscarOm.Text + "%");
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


            cmbConcluido.Enabled = true;
            txtExecutante.Enabled = true;
            cmbConcluido.Enabled = true;
            txtTempo.Enabled = true;
            txtComentarios.Enabled = true;
            txtOm.Enabled = true;


            txtOm.Focus();

        }
        private void DesahabilitarCampos()
        {


            cmbConcluido.Enabled = false;
            txtExecutante.Enabled = false;
            cmbConcluido.Enabled = false;
            txtTempo.Enabled = false;
            txtComentarios.Enabled = false;
            txtOm.Enabled = false;

        }
        private void LimparCampos()
        {

            cmbConcluido.Text= "";
            txtExecutante.Text = "";
            cmbConcluido.Text = "";
            txtTempo.Text = "";
            txtComentarios.Text = "";
            txtOm.Text = "";
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (txtOm.Text == "")
            {
               // MessageBox.Show("Insira Antes uma Om");
               // Close();

            }
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
           
            LimparCampos();

        }

      

        private void btnSalvar_Click(object sender, EventArgs e)
        {
         
            
                if (txtOm.Text.ToString().Trim() == "")
                {
                txtOm.Text = "";
                    MessageBox.Show("Preencha o Campo Om");
                txtOm.Focus();
                    return;
                }

                con.AbrirCon();
                sql = "INSERT INTO encerrar (Ordem, servico_concluido, tempo_utilizado, executante, comentarios, data ) VALUES (@ordem, @servico_concluido, @tempo_utilizado, @executante, @comentarios,  curDATE())";

                cmd = new MySqlCommand(sql, con.con);
                cmd.Parameters.AddWithValue("@Ordem", txtOm.Text);
               



                cmd.Parameters.AddWithValue("@servico_concluido", cmbConcluido.Text);

                cmd.Parameters.AddWithValue("@tempo_utilizado", txtTempo.Text);

                cmd.Parameters.AddWithValue("@executante", txtExecutante.Text);

                cmd.Parameters.AddWithValue("@comentarios", txtComentarios.Text);

              
                // verificar se a OM já existe no banco

              //  MySqlCommand cmdVerificar;

              //  cmdVerificar = new MySqlCommand("SELECT * FROM  controle where om = @Ordem", con.con);
             //   cmdVerificar.Parameters.AddWithValue("@Ordem", cmbOm.Text);
               // MySqlDataAdapter ta = new MySqlDataAdapter();
               // ta.SelectCommand = cmdVerificar;
              //  DataTable dt = new DataTable();
              //  ta.Fill(dt);
              //  if (dt.Rows.Count > 0)
               // {
               //     MessageBox.Show("Ordem de Trabalho já Registrado!", "ERRO AO SALVAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
               //     cmbOm.Text = "";
                //    cmbOm.Focus();
                //    return;
               // }







                cmd.ExecuteNonQuery();

                con.Fecharcon();

                MessageBox.Show("Registro Salvo com Sucesso!");
                btnNovo.Enabled = true;
                btnSalvar.Enabled = false;
                LimparCampos();
                DesahabilitarCampos();
                Listar();

            }

        private void frmEncerrar_Load(object sender, EventArgs e)
        {
            Listar();
           
            CarregarCombobox();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtOm.Text.ToString().Trim() == "")
            {
                txtOm.Text = "";
                MessageBox.Show("Preencha o Campo Om");
                txtOm.Focus();
                return;
            }
            //codigo para o botão editar
            con.AbrirCon();
            sql = "UPDATE encerrar SET Ordem = @Ordem, servico_concluido = @servico_concluido, tempo_utilizado = @tempo_utilizado, executante = @executante, comentarios= @comentarios  where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@Ordem", txtOm.Text);
            cmd.Parameters.AddWithValue("@servico_concluido", cmbConcluido.Text);
            cmd.Parameters.AddWithValue("@tempo_utilizado", txtTempo.Text);
            cmd.Parameters.AddWithValue("@executante", txtExecutante.Text);
            cmd.Parameters.AddWithValue("@comentarios", txtComentarios.Text);
           


            cmd.Parameters.AddWithValue("@id", id);
            //codigo para verificar  se om já existe no banco de dados 
            if (txtOm.Text != omAntiga)
            {
                MySqlCommand cmdVerificar;

                cmdVerificar = new MySqlCommand("SELECT * FROM  encerrar where Ordem = @ordem", con.con);
                cmdVerificar.Parameters.AddWithValue("@ordem", txtOm.Text);
                MySqlDataAdapter ta = new MySqlDataAdapter();
                ta.SelectCommand = cmdVerificar;
                DataTable dt = new DataTable();
                ta.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Ordem de Trabalho já Registrado!", "DADOS SALVOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOm.Text = "";
                    txtOm.Focus();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("Deseja Realmente Excluir o registro?", "Excluir Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                //codigo para o botão excluir
                con.AbrirCon();
                sql = "DELETE FROM encerrar where id = @id";
                cmd = new MySqlCommand(sql, con.con);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Fecharcon();
                MessageBox.Show("Registro Excluido com Sucesso!");
                btnNovo.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;
                txtOm.Enabled = false;
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
            HabilitarCampos();
            id = grid.CurrentRow.Cells[0].Value.ToString();
            txtOm.Text = grid.CurrentRow.Cells[1].Value.ToString();
            cmbConcluido.Text = grid.CurrentRow.Cells[2].Value.ToString();
            txtTempo.Text = grid.CurrentRow.Cells[3].Value.ToString();
            txtExecutante.Text = grid.CurrentRow.Cells[4].Value.ToString();
            txtComentarios.Text = grid.CurrentRow.Cells[5].Value.ToString();

            omAntiga = grid.CurrentRow.Cells[1].Value.ToString();



        }




      

        private void txtBuscarOm_TextChanged_1(object sender, EventArgs e)
        {
            Buscarom();
        }

        
    }




    }
    

