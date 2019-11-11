using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBanco01
{
    class UsuarioDAO
    {
        private Banco db;

        
        //public void Insert(string vNome, string vCargo, string vData)

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
                    DataNasc = DateTime.Parse(retorno["Data"].ToString())
                };
                usuarios.Add(TempUsuario);
            }
            retorno.Close();
            return usuarios;
        }





    }
}
