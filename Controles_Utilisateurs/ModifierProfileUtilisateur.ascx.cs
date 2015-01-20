using System;
using System.Web;
using System.Web.UI.WebControls;

public partial class Controles_Utilisateurs_ModifierProfileUtilisateur : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    //
    public bool Editable
    {
        get
        {
            if (ViewState["editable"] != null)
            {
                return (bool)ViewState["editable"];
            }
            else
            {
                return true;
            }
        }
        set
        {
            ViewState["editable"] = value;   
        }
    }
    //on surcharge la méthode preRender
    protected override void OnPreRender(EventArgs e)
    {
        //trouve et rend visible le bouton de modification
        Button EditButton = FormView1.FindControl("EditButton") as Button;
        if (EditButton != null)
            EditButton.Visible = Editable;
    }
    //
    public string Titre
    {
        get { return Page.Title ; }
        set { Page.Title = value; }
    }
}