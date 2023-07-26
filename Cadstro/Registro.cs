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
    public partial class frmRegistro : Form
    {
        
        Conexao con = new Conexao();
        string sql;
        MySqlCommand cmd;
         string id;

        string omAntiga;


        public frmRegistro()
        {
            InitializeComponent();
            
        }

        private void CarregarCombobox()

        {

            con.AbrirCon();
            sql = "SELECT * FROM  maquinas order by Equipamento asc ";
            cmd = new MySqlCommand(sql, con.con);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbEquipamento.DataSource = dt;

            // cmbEquipamento.ValueMember = id;
            
            cmbEquipamento.DisplayMember = "Equipamento";

            
            con.Fecharcon();




        }



          private void FormatarDG()
        {
            grid.Columns[0].HeaderText = "id";
            grid.Columns[1].HeaderText = "Om";
            grid.Columns[2].HeaderText = "Chamado";
            grid.Columns[3].HeaderText = "Origem";
            grid.Columns[4].HeaderText = "Prioridade";
            grid.Columns[5].HeaderText = "Ativo";
            grid.Columns[6].HeaderText = "Equipamento";
            grid.Columns[7].HeaderText = "Tipo Om";
            grid.Columns[8].HeaderText = "Serviço Solicitado";
            grid.Columns[9].HeaderText = "Setor";
           
            grid.Columns[10].HeaderText = "Solicitante";
           
           grid.Columns[0].Visible = false;
            grid.Columns[11].Width = 500;
            grid.Columns[12].HeaderText = "Detalhamento da Atividade";
            grid.Columns[13].HeaderText = "Recursos";
            grid.Columns[14].HeaderText = "Qtd/ Mão de Obra";
            grid.Columns[14].HeaderText = "Tempo/H.H";
            grid.Columns[15].HeaderText = "Tipo De Mão de Obra";
            grid.Columns[16].HeaderText = "Custo";
            grid.Columns[17].HeaderText = "PT ";
           
            grid.Columns[18].HeaderText = "Imagem";
            grid.Columns[19].HeaderText = "Data";

            //FORMATAR COLUNA PARA MOEDA
            grid.Columns[16].DefaultCellStyle.Format = "c2";
            grid.Columns[12].Width = 300;
            grid.Columns[16].Width = 200;
            grid.Columns[17].Width = 60;
            grid.Columns[14].Width = 120;
            grid.Columns[18].Width = 150;
            grid.Columns[15].Width = 200;
            grid.Columns[8].Width = 300;
            grid.Columns[7].Width = 200;
            grid.Columns[9].Width = 200;
            grid.Columns[3].Width = 150;
        }



        private void Listar()
        {

            con.AbrirCon();
            sql = "SELECT * FROM  controle order by om asc";
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
            sql = "SELECT * FROM  controle where om LIKE @om order by om asc  ";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@om", txtBuscarOm.Text+ "%");
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmd;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            grid.DataSource = dt;
            con.Fecharcon();
            FormatarDG();
        }
        private void Buscarchamado()
        {
            con.AbrirCon();
            sql = "SELECT * FROM  controle where chamado LIKE @chamado order by om asc  ";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@chamado", txtBuscarCh.Text + "%");
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
             

            txtOm.Enabled = true;
            txtServico.Enabled = true;
            txtSolicitante.Enabled = true;
            cmbAtivo.Enabled = true;
            cmbEquipamento.Enabled = true;
            cmbOrigem.Enabled = true;
            cmbPrioridade.Enabled = true;
            cmbSetor.Enabled = true;
            cmbTipo.Enabled = true;
            txtChamado.Enabled = true;
            txtAtividade.Enabled = true;
            txtRecursos.Enabled = true;
            txtAtividade.Enabled = true;
            cmbTempo.Enabled = true;
            cmbMobra.Enabled = true;
            cmbTempo.Enabled = true;
            txtCusto.Enabled = true;
            cmbPt.Enabled = true;
            btnimg.Enabled = true;

            txtOm.Focus();

        }
        private void DesahabilitarCampos()
        {


            txtOm.Enabled = false;
            txtServico.Enabled = false;
            txtSolicitante.Enabled = false;
            cmbAtivo.Enabled = false;
           // cmbEquipamento.Enabled = false;
            cmbOrigem.Enabled = false;
            cmbPrioridade.Enabled = false;
            cmbSetor.Enabled = false;
            cmbTipo.Enabled = false;
            txtChamado.Enabled = false;
            txtAtividade.Enabled = false;
            txtRecursos.Enabled = false;
            txtAtividade.Enabled = false;
            cmbMobra.Enabled = false;
            cmbTempo.Enabled = false;
            txtCusto.Enabled = false;
            cmbPt.Enabled = false;
            btnimg.Enabled = false;

        }
        private void LimparCampos()
        {


            txtOm.Text = "";
            txtServico.Text = "";
            txtSolicitante.Text = "";
            cmbAtivo.Text = "";
           // cmbEquipamento.Text =(" 0");
            cmbOrigem.Text = "";
            cmbPrioridade.Text = "";
            cmbSetor.Text = "";
            cmbTipo.Text = "";
            txtChamado.Text = "";
            txtAtividade.Text = "";
            txtRecursos.Text = "";
            txtAtividade.Text = "";
            cmbMobra.Text = "";
            cmbTempo.Text = "";
            txtCusto.Text = "";
            cmbPt.Text = "";
            btnimg.Text = "";
            cmbQualificacao.Text = "";
            
            LimparFoto();

        }
        private void LimparFoto()
        {
            img.Image = Properties.Resources.sem_foto;
        }

       

        private void frmRegistro_Load(object sender, EventArgs e)

        {
            Listar();
            rbOm.Checked = true;
            CarregarCombobox();

            LimparFoto();
           
        }



        private void rbOm_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarOm.Visible = true;
            txtBuscarCh.Visible = false;
            txtBuscarOm.Text = "";
        }

        private void rbChamado_CheckedChanged(object sender, EventArgs e)
        {
            txtBuscarOm.Visible = false;
            txtBuscarCh.Visible = true;
            txtBuscarCh.Text = "";
        }
      
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (cmbEquipamento.Text =="") 
            {
                MessageBox.Show("Cadastre Antes  Um Equipamento");
                Close();

            }
            HabilitarCampos();
            btnSalvar.Enabled = true;
            btnNovo.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            cmbEquipamento.Text = (" 0");
            LimparCampos();
          
        }
        //PROGRAMANDO O BOTAO SALVAR
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
            sql = "INSERT INTO controle(om, chamado, origem, prioridade, ativo, equipamento, tipom, servicosolicitado, setor, solicitante,detalhe, recursos , mao_de_obra, tempo, qualificacao, custo, permissao, data ) VALUES (@om, @chamado, @origem, @prioridade, @ativo, @equipamento, @tipom,@servicosolicitado,  @setor, @solicitante, @detalhe, @recursos , @mao_de_obra, @tempo, @qualificacao, @custo, @permissao, curDATE())";
            
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@om", txtOm.Text);
            cmd.Parameters.AddWithValue("@chamado", txtChamado.Text);
           



            cmd.Parameters.AddWithValue("@origem", cmbOrigem.Text);

            cmd.Parameters.AddWithValue("@prioridade", cmbPrioridade.Text);

            cmd.Parameters.AddWithValue("@ativo", cmbAtivo.Text);

            cmd.Parameters.AddWithValue("@equipamento", cmbEquipamento.Text);

            cmd.Parameters.AddWithValue("@tipom", cmbTipo.Text);
            cmd.Parameters.AddWithValue("@servicosolicitado", txtServico.Text);

            cmd.Parameters.AddWithValue("@setor", cmbSetor.Text);

            cmd.Parameters.AddWithValue("@solicitante", txtSolicitante.Text);
            cmd.Parameters.AddWithValue("@detalhe", txtAtividade.Text);
            cmd.Parameters.AddWithValue("@recursos", txtRecursos.Text);



            cmd.Parameters.AddWithValue("@mao_de_obra", cmbMobra.Text);
            cmd.Parameters.AddWithValue("@tempo", cmbTempo.Text);

            cmd.Parameters.AddWithValue("@qualificacao", cmbQualificacao.Text);

            cmd.Parameters.AddWithValue("@custo", txtCusto.Text);

            cmd.Parameters.AddWithValue("@permissao", cmbPt.Text);
            //cmd.Parameters.AddWithValue("@data", data);


            // verificar se a OM já existe no banco

            MySqlCommand cmdVerificar;

            cmdVerificar = new MySqlCommand("SELECT * FROM  controle where om = @om", con.con);
            cmdVerificar.Parameters.AddWithValue("@om", txtOm.Text);
            MySqlDataAdapter ta = new MySqlDataAdapter();
            ta.SelectCommand = cmdVerificar;
            DataTable dt = new DataTable();
            ta.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Ordem de Trabalho já Registrado!", "ERRO AO SALVAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOm.Text = "";
                txtOm.Focus();
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

        private void grid_Click(object sender, EventArgs e)
        {
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtOm.Text.ToString().Trim() == "")
            {
                txtOm.Text = "";
                MessageBox.Show("Preencha o Campo Editar");
                txtOm.Focus();
                return;
            }
            //codigo para o botão editar
            con.AbrirCon();
            sql = "UPDATE controle SET om = @om, chamado = @chamado,origem = @origem, prioridade = @prioridade, ativo= @ativo,equipamento= @equipamento, tipom=@tipom,servicosolicitado = @servicosolicitado, setor = @setor, solicitante = @solicitante,  detalhe = @detalhe,recursos= @recursos , mao_de_obra =@mao_de_obra, tempo=@tempo, qualificacao=@qualificacao, custo=@custo, permissao=@permissao where id = @id";
            cmd = new MySqlCommand(sql, con.con);
            cmd.Parameters.AddWithValue("@om", txtOm.Text);
            cmd.Parameters.AddWithValue("@chamado", txtChamado.Text);
            cmd.Parameters.AddWithValue("@origem", cmbOrigem.Text);
            cmd.Parameters.AddWithValue("@prioridade", cmbPrioridade.Text);
            cmd.Parameters.AddWithValue("@ativo", cmbAtivo.Text);
            cmd.Parameters.AddWithValue("@equipamento", cmbEquipamento.Text);
            cmd.Parameters.AddWithValue("@tipom", cmbTipo.Text);
            cmd.Parameters.AddWithValue("@servicosolicitado", txtServico.Text);
            cmd.Parameters.AddWithValue("@setor", cmbSetor.Text);
            cmd.Parameters.AddWithValue("@solicitante", txtSolicitante.Text);
            cmd.Parameters.AddWithValue("@detalhe", txtAtividade.Text);
            cmd.Parameters.AddWithValue("@recursos", txtRecursos.Text);
            cmd.Parameters.AddWithValue("@mao_de_obra", cmbMobra.Text);
            cmd.Parameters.AddWithValue("@tempo", cmbTempo.Text);
            cmd.Parameters.AddWithValue("@qualificacao", cmbQualificacao.Text);
            cmd.Parameters.AddWithValue("@custo", txtCusto.Text);
            cmd.Parameters.AddWithValue("@permissao", cmbPt.Text);
            

            cmd.Parameters.AddWithValue("@id", id);
            //codigo para verificar  se om já existe no banco de dados 
            if (txtOm.Text != omAntiga)
            {
                MySqlCommand cmdVerificar;

                cmdVerificar = new MySqlCommand("SELECT * FROM  controle where om = @om", con.con);
                cmdVerificar.Parameters.AddWithValue("@om", txtOm.Text);
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
                sql = "DELETE FROM controle where id = @id";
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

        private void btnimg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagens (*.jpg;*.PNG)*.png)|*.jpg|Arquivos PNG(*.png)|*.png|Todos os Arquivos(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foto = dialog.FileName.ToString();
                img.ImageLocation = foto;
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
            txtOm.Text = grid.CurrentRow.Cells[1].Value.ToString();
            txtChamado.Text = grid.CurrentRow.Cells[2].Value.ToString();
            cmbOrigem.Text = grid.CurrentRow.Cells[3].Value.ToString();
            cmbPrioridade.Text = grid.CurrentRow.Cells[4].Value.ToString();
            cmbAtivo.Text = grid.CurrentRow.Cells[5].Value.ToString();
            cmbEquipamento.Text = grid.CurrentRow.Cells[6].Value.ToString();
            cmbTipo.Text = grid.CurrentRow.Cells[7].Value.ToString();
            txtServico.Text = grid.CurrentRow.Cells[8].Value.ToString();

            cmbSetor.Text = grid.CurrentRow.Cells[9].Value.ToString();
           
            txtSolicitante.Text = grid.CurrentRow.Cells[10].Value.ToString();
            omAntiga = grid.CurrentRow.Cells[1].Value.ToString();
            txtAtividade.Text = grid.CurrentRow.Cells[11].Value.ToString();
            txtRecursos.Text = grid.CurrentRow.Cells[12].Value.ToString();
            cmbMobra.Text = grid.CurrentRow.Cells[13].Value.ToString();
            cmbTempo.Text = grid.CurrentRow.Cells[14].Value.ToString();
            cmbQualificacao.Text = grid.CurrentRow.Cells[15].Value.ToString();
            txtCusto.Text = grid.CurrentRow.Cells[16].Value.ToString();
            cmbPt.Text = grid.CurrentRow.Cells[17].Value.ToString();
           // data.Text = grid.CurrentRow.Cells[18].Value.ToString();



        }

        private void txtBuscarOm_TextChanged(object sender, EventArgs e)
        {
            Buscarom();
        }

        private void txtBuscarCh_TextChanged(object sender, EventArgs e)
        {
            Buscarchamado();
        }

        private void btnRel_Click(object sender, EventArgs e)
        {
            Relatorio.FrmRelOrdem form = new Relatorio.FrmRelOrdem();
            form.Show();
        }

        private void grid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
