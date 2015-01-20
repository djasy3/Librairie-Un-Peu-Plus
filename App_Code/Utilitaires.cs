using System;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Description résumée de Utilitaires
/// contient les fonctions de gestions d'erreurs
/// </summary>
public static class Utilitaires
{
	static Utilitaires()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //méthode générique pour envoyer un mail à webmaster en cas d'erreur ou de suggestion
    public static void EnvoiMail( string exp, string dest, string objet, string corps)
    {
        //configuration du protocole
        SmtpClient mailClient = new SmtpClient(LibConfig.MailServer);
        //creation des statut qui requier une authentification(pour les serveur smtp)
        mailClient.Credentials = new NetworkCredential(LibConfig.MailUserName, LibConfig.MailPassword);
        //création du corp du message
        MailMessage mailMessage = new MailMessage(exp, dest, objet, corps);
        //envoi du message
        mailClient.Send(mailMessage);
    }
    //méthode pour envoyer l'erreur de loggin
    public static void LogError(Exception ex)
    {
        //date et temps lors de la génération de l'erreur
        string dateTemps = DateTime.Now.ToLongDateString() + ", a " + DateTime.Now.ToShortTimeString();
        //save l'exception générée
        string messageErreur = "L'Exception generée le " + dateTemps;
        //on obtient la page qui a générée l'erreur
        System.Web.HttpContext context = System.Web.HttpContext.Current;
        //on continue à construire le corps du message
        messageErreur += "\n\n Endroit de la Page: " + context.Request.RawUrl;
        messageErreur += "\n\n Message: " + ex.Message;
        messageErreur += "\n\n Source: " + ex.Source;
        messageErreur += "\n\n Methode: " + ex.TargetSite;
        messageErreur += "\n\n Trace de la pile: \n\n" + ex.StackTrace;
        //on envoi le message s'il l'option EnableErrorLogMail est a true dans le web config
        if (LibConfig.EnableErrorLogEmail)
        {
            string exp = LibConfig.MailFrom;
            string dest = LibConfig.ErrorLogEmail;
            string objet = "Rapport d'erreur de la librairie un peu plus";
            string corps = messageErreur;
            //méthode d'envoi
            EnvoiMail(exp, dest, objet, corps);
        }
    }
    
}