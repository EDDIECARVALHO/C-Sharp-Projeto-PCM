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

namespace ProjetoPcm.Movimentacoes
{
    public partial class frmSaida : Form
    {

        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
        string idRequisicao;
        string idDetalhe;
        string idPeca;
        string totalVenda;
     

        public frmSaida()
        {
            InitializeComponent();
        }
        private void FormatarDGRequisicao()
        {
            grid.Columns[0].HeaderText = "id";
            grid.Columns[1].HeaderText = "Valor Total";
            grid.Columns[2].HeaderText = "Requisitante";
            grid.Columns[3].HeaderText = "Status";
            grid.Columns[4].HeaderText = "Data";



            grid.Columns[0].Visible = false;

            grid.Columns[1].DefaultCellStyle.Format = "C2";

        }
        private void ListarRequisicao()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  movimentacao order by data asc";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            grid.DataSource = dt;
            con.Fecharcon();
            FormatarDGRequisicao();


        }

        private void FormatarDGDetalhes()
        {
            gridDetalhes.Columns[0].HeaderText = "id";
            gridDetalhes.Columns[1].HeaderText = "Om do Pedido";
            gridDetalhes.Columns[2].HeaderText = "Peça";
            gridDetalhes.Columns[3].HeaderText = "Quantidade";
            gridDetalhes.Columns[4].HeaderText = "Valor Unitário";
            gridDetalhes.Columns[5].HeaderText = "Valor Total";
            gridDetalhes.Columns[6].HeaderText = "Funcionário";
            gridDetalhes.Columns[7].HeaderText = "id peça";

            gridDetalhes.Columns[7].Visible = false;
            gridDetalhes.Columns[1].Visible = false;


            gridDetalhes.Columns[0].Visible = false;

            gridDetalhes.Columns[4].DefaultCellStyle.Format = "C2";
            gridDetalhes.Columns[5].DefaultCellStyle.Format = "C2";

        }
        private void ListarDetalhes()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  detalhe_pedido where id_pedido = @id_pedido and funcionario =@funcionario";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_pedido", "0");
            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            gridDetalhes.DataSource = dt;
            con.Fecharcon();
            FormatarDGRequisicao();


        }

        private void HabilitarCampos()
        {


            txtPeca.Enabled = true;

            txtQuantidade.Enabled = true;
            // txtEstoque.Enabled = true;
            // txtValor.Enabled = true;
            btnPeca.Enabled = true;
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;

            txtQuantidade.Focus();

        }
        private void DesahabilitarCampos()
        {


            txtPeca.Enabled = true;

            txtQuantidade.Enabled = false;
            // txtEstoque.Enabled = false;
            // txtValor.Enabled = false;
            btnPeca.Enabled = false;
            btnAdd.Enabled = false;
            btnRemove.Enabled = false;





        }

        private void LimparCampos()
        {


            txtPeca.Text = "";
            txtEstoque.Text = "";
            txtValor.Text = "";

            txtQuantidade.Text = "";
            lblTotal.Text = "0";
        }

        private void frmSaida_Load(object sender, EventArgs e)
        {
            ListarRequisicao();
            DesahabilitarCampos();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {

            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            //btnEditar.Enabled = false;
            btnExcluir.Enabled = false;

            LimparCampos();
            ListarRequisicao();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (lblTotal.Text.ToString().Trim() == "")
            {

                MessageBox.Show("É Preciso Inserir Produtos Para requisição");

                return;
            }




        }

        private void btnPeca_Click(object sender, EventArgs e)
        {


            Program.chamadaPeca = "estoque";
            Cadstro.Peças.frmPeças form = new Cadstro.Peças.frmPeças();
            form.Show();
        }

        private void frmSaida_Activated(object sender, EventArgs e)
        {
            txtEstoque.Text = Program.estoquePeca;
            txtPeca.Text = Program.nomePeca;
            txtValor.Text = Program.valorPeca;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.ToString().Trim() == "")
            {
                txtQuantidade.Text = "";
                MessageBox.Show("Preencha a Quantidade");
                txtQuantidade.Focus();
                return;
            }
            if (Convert.ToInt32(txtEstoque.Text) < Convert.ToInt32(txtQuantidade.Text)) 
            {
                txtQuantidade.Text = "";
                MessageBox.Show("Não possui material suficiente em estoque", "Estoque insuficiente", MessageBoxButtons.OK);
                txtQuantidade.Focus();
                return;
            }


            con.AbrirCon();
            sql = "INSERT INTO detalhe_pedido(id_pedido, peca, quantidade, valor_unitario, valor_total,funcionario, id_peca ) VALUES (  @id_pedido, @peca, @quantidade, @valor_unitario, @valor_total,@funcionario, @id_peca)";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id_pedido", "0");
            cmd.Parameters.AddWithValue("@peca", txtPeca.Text);




            cmd.Parameters.AddWithValue("@quantidade", txtQuantidade.Text);

            cmd.Parameters.AddWithValue("@valor_unitario", Convert.ToDouble(txtValor.Text));

            cmd.Parameters.AddWithValue("@valor_total", Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text));

            cmd.Parameters.AddWithValue("@funcionario", Program.nomeUsuario);
            cmd.Parameters.AddWithValue("@id_peca", Program.idPeca);









            cmd.ExecuteNonQuery();

            con.Fecharcon();

            // MessageBox.Show("Registro Salvo com Sucesso!");
            
            //Abater Quantiade do estoque 
            con.AbrirCon();
            sql = "UPDATE pecas SET estoque=@estoque where id = @id";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id",idPeca);
            cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) - Convert.ToInt32(txtQuantidade.Text));













            cmd.ExecuteNonQuery();

            con.Fecharcon();


            //toatlizar a venda
            double total;
             total= Convert.ToDouble(totalVenda) + Convert.ToDouble(txtValor.Text)* Convert.ToDouble(txtQuantidade.Text);
           
            lblTotal.Text = String.Format("{0:c2}", total);
            //totalVenda = total.ToString();
            txtQuantidade.Text = "";
            txtPeca.Text = "";
            txtEstoque.Text = "0";
            txtValor.Text = "";
            idDetalhe = "";   
            ListarDetalhes();



        }

        private void gridDetalhes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idDetalhe  = gridDetalhes.CurrentRow.Cells[0].Value.ToString();
            txtPeca.Text = gridDetalhes.CurrentRow.Cells[2].Value.ToString();
            txtQuantidade.Text = gridDetalhes.CurrentRow.Cells[3].Value.ToString();
            txtValor.Text = gridDetalhes.CurrentRow.Cells[5].Value.ToString();
            idPeca = gridDetalhes.CurrentRow.Cells[7].Value.ToString();



            //recuperar total do estoque

            MySqlCommand cmdVerificar;
            MySqlDataReader reader;
            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT * FROM pecas where id = @id ", con.con);
            cmdVerificar.Parameters.AddWithValue("@id",  idPeca);
            reader = cmdVerificar.ExecuteReader();
            if (reader.HasRows) 
            {
                //extraindo informações da consulta
                while (reader.Read()) 
                {
                    txtEstoque.Text = Convert.ToString(reader["estoque"]);


                }



            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (idDetalhe == "")
            {
                txtQuantidade.Text = "";
                MessageBox.Show("Selecione um Item Para Remover", "Removendo Item ", MessageBoxButtons.OK);
                // txtQuantidade.Focus();
                return;
            }
            //codigo para deletar item venda
            con.AbrirCon();
            sql = "DELETE FROM detalhe_pedido WHERE id=@id";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", idDetalhe);
           
        








            cmd.ExecuteNonQuery();

            con.Fecharcon();

            // MessageBox.Show("Registro Salvo com Sucesso!");

            //Devolver Quantiade do estoque 
            con.AbrirCon();
            sql = "UPDATE pecas SET estoque = @estoque where id = @id";

            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@id", idPeca);
            cmd.Parameters.AddWithValue("@estoque", Convert.ToInt32(txtEstoque.Text) + Convert.ToInt32(txtQuantidade.Text));
          












            cmd.ExecuteNonQuery();

            con.Fecharcon();


            //toatlizar a venda
            double total;
            total = Convert.ToDouble(totalVenda) - Convert.ToDouble(txtValor.Text) * Convert.ToDouble(txtQuantidade.Text);
            
            lblTotal.Text = String.Format("{0:c2}", total);
            //totalVenda = total.ToString();
            txtQuantidade.Text = "";
            txtPeca.Text = "";
            txtEstoque.Text = "0";
            txtValor.Text = "";
            idDetalhe = "";
            ListarDetalhes();
        }
    }
    
}
