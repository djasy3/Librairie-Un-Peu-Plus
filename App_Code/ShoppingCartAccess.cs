using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.Common;
using System.Web.Security;

/// <summary>
/// Description résumée de ShoppingCartAccess
/// </summary>
public class ShoppingCartAccess
{
	public ShoppingCartAccess()
	{
		//
		// TODO: Add constructor logic here
		//

	}
    //retourne l'ID du shoppingCart du visiteur ou utilisateur sur le site
    private static string ShoppingCartId
    {
        get
        {
            //on obtient le HttpContext actuel
            HttpContext context = HttpContext.Current;
            //on essaie d'extraire l'id stockés dans le cookie de l'utilisateur actuel
            string cartId; //= context.Request.Cookies["LUP_CartID"].Value;
            //si l'id du Cart n'est pas dans le cookie
            {
                //on vérifie si l'id du cart existe en tant que cookie
                if (context.Request.Cookies["LUP_CartID"] != null)
                {
                    //on retourne l'id
                    cartId = context.Request.Cookies["LUP_CartID"].Value;
                    return cartId;
                }
                else
                {
                    //si l'id du cart n'existe pas dans le cookie, on génère un new id
                    //en générant un GUID(Globally Unique IDentifier
                    cartId = Guid.NewGuid().ToString();
                    //on créer un cookie et on lui attribue une valeur
                    HttpCookie cookie = new HttpCookie("LUP_CartID", cartId);
                    //on définie le nombre de jours du cookie
                    int nbreDejours = LibConfig.CartPersistDays;
                    DateTime dateActuelle = DateTime.Now;
                    //pour obtenir une intervalle de temps: structure
                    TimeSpan intevalTemps = new TimeSpan(nbreDejours, 0, 0,0);
                    //on définit la date d'expiration
                    DateTime dateExpiration = dateActuelle.Add(intevalTemps);
                    cookie.Expires = dateExpiration;
                    //on définit le cookie dans le navigateur du client
                    context.Response.Cookies.Add(cookie);
                    //on retourne l'id du cart
                    return cartId.ToString();
                }
            }
        }
    }
    //methode pour ajouter un produit dans notre shopping Cart
    public static bool AjouterProduit(string produitId)
    {
        //on crée la commande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //nom de la procedure stockées
        m_cmd.CommandText = "Ajout_Part1";
        //on crée un nouveau paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@ProduitID";
        m_param.Value = produitId;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on crée un nouveau Parametre
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CartID";
        m_param.Value = ShoppingCartId;
        m_param.DbType = DbType.String;
        m_param.Size = 36;
        m_cmd.Parameters.Add(m_param);
        
        //on execute la commande avec les paramètres
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        try
        {
            //on crée des nouvelles commande pour l'execution
            DbCommand m_cmd2 = LibAccesGenerique.CreerCmd();
            //on vérifie si le produit existe déjà dans la table, si oui, on ajoute que la quantité
            if (m_table.Rows.Count > 0 )
            {
                //nom procédure stockées
                m_cmd2.CommandText = "UpdateShoppingCart";
                //on crée un nouveau paramètre
                DbParameter m_param1 = m_cmd2.CreateParameter();
                m_param1.ParameterName = "@ProduitID";
                m_param1.Value = produitId;
                m_param1.DbType = DbType.Int32;
                m_cmd2.Parameters.Add(m_param1);
                //on crée un deuxième paramètre
                m_param1 = m_cmd2.CreateParameter();
                m_param1.ParameterName = "@CartID";
                m_param1.Value = ShoppingCartId;
                m_param1.DbType = DbType.String;
                m_param1.Size = 36;
                m_cmd2.Parameters.Add(m_param1);
                
                //on exécute la commande avec les nouveau paramètres
                return (LibAccesGenerique.ExecuteNonQuery(m_cmd2)!= -1);
            }
            else
            {
                //nom de la procedure stocké
                m_cmd2.CommandText = "Ajout_Part2";
                //m_cmd2.Parameters.Clear();
                DbParameter m_param1 = m_cmd2.CreateParameter();
                m_param1.ParameterName = "@ProduitID";
                m_param1.Value = produitId;
                m_param1.DbType = DbType.Int32;
                m_cmd2.Parameters.Add(m_param1);
                //si le produit n'existait pas, on ajoute les nouvelles données dans la table
                //on obtient le résultat de la procédure ensuite
                int n = Convert.ToInt32(LibAccesGenerique.ExecuteScalar(m_cmd2));
                //
                DbCommand m_cmd3 = LibAccesGenerique.CreerCmd();
                if (n > 0)
                {
                    //m_cmd2.Parameters.Clear();
                    m_cmd3.CommandText = "InsertShoppingCart";
                    DbParameter m_param2 = m_cmd3.CreateParameter();
                    m_param2 = m_cmd3.CreateParameter();
                    m_param2.ParameterName = "@CartID";
                    m_param2.Value = ShoppingCartId;
                    m_param2.DbType = DbType.String;
                    m_param2.Size = 36;
                    m_cmd3.Parameters.Add(m_param2);
                    //on créer des nouveaux paramètres
                    m_param2 = m_cmd3.CreateParameter();
                    m_param2.ParameterName = "@ProduitID";
                    m_param2.Value = produitId;
                    m_param.DbType = DbType.Int32;
                    m_cmd3.Parameters.Add(m_param2);
                }
                return (LibAccesGenerique.ExecuteNonQuery(m_cmd3) != -1);
            }
        }
        catch
        {
            return false;
        }
        
    }
    //méthode pour mettre à jour les données dans la table
    public static bool MajProduit(string produit, int qte)
    {
        //on obtient l'objet configuré DbCommande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on établit la procédure stockée
        if (qte <= 0)
            m_cmd.CommandText = "ShoppingCartDeleteProduits";
        else
            m_cmd.CommandText = "ShoppingCartUpdateProduit";
        //on créer les paramètres
        DbParameter m_param = m_cmd.CreateParameter();
        //parametre qté
        m_param.ParameterName = "@Quantite";
        m_param.Value = qte;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);

