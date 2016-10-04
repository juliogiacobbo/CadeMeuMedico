using CadeMeuMedico.Models;
using System;
using System.Linq;
using System.Web.Security;

namespace CadeMeuMedico.Repositorios
{
    public class RepositorioUsuarios
    {

        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");
            try
            {
                using (EntidadesCadeMeuMedicoBD2 db = new EntidadesCadeMeuMedicoBD2())
                {
                    var queryAutenticaUsuarios = db.Usuario.Where(x => x.Login == Login && x.Senha == SenhaCriptografada).SingleOrDefault();

                    if (queryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    else
                    {
                        RepositorioCookies.RegistraCookieAutenticacao(queryAutenticaUsuarios.IDUsuario);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}