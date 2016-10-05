using CadeMeuMedico.Models;
using System;
using System.Linq;
using System.Web;
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

        //Os nomes de ambos osmétodos apresentados pela listagem 7 já dão ideia de suas
        //funções no contexto da aplicação.O primeiro tenta recuperar o registro único de
        //usuário baseado no código proveniente do parâmetro do mesmo.O segundo toma
        //como base o usuário recuperado pelo primeiro método e verifica se o usuário já se
        //encontra autenticado no sistema.Simples e funcional.
        public static Usuario RecuperaUsuarioPorID(long IDUsuario)
        {
            try
            {
                using (EntidadesCadeMeuMedicoBD2 db = new EntidadesCadeMeuMedicoBD2())
                {
                    var Usuario = db.Usuario.Where(u => u.IDUsuario == IDUsuario).SingleOrDefault();
                    return Usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static Usuario VerificaSeOUsuarioEstaLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            if (Usuario == null)
            {
                return null;
            }
            else
            {
                long IDUsuario = Convert.ToInt64(RepositorioCriptografia.Descriptografar(Usuario.Values["IDUsuario"]));
                var UsuarioRetornado = RecuperaUsuarioPorID(IDUsuario);
                return UsuarioRetornado;
            }
        }

    }

}