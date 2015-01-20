using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

///<summary>
///structure qui renvoi la description des données du livre demandées
///</summary>
public struct DescriptionNew
{
    //tous les champs concernés
    public int NumLivre;
    public string Titre;
    public string Auteur;
    public DateTime Date;
    public string Isbn;
    public string Prix;
    public string Description;
    public string MaisonEdition;
    public string Categorie;
    public string Type;

}
/// <summary>
/// Description résumée de PresentationLivres
/// Donnes les methodes d'acces aux données des pages
/// Présentes les données aux pages du cotés clients
/// </summary>
public static class PresentationLivres
{
	static PresentationLivres()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //affiches les données de différents pages
    public static DataTable GetListeLivres()
    {
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //set le nom de la procédure(requetes)
        m_cmd.CommandText = "VueLivres";//requetes pre enregistrer dans la base de données
        //on execute la requete
        return LibAccesGenerique.ExecuteCmd(m_cmd);
    }
    //afficher les données pages index
    public static DataTable GetIndex()
    {
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on assigne la requete
        m_cmd.CommandText = "VueNouveautes";
        //on execute la requete
        return LibAccesGenerique.ExecuteCmd(m_cmd);
    }
    //cette méthode affiche la descrption complète des nouveaux livres, elle recoit en parametre l'id du livre
    public static DescriptionNew GetDescriptionNew(string numLivre)
    {
        //on crée la commande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on assigne la requete
        m_cmd.CommandText = "DescriptionNouveau";
        //on crée le parametre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@NumLivre";
        m_param.Value = numLivre;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on execute la requete avec le parametre
        //cette methode nous permettra de bien gérér les erreur venant du coté client
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        //on charge les données recu de bdd dans notre structure.(elles sont présents sur une ligne seulement
        DescriptionNew DescriptionNouveau = new DescriptionNew();
        if(m_table.Rows.Count > 0 )
        {
            //on extrait la première ligne de notre table virtuelle
            DataRow m_lignesDonnees = m_table.Rows[0];
            //détails sur les livres
            DescriptionNouveau.NumLivre = int.Parse(numLivre);
            DescriptionNouveau.Titre = m_lignesDonnees["Titre"].ToString();
            DescriptionNouveau.Auteur = m_lignesDonnees["Auteur"].ToString();
            DescriptionNouveau.Date = DateTime.Parse(m_lignesDonnees["Date"].ToString());
            DescriptionNouveau.Isbn = m_lignesDonnees["Isbn"].ToString();
            DescriptionNouveau.Prix = m_lignesDonnees["Prix"].ToString();
            DescriptionNouveau.Description = m_lignesDonnees["Description"].ToString();
        }
        return DescriptionNouveau;
    }
    //livres rubrique informatique
    public static DataTable GetInfo()
    {
        //on créer la commande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on assigne la requete
        m_cmd.CommandText = "VueInfo";
        //on execute la requete
        return LibAccesGenerique.ExecuteCmd(m_cmd);
    }
    //livres rubrique Technologie
    public static DataTable GetTechno()
    {
        //on créer la commande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on assigne la requete
        m_cmd.CommandText = "VueTechno";
        //on execute la commande
        return LibAccesGenerique.ExecuteCmd(m_cmd);
    }
    //rubriques Affaires
    public static DataTable GetAffaires()
    {
        //on créer la commande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on assigne la requete
        m_cmd.CommandText = "VueAffaires";
        //on execute la commande
        return LibAccesGenerique.ExecuteCmd(m_cmd);
    }
    //détails sur les livres
    public static DescriptionNew GetDetails(string numLivre)
    {
        //on crée la commande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on assign la requete à la nouvelle commande
        m_cmd.CommandText = "DescriptionLivres";
        //on crée le paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@NumLivre";
        m_param.Value = numLivre;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on execute la requete avec le parametre
        //cette methode nous permettra de bien gérér les erreur venant du coté client
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        //on charge les données recu de bdd dans notre structure.(elles sont présents sur une ligne seulement
        DescriptionNew DescriptionLivres = new DescriptionNew();
        if (m_table.Rows.Count > 0)
        {
            //on extrait la première ligne de notre table virtuelle
            DataRow m_lignesDonnees = m_table.Rows[0];
            //détails sur les livres
            DescriptionLivres.NumLivre = int.Parse(numLivre);
            DescriptionLivres.Titre = m_lignesDonnees["Titre"].ToString();
            DescriptionLivres.Auteur = m_lignesDonnees["Auteur"].ToString();
            DescriptionLivres.Date = DateTime.Parse(m_lignesDonnees["AnneeEdition"].ToString());
            DescriptionLivres.Isbn = m_lignesDonnees["Isbn"].ToString();
            DescriptionLivres.Prix = m_lignesDonnees["Prix"].ToString();
            DescriptionLivres.Description = m_lignesDonnees["Description"].ToString();
            DescriptionLivres.MaisonEdition = m_lignesDonnees["Edition"].ToString();
            DescriptionLivres.Type = m_lignesDonnees["Type"].ToString();
            DescriptionLivres.Categorie = m_lignesDonnees["Categorie"].ToString();
        }
        return DescriptionLivres;
    }
}