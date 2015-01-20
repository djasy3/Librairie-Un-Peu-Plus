using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminShoppingCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //compter les vieux shopping Carts
    protected void countButton_Click(object sender, EventArgs e)
    {
        byte jours = byte.Parse(listeDesJours.SelectedItem.Value);
        int vieuxItems = ShoppingCartAccess.CompterVieuxCarts(jours);
        //en cas d'erreur de comptage
        if (vieuxItems == -1)
            countLabel.Text = "Impossible de compter les vieux shopping carts(panniers).";
        else if (vieuxItems == 0)
            countLabel.Text = "Il n'y a pas des vieux shopping carts pour l'instant.";
        else
            countLabel.Text = "Il y a "+ vieuxItems.ToString()+" vieux shopping carts.";
    }
    //effacer les vieux shopping carts
    protected void deleteButton_Click(object sender, EventArgs e)
    {
        byte jours = byte.Parse(listeDesJours.SelectedItem.Value);
        ShoppingCartAccess.EffacerVieuxCarts(jours);
        countLabel.Text = "Les vieux shopping carts ont été effacé de la base de données";
    }
}