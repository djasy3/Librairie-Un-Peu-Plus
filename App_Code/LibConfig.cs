using System;
using System.Configuration;

/// <summary>
/// Description résumée de LibConfig
/// Classe qui contient les différentes configurations
/// Chaines de connexion et différents protocoles
/// </summary>
public static class LibConfig
{
    //chaine de connexion
    private static string dbConnectionString;
    //fournisseur de données(pilotes)
    private static string dbProviderName;
    //le nom du site
    private readonly static string nomSite;

	static LibConfig()
	{
        dbConnectionString = ConfigurationManager.ConnectionStrings["LUP"].ConnectionString;
        dbProviderName = ConfigurationManager.ConnectionStrings["LUP"].ProviderName;
        nomSite = ConfigurationManager.AppSettings["NomSite"];
	}
    //propriété pour retourner la chaine de connexion de la base de données
    public static string DbConnectionString
    {
        get { return dbConnectionString; }
    }
    //idem mais cette fois-ci le fournisseur de la bdd/access dans ce cas
    public static string DbProviderName
    {
        get { return dbProviderName; }
    }
    //on retourne l'addresse du site
    public static string NomSite
    {
        get { return nomSite; }
    }
    //on retourne l'addresse du serveur de messagerie
    public static string MailServer
    {
        get { return ConfigurationManager.AppSettings["MailServer"]; }
    }
    //on retourne l'addresse mail du user
    public static string MailUserName
    {
        get { return ConfigurationManager.AppSettings["MailUserName"]; }
    }
    //on retourne le mot de passe du user
    public static string MailPassword
    {
        get { return ConfigurationManager.AppSettings["MailPassword"]; }
    }
    //on retourne l'addresse d'expédition
    public static string MailFrom
    {
        get { return ConfigurationManager.AppSettings["MailFrom"]; }
    }
    //on retourne les erreurs de logging
    public static bool EnableErrorLogEmail
    {
        get { return bool.Parse(ConfigurationManager.AppSettings["EnableErrorLogEmail"]); }
    }
    //on retourne l'addresse e-mail ou doivent être envoyé les erreurs;
    public static string ErrorLogEmail
    {
        get { return ConfigurationManager.AppSettings["ErrorLogEmail"]; }
    }
    //retourne le nombre de jour d'expiration du shoppingCart
    public static int CartPersistDays
    {
        get { return int.Parse(ConfigurationManager.AppSettings["CartPersistDays"]); }
    }
}