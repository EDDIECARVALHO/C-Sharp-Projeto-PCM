using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoPcm
{
    static class Program
    {
        //DECLARAR AS VARIAVEIS GLOBAIS DO SISTEMA
        public static string nomeUsuario;
        public static string matriculaUsuario;
        public static string idcontrole;
        public static string chamadaPeca;
        public static string nomePeca;
        public static string estoquePeca;
        public static string idPeca;
        public static string valorPeca;
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmLogin());
        }
    }
}
