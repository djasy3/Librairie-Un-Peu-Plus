using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Description résumée de Liens
/// </summary>
public static class Liens
{
	static Liens()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //
    private static string LienAbsolu(string lienRelatif)
    {
        //lien courant
        Uri m_uri = HttpContext.Current.Request.Url;
        //lien absolue
        string app = HttpContext.Current.Request.ApplicationPath;
        if (!app.EndsWith("/"))
        {
            app += "/";
        }
        lienRelatif = lienRelatif.TrimStart('/');
        //on retourne le chemin relatif
        return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}",m_uri.Host,m_uri.Port,app,lienRelatif));
    }
    //génère le lien qui renvoi la description complète sur les nouveautés
    public static string LivreIndex(string livreId, string page)
    {
        if (page == "1")
        {
            return LienAbsolu(String.Format("Details/description.aspx?Numlivre={0}", livreId));
        }
        else
        {
            return LienAbsolu(String.Format("Details/description.aspx?Numlivre={0}&DataPager1={1}", livreId, page));
        }
    }
    //lien pour la premiere page
    public static string LivreIndex(string livreId)
    {
        return LivreIndex(livreId, "1");
    }
    //génère le lien qui renvoi la description sur les livres restant de la base données
    public static string Livres(string livreId)
    {
        return LienAbsolu(String.Format("Details/details.aspx?Numlivre={0}", livreId));
    }
    //info
    public static string LivresInfo(string livreId)
    {
        return LienAbsolu(String.Format("Informatique/details.aspx?Numlivre={0}", livreId));
    }
    //techno
    public static string LivresTechno(string livreId)
    {
        return LienAbsolu(String.Format("Technologies/details.aspx?Numlivre={0}", livreId));
    }
    //affaires
    public static string LivresAffaires(string livreId)
    {
        return LienAbsolu(String.Format("Affaires/details.aspx?Numlivre={0}", livreId));
    }
    //retour a chaque catégorie
    public static string Categorie(string categorie)
    {
        if (categorie == "Informatique")
            return LienAbsolu(String.Format("Informatique/informatiques.aspx"));
        else if (categorie == "Technologi")
            return LienAbsolu(String.Format("Techonologies/technologies.aspx"));
        else
            return LienAbsolu(String.Format("Affaires/affaires.aspx"));
    }
    //génère le lien qui envoi l'id du livre pour le shopping cart
    public static string IdShoppingCart(string NumLivre)
    {
        return LienAbsolu(String.Format("~/index.aspx?Numlivre={0}",NumLivre));
    }
}