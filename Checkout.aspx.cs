using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            ChargePage();
    }
    //on charge les données dans le controle
    public void ChargePage()
    {
        //on obtient les données du shopping cart
        DataTable m_dt = ShoppingCartAccess.GetProduits();
        //on charge le grid avec les données du shopping cart
        m_grid.DataSource = m_dt;
        m_grid.DataBind();
        m_grid.Visible = true;
        //on affiche la somme totale
        decimal somme = ShoppingCartAccess.GetSommeTotale();
        sommeTotale.Text = String.Format("{0:c}", somme);
        //on vérifie si le client a entré des information requises
        bool addresseOk = true;
        bool carteOk = true;
        if (Profile.Adresse1 + Profile.Adresse2 == ""
            || Profile.ZoneDeLivraison == ""
            || Profile.ZoneDeLivraison == "Veuillez selectionner"
            || Profile.Pays == "")
        {
            addresseOk = false;
        }
        if(Profile.CarteDeCredit =="")
        {
            carteOk = false;
        }
        //on désactive le boutton si les informations ne sont pas encore fournies
        if (!addresseOk)
        {
            if (!carteOk)
            {
                labelInfo.Text = "Vous devez entrer une adresse valide avant de confirmer votre commande.";
            }
        }
        else if (!carteOk)
        {
            labelInfo.Text = "Vous devez enregistrer une carte de crédit avant de confirmer votre commande";
        }
        else
        {
            labelInfo.Text = "Veuillez confirmer que les informations entrées ci-dessus sont correctes<br/>Imprimez cette page pour plus d'amples renseignements!";
            NumCommande.Text = ShoppingCartAccess.renvoiId().ToString();
        }
        validerCmd.Visible = addresseOk && carteOk;
    }
    //boutton valider commande
    protected void validerCmd_Click(object sender, EventArgs e)
    {
        decimal somme = ShoppingCartAccess.GetSommeTotale();
        //on créer la commande et son stock son numéro
        string cmdId = ShoppingCartAccess.PasserCommande();
        string nomCmd = LibConfig.NomSite + "Commande " + cmdId;
        //on redirige la page vers la page d'acceuille
        Response.Redirect("CommandeConfirmee.aspx");
    }
}