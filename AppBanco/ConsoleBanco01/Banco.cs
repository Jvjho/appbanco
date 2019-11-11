using System;
//Apos declarado o uso da biblioteca System.Data não é necessário inseri-lo em nenhuma parte do código
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleBanco01
{
    class Banco : IDisposable
    {
        //variavel do tipo readonly não pode receber valores depois de ser iniciada
        private readonly SqlConnection conexao;

        //Metodo construtor, recebe o mesmo nome da classe
        public Banco()
        {
            //Fazendo deste modo, o projeto usa como referencia a conexão que esta em App.Config, fica mais fácil para fazer manutenção
            conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }
        
        public void ExecutaComando(string StrQuery)
        {
            var vComando = new SqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexao 
            };
            //Dando comando NonQuery para que possa ser executado um comando SQL
            vComando.ExecuteNonQuery();
        }

        public SqlDataReader RetornaComando (string Strquery)
        {
            var comando = new SqlCommand(Strquery, conexao);
            return comando.ExecuteReader();

        }

        //Metodo Dipose sempre é executado quando a classe for chamada
        public void Dispose()
        {
            //Testando se o estado da conexao está aberto, caso esteja, irá fecha-la
            if (conexao.State == ConnectionState.Open)
            conexao.Close();
        }


    }
}
