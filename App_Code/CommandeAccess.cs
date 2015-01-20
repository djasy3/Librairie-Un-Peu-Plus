using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;

///<sumary>
///struct decrivant les détails sur la commande à passer à la couche de présentation
///</sumary>
public struct InfoCommande
{
    public int CmdID;
    public decimal SommeTotale;
    public string DateDeCmd;
    public string DateDeLivraison;
    public bool VerifiE;
    public bool CompletE;
    public bool AnnulE;
    public string Commentaires;
    public string NomClient;
    //public string EmailClient;
    public string AddresseDeLivraison;

}
/// <summary>
/// Description résumée de CommandeAccess
/// </summary>
public class CommandeAccess
{
	public CommandeAccess()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    //on obtient les commandes placées récemments
    public static DataTable GetByRecent()
    {
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procedure
        m_cmd.CommandText = "CmdObtenuesRecement";
        //on stocke le résultat dans une table
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        //on retourne la table
        return m_table;
    }
    //les commande placée durant un intervale de temps données
    public static DataTable GetByDate(string jourDebut, string jourFin)
    {
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure
        m_cmd.CommandText = "CmdObtenuesParDate";
        //on crée les paramètres
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@DateDebut";
        m_param.Value = jourDebut;
        m_param.DbType = DbType.Date;
        m_cmd.Parameters.Add(m_param);
        //deuxième paramètre
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@DateFin";
        m_param.Value = jourFin;
        m_param.DbType = DbType.Date;
        m_cmd.Parameters.Add(m_param);
        //on retourne la table
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        return m_table;
    }
    //les commande qui doivent être vérifée ou annulée
    public static DataTable GetNonVerifieNonAnnulE()
    {
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure
        m_cmd.CommandText = "CmdNonVerifEetNonAnnulE";
        //on stocke le résultat dans une table
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        //on retourne la table
        return m_table;
    }
    //les commandes qui doivent être posté/complété
    public static DataTable GetVerifieNonComplete()
    {
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure
        m_cmd.CommandText = "CmdVerifiEetNonCompletE";
        //on stocke le résultat dans une table
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        //on retourne la table
        return m_table;
    }
    //on obtient les informations sur la commande
    public static InfoCommande GetInfo(string cmdId)
    {
        //appelle à la commande de connexin
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit le nom de la procedure stockée
        m_cmd.CommandText = "InfoCommande";
        //on créer le paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CmdID";
        m_param.Value = cmdId;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        // on obtient les résultats
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        DataRow m_ligneCmd = m_table.Rows[0];
        //on sauvegarde le résultat dans la structure
        InfoCommande infoCmd;
        infoCmd.CmdID = Int32.Parse(m_ligneCmd["CmdID"].ToString());
        infoCmd.SommeTotale = Decimal.Parse(m_ligneCmd["SommeTotale"].ToString());
        infoCmd.DateDeCmd = m_ligneCmd["DateDeCmd"].ToString();
        infoCmd.DateDeLivraison = m_ligneCmd["DateDeLivraison"].ToString();
        infoCmd.VerifiE = bool.Parse(m_ligneCmd["VerifiE"].ToString());
        infoCmd.CompletE = bool.Parse(m_ligneCmd["CompletE"].ToString());
        infoCmd.AnnulE = bool.Parse(m_ligneCmd["AnnulE"].ToString());
        infoCmd.Commentaires = m_ligneCmd["Commentaires"].ToString();
        infoCmd.NomClient = m_ligneCmd["NomClient"].ToString();
        
        infoCmd.AddresseDeLivraison = m_ligneCmd["AddresseDeLivraison"].ToString();
        //on retourne la structure
        return infoCmd;
    }
    //on revoit les détails sur la commande
    public static DataTable GetDetails(string cmdId)
    {
        //configuration de la commande de connexion
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on definit la procédure
        m_cmd.CommandText = "CommandeGetDetails";
        //on définit les paramètres
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CmdID";
        m_param.Value = cmdId;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on retourne les résultats
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        return m_table;
    }
    //mettre à jour une commande
    public static void MajCmd(InfoCommande infoCmd)
    {
        //configuration de la commande de connexion
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure
        m_cmd.CommandText = "MajCommande";
        //on crée le paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CmdID";
        m_param.Value = infoCmd.CmdID;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_cmd);
        //on créer un deuxième paramète
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@DateDeCmd";
        m_param.Value = infoCmd.DateDeCmd;
        m_param.DbType = DbType.DateTime;
        m_cmd.Parameters.Add(m_cmd);
        //ici le paramètre de la date de livraison est configuré si la donnée est disponible
        if(infoCmd.DateDeLivraison.Trim() != "")
        {
            m_param = m_cmd.CreateParameter();
            m_param.ParameterName = "@DateDeLivraison";
            m_param.Value = infoCmd.DateDeLivraison;
            m_param.DbType = DbType.DateTime;
            m_cmd.Parameters.Add(m_cmd);
        }
        //on continue avec la création des paramètres
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@VerifiE";
        m_param.Value = infoCmd.VerifiE;
        m_param.DbType = DbType.Byte;
        m_cmd.Parameters.Add(m_cmd);
        //4eme paramètre
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CompletE";
        m_param.Value = infoCmd.CompletE;
        m_param.DbType = DbType.Byte;
        m_cmd.Parameters.Add(m_cmd);
        //5ème paramètre
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@AnnulE";
        m_param.Value = infoCmd.AnnulE;
        m_param.DbType = DbType.Byte;
        //6ème paramètre
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@Commentaire";
        m_param.Value = infoCmd.Commentaires;
        m_param.DbType = DbType.String;
        m_cmd.Parameters.Add(m_cmd);
        //7ème param...
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@NomClient";
        m_param.Value = infoCmd.NomClient;
        m_param.DbType = DbType.String;
        m_cmd.Parameters.Add(m_cmd);
        //8ème param...
        //m_param = m_cmd.CreateParameter();
        //m_param.ParameterName = "@EmailClient";
        //m_param.Value = infoCmd.EmailClient;
        //m_param.DbType = DbType.String;
        //m_cmd.Parameters.Add(m_cmd);
        //9ème param...
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@AddresseDeLivraison";
        m_param.Value = infoCmd.AddresseDeLivraison;
        m_param.DbType = DbType.String;
        m_cmd.Parameters.Add(m_cmd);
        //on retourne les résultats
        LibAccesGenerique.ExecuteNonQuery(m_cmd);
    }
    //marquer la commande comme vérifiée
    public static void MarqueCmdVerifiE(string cmdId)
    {
        //configuration de la commande de connexion
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure
        m_cmd.CommandText = "MarqueCmdVerifiE";
        //on crée le paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CmdID";
        m_param.Value = cmdId;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on retourne les résultats
        LibAccesGenerique.ExecuteNonQuery(m_cmd);
    }
    //marquer la commande comme complétée
    public static void MarqueCmdCompletE(string cmdId)
    {
        //configuration de la commande de connexion
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure
        m_cmd.CommandText = "MarqueCmdCompletE";
        //on crée le paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CmdID";
        m_param.Value = cmdId;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on retourne les résultats
        LibAccesGenerique.ExecuteNonQuery(m_cmd);
    }
    //marquer la commande comme annulée
    public static void MarquerCmdAnnulE(string cmdId)
    {
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure
        m_cmd.CommandText = "MarqueCmdAnnulE";
        //on crée le paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CmdID";
        m_param.Value = cmdId;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on retourne les résultats
        LibAccesGenerique.ExecuteNonQuery(m_cmd);
    }
}