using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminDetailsCommandes : System.Web.UI.Page
{
    //on configure le formulaire
    protected void Page_Load(object sender, EventArgs e)
    {
        //on vérifie si l'on doit afficher les détails de commande
        if(!Page.IsPostBack && Request.QueryString["CmdID"] != null)
        {
            string cmdId = Request.QueryString["CmdID"];
            //on charge les données dans le grid
            this.ChargePage(cmdId);
            //on configure le mode d'édition
            this.SetEditMode(false);
        }
    }
    //on charge les données dans le grid
    private void ChargePage(string cmdId)
    {
        //on obtient les info sur la commande
        InfoCommande infoCmd = CommandeAccess.GetInfo(cmdId);
        //on charge les données sur les controles
        CmdIDLabel.Text = "Commande #" + cmdId;
        SommeTotaleLabel.Text = String.Format("{0:c}", infoCmd.SommeTotale);
        DateDeCmdTextBox.Text = infoCmd.DateDeCmd;
        DateDeLivraisonTextBox.Text = infoCmd.DateDeLivraison;
        VerifiECheck.Checked = infoCmd.VerifiE;
        CompletECheck.Checked = infoCmd.CompletE;
        AnnulECheck.Checked = infoCmd.AnnulE;
        CommentsTextBox.Text = infoCmd.Commentaires;
        NomClientTextBox.Text = infoCmd.NomClient;
        //EmailClientTextBox.Text = infoCmd.EmailClient;
        AdrsLivraisonTextBox.Text = infoCmd.AddresseDeLivraison;
        //par défaut le bouton d'édition est activée, tansdisque les deux autre désactivées
        editButton.Enabled = true;
        cancelButton.Enabled = false;
        updateButton.Enabled = false;
        //maintenant on decide lesquelles des boutons des trois autre boutton doivent cochées selon les circonstances
        if (AnnulECheck.Checked || CompletECheck.Checked)
        {
            //si la commande était annulé ou complétée
            marqueVerifiEButton.Enabled = false;
            marqueAnnulE.Enabled = false;
            marqueCompletE.Enabled = false;
        }
        else if (VerifiECheck.Checked)
        {
            //si la commande n'était pas annulée mais vérifié
            marqueVerifiEButton.Enabled = false;
            marqueAnnulE.Enabled = true;
            marqueCompletE.Enabled = true;
        }
        else
        {
            //si la commande n'était pas annulée ou n'est pas encore completée
            marqueVerifiEButton.Enabled = true;
            marqueAnnulE.Enabled = false;
            marqueCompletE.Enabled = true;
        }
        //on remplit le grid avec les données
        m_grid.DataSource = CommandeAccess.GetDetails(cmdId);
        m_grid.DataBind();
    }
    //on définit le mode éditable pour les informations!
    public void SetEditMode(bool enable)
    {
        DateDeCmdTextBox.Enabled = enable;
        DateDeLivraisonTextBox.Enabled = enable;
        VerifiECheck.Enabled = enable;
        CompletECheck.Enabled = enable;
        AnnulECheck.Enabled = enable;
        CommentsTextBox.Enabled = enable;
        NomClientTextBox.Enabled = enable;
        //EmailClientTextBox.Enabled = enable;
        AdrsLivraisonTextBox.Enabled = enable;
        editButton.Enabled = !enable;
        updateButton.Enabled = enable;
        cancelButton.Enabled = enable;

    }
    //entrer dans le mode d'édition
    protected void editButton_Click(object sender, EventArgs e)
    {
        string cmdId = Request.QueryString["CmdID"];
        this.ChargePage(cmdId);
        this.SetEditMode(true);
    }
    //mode de mise à jour
    protected void updateButton_Click(object sender, EventArgs e)
    {
        //on sauvegarde les données dans la base données à travers la structure
        InfoCommande infoCmd = new InfoCommande();
        string cmdId = Request.QueryString["CmdID"];
        infoCmd.CmdID = Int32.Parse(cmdId);
        infoCmd.DateDeCmd = DateDeCmdTextBox.Text;
        infoCmd.DateDeLivraison = DateDeLivraisonTextBox.Text;
        infoCmd.VerifiE = VerifiECheck.Checked;
        infoCmd.CompletE = CompletECheck.Checked;
        infoCmd.AnnulE = AnnulECheck.Checked;
        infoCmd.Commentaires = CommentsTextBox.Text;
        infoCmd.NomClient = NomClientTextBox.Text;
        //infoCmd.EmailClient = EmailClientTextBox.Text;
        infoCmd.AddresseDeLivraison = AdrsLivraisonTextBox.Text;
        //on essaye de mettre à jour les informations de la commande
        try
        {
            //màj de la commande
            CommandeAccess.MajCmd(infoCmd);
        }
        catch
        {
            //s'il y a une erreur on l'ignore
        }
        //on quitte le mode d'édition
        this.SetEditMode(false);
        //on charge les données dans le grid
        this.ChargePage(cmdId);
    }
    //le mode d'annulation
    protected void cancelButton_Click(object sender, EventArgs e)
    {
        string cmdId = Request.QueryString["CmdID"];
        this.ChargePage(cmdId);

    }
    //marquer le boutton comme vérifié
    protected void marqueVerifiEButton_Click(object sender, EventArgs e)
    {
        string cmdId = Request.QueryString["CmdID"];
        //marquer la commande comme vérifiée
        CommandeAccess.MarqueCmdVerifiE(cmdId);
        //on met à jour le grid
        this.ChargePage(cmdId); 
    }
    //marquer la commande comme complétée
    protected void marqueCompletE_Click(object sender, EventArgs e)
    {
        string cmdId = Request.QueryString["CmdID"];
        //marquer la commande comme completée
        CommandeAccess.MarqueCmdCompletE(cmdId);
        //on met à jour le grid
        this.ChargePage(cmdId);
    }
    //marquer la commande comme annulée
    protected void marqueAnnulE_Click(object sender, EventArgs e)
    {
        string cmdId = Request.QueryString["CmdID"];
        //m
        CommandeAccess.MarquerCmdAnnulE(cmdId);
        //on met à jour le grid
        this.ChargePage(cmdId);
    }
}