        //on en crée un autre produit
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@Produit";
        m_param.Value = produit;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on crée l'id du cart basé sur le user actuel
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CartID";
        m_param.Value = ShoppingCartId;
        m_param.DbType = DbType.String;
        m_param.Size = 36;
        m_cmd.Parameters.Add(m_param);
        
        //on retourne vrai si l'opération réussie
        try
        {
            //on execute la procédure stockée et retourne vrai, si la méthode s'est bien exécutée
            return (LibAccesGenerique.ExecuteNonQuery(m_cmd) != -1);
        }
        catch
        {
            return false;
        }
    }
    //Enlever un produit du shoppingCart
    public static bool SupprimerProduit(string produitID)
    {
        //on obtient l'objet configuré DbCommande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on établit la procédure stockée
        m_cmd.CommandText = "ShoppingCartDeleteProduits";
        //on créer les paramètres
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CartID";
        m_param.Value = ShoppingCartId;
        m_param.DbType = DbType.String;
        m_param.Size = 36;
        m_cmd.Parameters.Add(m_param);
        //on en crée un autre produit
        m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@Produit";
        m_param.Value = produitID;
        m_param.DbType = DbType.Int32;
        m_cmd.Parameters.Add(m_param);
        //on retourne vrai si l'opération réussie
        try
        {
            //on execute la procédure stockée et retourne vrai, si la méthode s'est bien exécutée
            return (LibAccesGenerique.ExecuteNonQuery(m_cmd) != -1);
        }
        catch
        {
            return false;
        }

    }
    //obtenir les produits
    public static DataTable GetProduits()
    {
        //on obtient l'objet configuré DbCommande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on établit la procédure stockée
        m_cmd.CommandText = "ShoppingCartGetProduits";
        //on créer les paramètres
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CartID";
        m_param.Value = ShoppingCartId;
        m_param.DbType = DbType.String;
        m_param.Size = 36;
        m_cmd.Parameters.Add(m_param);
        //on retourne la table avec résultats
        DataTable m_table = LibAccesGenerique.ExecuteCmd(m_cmd);
        return m_table;
    }
    //obtenir la somme total de la commande
    public static decimal GetSommeTotale()
    {
        //on obtient l'objet configuré DbCommande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure stockée
        m_cmd.CommandText = "ShoppingCartGetSommeTotal";
        //on créer les paramètres
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CartID";
        m_param.Value = ShoppingCartId;
        m_param.DbType = DbType.String;
        m_param.Size = 36;
        m_cmd.Parameters.Add(m_param);
        //on retourne la table résultat 
        return decimal.Parse(LibAccesGenerique.ExecuteScalar(m_cmd));
    }
    //méthode pour afficher la quantité totale des articles dans le pannier
    public static int GetQuantiteTotal()
    {
        //on obtient l'objet configuré DbCommande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure stockée
        m_cmd.CommandText = "ShoppingCartGetSommeQte";
        //on crée le paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@CartID";
        m_param.Value = ShoppingCartId;
        m_param.DbType = DbType.String;
        m_param.Size = 36;
        m_cmd.Parameters.Add(m_param);
        //on retourne la table des résultats
        return int.Parse(LibAccesGenerique.ExecuteScalar(m_cmd));
    }
    //compter les vieux shoppingCart
    public static int CompterVieuxCarts(byte jours)
    {
        //on obtient l'objet configuré DbCommande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure stockée
        m_cmd.CommandText = "ShoppingCartCountAncienCarts";
        //on crée un nouveau paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@Jours";
        m_param.Value = jours;
        m_param.DbType = DbType.Byte;
        m_cmd.Parameters.Add(m_param);
        //on execute la commande qui retournera le nombre des vieux shoppingCart
        try
        {
            return Byte.Parse(LibAccesGenerique.ExecuteScalar(m_cmd));
        }
        catch
        {
            return -1;
        }
    }
    //effacer les vieux shoppingCart
    public static bool EffacerVieuxCarts(byte jours)
    {
        //on obtient l'objet configuré DbCommande
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure stockée
        m_cmd.CommandText = "ShoppingCartRemoveAncienCarts";
        //on crée un nouveau paramètre
        DbParameter m_param = m_cmd.CreateParameter();
        m_param.ParameterName = "@Jours";
        m_param.Value = jours;
        m_param.DbType = DbType.Byte;
        m_cmd.Parameters.Add(m_param);
        //execute la commande et retourne vrai si tout est correcte
        try
        {
            LibAccesGenerique.ExecuteNonQuery(m_cmd);
            return true;
        }
        catch
        {
            return false;
        }
    }
    //passer la commande à partir du shoppingCart
    public static string PasserCommande()
    {
        //on obtient l'objet configuré DbCommande
        //étape 1
        DbCommand m_cmd = LibAccesGenerique.CreerCmd();
        //on définit la procédure stockée
        m_cmd.CommandText = "PasserCommande_1_1";
        DbParameter m_param0 = m_cmd.CreateParameter();
        m_param0.ParameterName = "@ClientID";
        m_param0.Value = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey;
        m_param0.DbType = DbType.Int32;
        m_param0.Size = 16;
        m_cmd.Parameters.Add(m_param0);
        LibAccesGenerique.ExecuteNonQuery(m_cmd);
        //étape 2
        DbCommand m_cmd1 = LibAccesGenerique.CreerCmd();
        m_cmd1.CommandText = "PasserCommande_2";
        //on crée un nouveau paramètre
        DbParameter m_param = m_cmd1.CreateParameter();
        m_param.ParameterName = "@CmdID";
        m_param.Value = renvoiId();
        m_param.DbType = DbType.Int32;
        m_cmd1.Parameters.Add(m_param);
        //2ème param
        m_param = m_cmd1.CreateParameter();
        m_param.ParameterName = "@CartID";
        m_param.Value = ShoppingCartId;
        m_param.DbType = DbType.String;
        m_param.Size = 36;
        m_cmd1.Parameters.Add(m_param);
        LibAccesGenerique.ExecuteNonQuery(m_cmd1);
        //étape3
        
        DbCommand m_cmd2 = LibAccesGenerique.CreerCmd();
        m_cmd2.CommandText = "PasserCommande_3";
        DbParameter m_param2 = m_cmd2.CreateParameter();
        m_param2 = m_cmd1.CreateParameter();
        m_param2.ParameterName = "@CartID";
        m_param2.Value = ShoppingCartId;
        m_param2.DbType = DbType.String;
        m_param2.Size = 36;
        m_cmd2.Parameters.Add(m_param2);
        LibAccesGenerique.ExecuteNonQuery(m_cmd2);
         
        //étape 4
        DbCommand m_cmd3 = LibAccesGenerique.CreerCmd();
        m_cmd3.CommandText = "PasserCommande_4";
       //on crée un nouveau paramètre
        DbParameter m_param1 = m_cmd3.CreateParameter();
        m_param1.ParameterName = "@CmdID";
        m_param1.Value = renvoiId();
        m_param1.DbType = DbType.Int32;
        m_cmd3.Parameters.Add(m_param1);
        return LibAccesGenerique.ExecuteScalar(m_cmd3);
    }
    //renvoi id
    public static int renvoiId()
    {
        DbCommand cmd = LibAccesGenerique.CreerCmd();
        cmd.CommandText = "LastIDCmd";
        DataTable m_table = LibAccesGenerique.ExecuteCmd(cmd);
        DataRow m_dr = m_table.Rows[0];
        return int.Parse(m_dr["CmdID"].ToString());
    }
}