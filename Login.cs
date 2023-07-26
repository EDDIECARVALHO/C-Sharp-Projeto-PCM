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
    public partial class FrmLogin : Form
    {
        Conexao con = new Conexao();
        public FrmLogin()
        {
            InitializeComponent();
            pnlLogin.Visible = false;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
            pnlLogin.Visible = true;
        }

        private void btnLOgin_Click(object sender, EventArgs e)
        {
            ChamarLogin();
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChamarLogin();
            }
        }

        private void ChamarLogin()
        {
            if (txtUsuario.Text.ToString().Trim() == "" || txtSenha.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Preencha os Campos");
                txtUsuario.Text = "";
                txtUsuario.Focus();
                return;
            }
            //aqui vai o codigo para o login
           
            MySqlCommand cmdVerificar;
            MySqlDataReader reader;
            con.AbrirCon();
            cmdVerificar = new MySqlCommand("SELECT * FROM  usuarios where usuario = @usuario and senha = @senha", con.con);
            cmdVerificar.Parameters.AddWithValue("@usuario", txtUsuario.Text);
            cmdVerificar.Parameters.AddWithValue("@senha", txtSenha.Text);
            reader = cmdVerificar.ExecuteReader();
            
            if (reader.HasRows)
            {
                //EXTRAINDO INFORMAÇÕES DA CONSULTA LOGIN
                while (reader.Read())
                        {
                    Program.nomeUsuario = Convert.ToString(reader["nome"]);
                    Program.matriculaUsuario = Convert.ToString(reader["matricula"]);


                }

               // MessageBox.Show("Bem vindo!"   +   Program.nomeUsuario,   "LOGIN EFETUADO",   MessageBoxButtons.OK, MessageBoxIcon.Information);
                  FrmMenu form = new FrmMenu();
                  Limpar();
                  form.Show();
            }
            else
            {
                MessageBox.Show("ERRO AO LOGAR !", "DADOS INCORRETOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtUsuario.Focus();
                txtSenha.Text = "";
               
            }
            con.Fecharcon();
        }
        private void Limpar()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtUsuario.Focus();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }
    } 
}
