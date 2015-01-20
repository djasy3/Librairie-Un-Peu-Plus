using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //on charge le control(gridview) à l'initialisation de la page seulement
        if (!IsPostBack)
            chargerControl();
    }
    //méthode qui charge les données dans le Gridview du shoppingCart
    private void chargerControl()
    {
        //on obtient les données du shoppingCart
        DataTable m_table = ShoppingCartAccess.GetProduits();
        //si le pannier est vide
        if (m_table.Rows.Count == 0)
        {
            LabelTitre.Text = "Votre Pannier est Vide";
            m_grid.Visible = false;
            updateButton.Enabled = false;
            passerCmdButton.Enabled = false;
            LabelSommeTotale.Text = String.Format("{0:c}", 0);
        }
        //si le pannier contient quelque choses
        else
        {
            //charge le gridview des éléments se trouvant dans le shoppingCart
            m_grid.DataSource = m_table;
            m_grid.DataBind();
            //configuration du gridview
            LabelTitre.Text = "Vous disposez quelques produits dans votre pannier";
            m_grid.Visible = true;
            updateButton.Enabled = true;
            passerCmdButton.Enabled = true;
            //on affiche la somme totale
            decimal somme = ShoppingCartAccess.GetSommeTotale();
            LabelSommeTotale.Text = String.Format("{0:c}",somme);
            
        }
    }
    //enlever les livres du shoppingCart
    protected void m_grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //on obtient l'index de la ligne qui veut être enlevée
        int indexLigne = e.RowIndex;
        //l'ID du produit qui va être enlevé
        string produitId = m_grid.DataKeys[indexLigne].Value.ToString();
        //on enleve le produit du pannier
        bool reussite = ShoppingCartAccess.SupprimerProduit(produitId);
        //affiche l'état après l'action
        LabelEtat.Text = reussite ? "Le livre a été enlevé avec succès" : "Une erreur est survenue lors de la suppression du livre";
        //on recharge le gridView
        chargerControl();
    }
    //on fait une mise à jour des livres dans le pannier
    protected void updateButton_Click(object sender, EventArgs e)
    {
        //nombre de ligne dans le GridView
        int ligneCount = m_grid.Rows.Count;
        //sauvegardera une ligne du GridView
        GridViewRow m_gridLigne;
        //referencera une le textBox(quantité) au gridView
        TextBox qteTxtBox;
        //variable pour sauvegarder le num du livre et la quantité
        string produitId;
        int qte;
        //au cas ou la suppression du produit aurait réussie
        bool reussite = true;
        //parcourir les ligne du gridview
        for (int i = 0; i < ligneCount; i++)
        {
            //on obtient la ligne
            m_gridLigne = m_grid.Rows[i];
            // l'id du livre qu'on veut enlever du pannier
            produitId = m_grid.DataKeys[i].Value.ToString();
            //on obtient la quantité des livres à mettre à jour dans la ligne
            qteTxtBox = (TextBox)m_gridLigne.FindControl("editQuantite");
            //on obtient la quantité, en étant prudent au cas ou il y'aurait un bug
            if (Int32.TryParse(qteTxtBox.Text, out qte))
            {
                //mise à jour de la quantité des livres
                reussite = reussite && ShoppingCartAccess.MajProduit(produitId, qte);
            }
            else
            {
                //si la conversion n'a pas réussi
                reussite = false;
            }
            //on affiche un message si le pannier a été mis à jour!
            LabelEtat.Text = reussite ? "Votre pannier a été mis à jour avec succès" : "La mise à jour de la quantité des certains livres a échoué, verifiez dans votre pannier!";
        }
        //on recharge le gridView
        chargerControl();
    }
    //passer la commande
    protected void passerCmdButton_Click(object sender, EventArgs e)
    {
        //on obtient la somme total de la commande
        decimal somme = ShoppingCartAccess.GetSommeTotale();
        //on se redirige vers la page checkout
        Response.Redirect("Checkout.aspx");
    }
}