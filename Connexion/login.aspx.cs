using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Connexion_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //méthode pour remplir le datalist et faire des vérification
        verifier();
    }
    //on active le lien créer compte si il y'a un item dans le shopping cart, si non le client n'a pas le droit de se connecter
    public void verifier()
    {
        //obtenir le contenu du shoppingCart
        System.Data.DataTable m_table = ShoppingCartAccess.GetProduits();
        //on vérifie si le shoppingCart est vide
        if (m_table.Rows.Count == 0)
        {
            info.Visible = true;
            info.Text = "Vous devez au moins avoir un article dans votre pannier pour créer un compte !";
        }
        else
        {
            info.Visible = false;
            loginControl.CreateUserText = "Vous n'avez pas de compte?";
            loginControl.CreateUserUrl = "~/Connexion/account.aspx";
        }
    }
}