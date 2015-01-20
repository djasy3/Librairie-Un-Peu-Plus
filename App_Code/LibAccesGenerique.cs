using System;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;

/// <summary>
/// Description résumée de LibAccesGenerique
/// Classe d'accès générique aux données, par elle sera établie toutes les connexions des différentes pages qui requierent
/// l'accès au données.
/// Cette classe implémente les méthodes génériques qui permettront à toutes les pages d'accéder au données
/// </summary>
public static class LibAccesGenerique
{
	static LibAccesGenerique()
	{
	    //csteur	
	}
    //execute une commande and renvoi le résultat dans un objet datatable
    public static DataTable ExecuteCmd(DbCommand cmd)
    {
        //Datatable a retourner
        DataTable m_table;
        //connexion a la base
        try
        {
            //ouvrir la connection
            cmd.Connection.Open();
            //execute la commande et enregistre le résultat dans la datatable
            DbDataReader m_reader = cmd.ExecuteReader();
            m_table = new DataTable();
            m_table.Load(m_reader);
            //on ferme le reader
            m_reader.Close();
        }
        catch (Exception ex)
        {
            //exception générique
            Utilitaires.LogError(ex);
            throw;
        }
        finally
        {
            //si tout se déroule bien on ferme la connexion
            cmd.Connection.Close();
        }
        return m_table;
    }
    //crée et prépare un nouvel objet Dbcommand sur la connexion établie
    public static DbCommand CreerCmd()
    {
        //on obtient le nom du fournisseur a partir de la propriété créer dans main
        string dataProviderName = LibConfig.DbProviderName;
        //chaine de connexion
        string dataCnx = LibConfig.DbConnectionString;
        //on créer une couche standard(générique), celle-ci nous permet de changer de bases de données sans isues
        DbProviderFactory m_factory = DbProviderFactories.GetFactory(dataProviderName);
        //connexion spécifique à la base de données
        DbConnection m_cnx = m_factory.CreateConnection();
        //set la chaine de connexion
        m_cnx.ConnectionString = dataCnx;
        //créer la commande standard
        DbCommand m_cmd = m_cnx.CreateCommand();
        //on assigne la requete enregistré sur la commande
        m_cmd.CommandType = CommandType.StoredProcedure;
        //on retourne le résultat
        return m_cmd;
    }
    //commande de supression-modification-insertion
    //et qui retourne le nombre de ligne affectée par l'action
    public static int ExecuteNonQuery(DbCommand cmd)
    {
        //le nombre de ligne affectées dans la bdd
        int ligneAffectees = -1;
        //execution de la commande et s'assurer la connexion à la base est close
        try
        {
            //ouverture de la connexion
            cmd.Connection.Open();
            //on execute la commande et on obtient le nombre de lignes affectées
            ligneAffectees = cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            //on génère l'erreur, si rencontréé
            Utilitaires.LogError(ex);
            throw;
        }
        finally
        {
            //on ferme la connexion
            cmd.Connection.Close();
        }
        //on retourne le nombre de lignes affectées
        return ligneAffectees;
    }
    //on execute une commande de selection et on renvoi le résultat sous forme de chaine de charactère
    public static string ExecuteScalar(DbCommand cmd)
    {
        //la valeur à être retournée
        string valeur = "";
        //execution de la commande et s'assurer la connexion à la base est close
        try
        {
            //ouverture de la connexion
            cmd.Connection.Open();
            //on execute la commande et on obtient la première ligne affectée
            valeur = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            //on génère l'erreur, si rencontréé
            Utilitaires.LogError(ex);
            throw;
        }
        finally
        {
            //on ferme la connexion
            cmd.Connection.Close();
        }
        //on retourne la première ligne affectée
        return valeur ;
    }
}