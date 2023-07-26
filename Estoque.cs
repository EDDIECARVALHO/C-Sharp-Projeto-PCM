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

namespace ProjetoPcm
{
    public partial class frmEstoque : Form

    {

        Conexao con = new Conexao();
        string sql;
       MySqlCommand cmd;
        string id;
        public frmEstoque()
        {
            InitializeComponent();
        }
        private void CarregarCombobox()

        {

           // con.AbrirCon();
           // sql = "SELECT * FROM  fornecedores order by nome asc ";
           // cmd = new MySqlCommand(sql, con.con);
           // MySqlDataAdapter da = new MySqlDataAdapter();
            //da.SelectCommand = cmd;
           // DataTable dt = new DataTable();
           // da.Fill(dt);
           // cmbNome.DataSource = dt;

            // cmbEquipamento.ValueMember = id;

           // cmbEquipamento.DisplayMember = "Equipamento";


            //con.Fecharcon();




        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            CarregarCombobox();
            DesahabilitarCampos();
        }
        private void HabilitarCampos()
        {


            txtPeca.Enabled = true;
           // txtEstoque.Enabled = true;
            txtValor.Enabled = true;
           // cmbFornecedor.Enabled = true;
            txtQuantidade.Enabled = true;
            btnSalvar.Enabled = true;
            
           

            txtQuantidade.Focus();

        }
        private void DesahabilitarCampos()
        {


            txtPeca.Enabled = false;
            txtEstoque.Enabled = false;
            txtValor.Enabled = false;
            cmbFornecedor.Enabled = false;
            txtQuantidade.Enabled = false;
            btnSalvar.Enabled = false;


        }
        private void LimparCampos()
        {

            txtPeca.Text = "";
            txtEstoque.Text = "";
            txtValor.Text = "";

            txtQuantidade.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            HabilitarCampos();
            LimparCampos();
            Program.chamadaPeca = "estoque";
            Cadstro.Peças.frmPeças form = new Cadstro.Peças.frmPeças();
            form.Show();
        }

        private void frmEstoque_Activated(object sender, EventArgs e)
        {
            txtEstoque.Text = Program.estoquePeca;
            txtPeca.Text = Program.nomePeca;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (txtPeca.Text.ToString().Trim() == "")
            {
                txtPeca.Text = "";
                MessageBox.Show("Selecione uma Peça");
                txtPeca.Focus();
                return;
            }
            if (txtQuantidade.Text == "")
            {
                
                MessageBox.Show("Preencha a Quantidade");
                txtPeca.Focus();
                return;
                
            }
               //codigo botão editar
                con.AbrirCon();
                sql = "UPDATE pecas SET   valor = @valor, estoque=@estoque where id = @id";
                cmd = new MySqlCommand(sql, con.con);

            cmd.Parameters.AddWithValue("@estoque", Convert.ToDouble(txtQuantidade.Text) + Convert.ToDouble(txtEstoque.Text));
                cmd.Parameters.AddWithValue("@valor", txtValor.Text.Replace(",", "."));
             
                cmd.Parameters.AddWithValue("@id", Program.idPeca);

                cmd.ExecuteNonQuery();
                con.Fecharcon();
               






            MessageBox.Show("Lançamento de estoque feito  com Sucesso!");
               
                LimparCampos();
                DesahabilitarCampos();
           


        }
        }
    }


