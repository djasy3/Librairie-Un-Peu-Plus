using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminCommandes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //on liste les récentes commandes
    protected void ByrecentGo_Click(object sender, EventArgs e)
    {
        //on charge les données dans le grid
        m_grid.DataSource = CommandeAccess.GetByRecent();
        //on rafraichit le grid
        m_grid.DataBind();
    }
    //on affiche les commandes envoyée entres un interval de temps données
    protected void ByDate_Click(object sender, EventArgs e)
    {
        //on vérifie si la page est valide(parce qu'on fait une vérification au niveau des dates) au cas ou
        //javascript serait désactivé au niveau du navs
        if ((Page.IsValid) && (jourDebutTextBox.Text + jourFinTextBox.Text != ""))
        {
            //on obtient les dates
            string dateDebut = jourDebutTextBox.Text;
            string dateFin = jourFinTextBox.Text;
            //on charge les données dans le grid avec les données requises
            m_grid.DataSource = CommandeAccess.GetByDate(dateDebut, dateFin);
        }
        else { errorLabel.Text = "Veuillez entrer les dates valides"; }
        //on rafraichit le grid
        m_grid.DataBind();
    }
    //on affiche les commandes non vérifiées  et non annulées
    protected void NonVerifieGo_Click(object sender, EventArgs e)
    {
        //on charge le grid avec les données fournies
        m_grid.DataSource = CommandeAccess.GetNonVerifieNonAnnulE();
        //on rafraichi le grid
        m_grid.DataBind();
    }
    //on affiches les commandes vérifiées mais non complétée
    protected void NonCompleteGo_Click(object sender, EventArgs e)
    {
        //on charge le grid avec les données fournies
        m_grid.DataSource = CommandeAccess.GetVerifieNonComplete();
        //on rafraichi le grid
        m_grid.DataBind();

    }
    //on charge les détails de la commande sélectionnée
    protected void m_grid_SelectedIndexChanged(object sender, EventArgs e)
    {
        string destination = String.Format("AdminDetailsCommandes.aspx?CmdID={0}",m_grid.DataKeys[m_grid.SelectedIndex].Value.ToString());
        Response.Redirect(destination);
    }
}