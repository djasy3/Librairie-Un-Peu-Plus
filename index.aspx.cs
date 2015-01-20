using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public partial class Index : System.Web.UI.Page
{
    public Index()
    {
        //cstor
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //on obtient la liste des livres de la page index grace à la methode GetIndex
        ListIndex.DataSource = PresentationLivres.GetIndex();
        //on charge les données sur la liste
        ListIndex.DataBind();
    }
    /*
    protected void m_addShCart_Click(object sender, EventArgs e)
    {
        ajouterAuPannier();
    }
    //
    protected void m_addShCart_Click1(object sender, EventArgs e)
    {
        ajouterAuPannier();
    }
    //methode pour ajouter au pannier
    protected void ajouterAuPannier()
    {
        string numLivre = Request.QueryString["NumLivre"];
        //on ajoute le livre au panier
        ShoppingCartAccess.AjouterProduit(numLivre);
    }
     */
}