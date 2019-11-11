using AppBancoDominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDLL
{
    public class UsuarioDAO
    {
        private Banco db;

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===========MENU==========\n" +
                              " 0 - Cadastrar Usuario\n" +
                              " 1 - Editar Usuario\n" +
                              " 2 - Excluir Usuario\n" +
                              " 3 - Listar Usuarios\n" +
                              " 4 - Sair \n" +
                              "=========================\n\n" +
                              "Escolha uma das opções acima!");

        }

        public Usuario DadosUsuario(Usuario usuario)
        {

            Console.WriteLine("Digite o nome do usuário");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.NomeUsu = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite o cargo do usuario");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.Cargo = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Digite a data de nascimento do usuario");
            Console.ForegroundColor = ConsoleColor.Red;
            usuario.DataNasc = DateTime.Parse(Console.ReadLine());
            return usuario;
        }

        public void Insert(Usuario usuario)
        {

            var StrQuery = "";
            StrQuery += "INSERT INTO tbUsuario(NomeUsu, Cargo, DataNasc)";             
            StrQuery += string.Format("VALUES('{0}', '{1}', CONVERT(DATETIME,'{2}',103));",
                //Passando como parametro os atributos da classe Usuario
                usuario.NomeUsu, usuario.Cargo, usuario.DataNasc);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }

        public void Atualizar(Usuario usuario)
        {
            var StrQuery = "";
            StrQuery += "UPDATE tbUsuario SET ";
            StrQuery += string.Format("NomeUsu = '{0}',", usuario.NomeUsu);
            StrQuery += string.Format("Cargo = '{0}',", usuario.Cargo);
            StrQuery += string.Format("DataNasc = CONVERT(DATETIME, '{0}' ,103)", usuario.DataNasc);
            StrQuery += string.Format("WHERE IdUsu = '{0}'", usuario.IdUsu);

            using (db = new Banco())
            {
                db.ExecutaComando(StrQuery);
            }
        }

        //Passando como parametro o objeto usuario da classe Usuario
        public void Excluir(Usuario usuario)
        {
            var strQuery =  "";
            strQuery += string.Format("DELETE FROM tbUsuario WHERE IdUsu = '{0}'", usuario.IdUsu);
            
            using (db = new Banco())
            {
                db.ExecutaComando(strQuery);
            }
        }

        //Metodo onde caso o Id digitado ja exista, ele irá atualizar(UPDATE) caso não tenha, fará insert
        public void Salvar(Usuario usuario)
        {
            if (usuario.IdUsu > 0)
            {
                Atualizar(usuario);
                
            }else
            {
                Insert(usuario);
            }
        }

        //Retorno desse metodo é uma List
        public List<Usuario> Listar()
        {
            var db = new Banco();
            var strQuery = "SELECT * FROM tbUsuario;";
            var retorno = db.RetornaComando(strQuery);
            return ListaDeUsuario(retorno);
        }

        public List<Usuario> ListaDeUsuario(SqlDataReader retorno)
        {
            var usuarios = new List<Usuario>();

            while (retorno.Read())
            {
                var TempUsuario = new Usuario()
                {
                    IdUsu = int.Parse(retorno["IdUsu"].ToString()),
                    NomeUsu = retorno["NomeUsu"].ToString(),
                    Cargo = retorno["Cargo"].ToString(),
                    DataNasc = DateTime.Parse(retorno["DataNasc"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }

        //Usar na validação de usuário
        public Usuario ListarID(int Id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("SELECT * FROM tbUsuario WHERE IdUsu = {0};", Id);
                var retorno = db.RetornaComando(strQuery);
                return ListaDeUsuario(retorno).FirstOrDefault();
            }
        }





    }
}
