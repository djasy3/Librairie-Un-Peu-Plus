using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class description : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string numlivre;
            numlivre = Request.QueryString["NumLivre"];//l'id passé par le client
        //on charge les détails sur le produits
        DescriptionNew dnlivre = PresentationLivres.GetDescriptionNew(numlivre);
        //on vérifie si le produit existe
        if (dnlivre.Auteur != null)
        {
            //on charge la page des données
            ChargePage(dnlivre);
        }
    }
    //fonction qui charge les données sur la page description
    private void ChargePage(DescriptionNew dn)
    {
        //on affiche sur la page les données
        LabelTitre.Text = dn.Titre;
        LabelAuteur.Text = dn.Auteur;
        LabelDateApp.Text = dn.Date.ToLongDateString();
        LabelIsbn.Text = dn.Isbn;
        LabelPrix.Text = dn.Prix;
        LabelDescription.Text = dn.Description;
        etat.Visible = false;
        //on fixe le titre de la page en fonctin du produit selectionné
        this.Title = LibConfig.NomSite +" : "+ dn.Titre;
    }
    protected void m_addShCart_Click(object sender, EventArgs e)
    {
        
    }
    protected void m_addShCart_Click1(object sender, EventArgs e)
    {
        string numLivre = Request.QueryString["NumLivre"];
        //on ajoute le livre au panier
        etat.Visible = true;
        etat.Text = ShoppingCartAccess.AjouterProduit(numLivre) ? "Votre livre a été ajouté avec succès" : "L'ajout de votre livre à échoué";
    }
}