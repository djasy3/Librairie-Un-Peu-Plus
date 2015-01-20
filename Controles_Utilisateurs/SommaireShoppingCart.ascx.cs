using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controles_Utilisateurs_SommaireShoppingCart : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //remplir le contenu du shopping cart à la phase de pré-rendement
    protected void Page_PreRender(object sender, EventArgs e)
    {
        //méthode pour remplir le datalist
        ChargerControl();
    }
    //chargement des données dans le controle(ici datalist)
    private void ChargerControl()
    {
        //obtenir le contenu du shoppingCart
        System.Data.DataTable m_table = ShoppingCartAccess.GetProduits();
        //on vérifie si le shoppingCart est vide
        if (m_table.Rows.Count == 0)
        {
            LabelSommaireShpcart.Text = "Votre pannier est vide";
            LabelSommeTotal.Text = String.Format("{0:c}", 0);
            LabelQteTotale.Text = "0";
            LienVoirCart.Visible = false;
        }
        //si il y'a du contenu dans le shoppingCart
        else
        {
            //on charge le contenu du ShoppingCart
            LienVoirCart.Visible = true;
            //on configure les controls
            LabelSommaireShpcart.Visible = false;
            //on affiche la somme total
            decimal m_somme = ShoppingCartAccess.GetSommeTotale();
            LabelSommeTotal.Text = String.Format("{0:c}",m_somme);
            //on affiche la quantité totale des articles se trouvant dans le pannier
            int m_Qte = ShoppingCartAccess.GetQuantiteTotal();
            LabelQteTotale.Text = m_Qte.ToString();
        }
    }
    //méthode qui permet de ne pas afficher le sommaire du shoppingCart s'il on est sur la page du ShoppingCart
    //à l'étape d'initiation de la page
    protected void Page_Init(object sender, EventArgs e)
    {
        //on obtient la page actuelle
        string page = Request.AppRelativeCurrentExecutionFilePath;
        //si nous somme sur la page du shoppingCart, on n'affiche pas le sommaire
        if (String.Compare(page, "~/ShoppingCart.aspx", true) == 0)
            this.Visible = false;
        else
            this.Visible = true;
    }
}