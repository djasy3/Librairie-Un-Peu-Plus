using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Details_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string numlivre;
        try
        {
            numlivre = Request.QueryString["NumLivre"];//l'id passé par le client
        }
        catch (Exception)
        {
            throw;
        }
        //on charge les détails sur le produits
        DescriptionNew detailLivre = PresentationLivres.GetDetails(numlivre);
        //on vérifie si le produit existe
        if (detailLivre.Auteur != null)
        {
            //on charge la page des données
            ChargePage(detailLivre);
        }
    }
    //fonction qui charge les données sur la page description
    private void ChargePage(DescriptionNew detail)
    {
        //on affiche sur la page les données
        LabelTitre.Text = detail.Titre;
        LabelAuteur.Text = detail.Auteur;
        LabelAnEdition.Text = detail.Date.ToLongDateString();
        LabelIsbn.Text = detail.Isbn;
        LabelPrix.Text = String.Format("{0:c}",detail.Prix);
        LabelDescription.Text = detail.Description;
        LabelCategorie.Text = detail.Categorie;
        LabelMaisonEdition.Text = detail.MaisonEdition;
        LabelType.Text = detail.Type;
        etat.Visible = false;

        //on fixe le titre de la page en fonctin du produit selectionné
        this.Title = LibConfig.NomSite + " : " + detail.Titre;
    }
    //
    protected void m_addShCart_Click(object sender, EventArgs e)
    {
        string numLivre = Request.QueryString["NumLivre"];
        //on ajoute le livre au panier
        etat.Visible = true;
        etat.Text = ShoppingCartAccess.AjouterProduit(numLivre) ? "votre livre a été ajouté avec succès":"l'ajout de votre livre à échoué";
    }
}