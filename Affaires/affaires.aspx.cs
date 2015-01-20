using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Affaires_Affaires : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //liste tous les livres sur les affaires
        ListAffaires.DataSource = PresentationLivres.GetAffaires();
        //on les charges dans la liste
        ListAffaires.DataBind();
    }
}