using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text;
using DAL;

namespace DesfacaFacil.Models
{
    public abstract class Notificacao
    {
        private static string endereco = "localhost:54202";
        private static void enviarNotificacao(DBUsuarios destinatario, string assunto, string conteudo)
        {
            Debug.WriteLine("Enviando email com titulo '" + assunto + "' para '" + destinatario.email + "'");
            MailServer MailServer = new MailServer("ovcentral.dyndns.org", 22025, "notificacao", "123*abc");
            MailServer.enviarEmail("notificacao@desfacafacil.com.br", destinatario.email, assunto, conteudo);
        }

        public static void mensagemRecebida(DBUsuarios remetente, DBUsuarios destinatario, DBAnuncios anuncio)
        {
            string texto = remetente.nome + " envio uma mensagem para você, referente ao anúncio " + anuncio.titulo;
            enviarNotificacao(destinatario, "Você recebeu uma nova mensagem", texto);

        }

        public static void confirmaCadastro(DBUsuarios usuario)
        {
            byte[] entrada = Encoding.UTF8.GetBytes(usuario.email);
            string hash = Convert.ToBase64String(entrada);
            string texto = "Olá " + usuario.nome + "!<br> Para confirmar seu cadastro, clique no link a seguir: <a href=\"http://" + endereco + "/Usuarios/Validar/?id=" + hash + "\">Validar</a>";
            enviarNotificacao(usuario, "Confirmação de Cadastro", texto);
        }

    }
}