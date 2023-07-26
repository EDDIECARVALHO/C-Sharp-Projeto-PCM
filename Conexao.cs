using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoPcm
{
    class Conexao
    {      //CONEXÃO COM BANCO DE DADOS LOCAL
        string conec = "SERVER=localhost; DATABASE=sistemapcm; UID=root;Allow Zero Datetime=True; PWD=; PORT=;";
        public MySqlConnection con = null;
        public void AbrirCon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Open();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        public void Fecharcon()
        {
            try
            {
                con = new MySqlConnection(conec);
                con.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }




        //DECLARAÇÃO DE OUTRAS VARIAVEIS GLOBAIS
       
    }




}
    
  

    

