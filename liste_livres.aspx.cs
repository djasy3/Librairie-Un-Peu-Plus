using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class liste_livres : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //on remplit notre dataliste
        m_liste.DataSource = PresentationLivres.GetListeLivres();
        m_liste.DataBind();
    }
}