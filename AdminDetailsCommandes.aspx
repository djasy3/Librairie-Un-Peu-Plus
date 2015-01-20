<%@ Page Title="Administrer les détails des commandes" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminDetailsCommandes.aspx.cs" Inherits="AdminDetailsCommandes" EnableViewState="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitrePlaceHolder" Runat="Server">
    <span class="AdminTitre">
        Librairie Un peu plus Administration
        <br />
        Commandes
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
    <p><asp:Label ID="countLabel" runat="server" CssClass="AdminError">Salut Monsieur l'Administrateur !</asp:Label></p>
    <ul><li><a href="../index.aspx">retourner à la page d'accueil</a></li></ul>
    <h2>
        <asp:Label ID ="CmdIDLabel" runat="server" CssClass="AdminTitre" Text="Commande #000" />
    </h2>
        <table>
            <tr>
                <td>Somme Totale</td>
                <td><asp:Label ID="SommeTotaleLabel" runat="server" CssClass="PrixProduit"/></td>
            </tr>
            <tr>
                <td>Date de Commande</td>
                <td><asp:TextBox ID="DateDeCmdTextBox" runat="server"/></td>
            </tr>
            <tr>
                <td>Date de Livraison</td>
                <td><asp:TextBox ID ="DateDeLivraisonTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Status</td>
            </tr>
            <tr>
                <td>Vérifiée</td>
                <td><asp:CheckBox ID="VerifiECheck" runat="server" /></td>
            </tr>
            <tr>
                <td>Complétée</td>
                <td><asp:CheckBox ID ="CompletECheck" runat="server" /></td>
            </tr>
            <tr>
                <td>Annulée</td>
                <td><asp:CheckBox ID="AnnulECheck" runat="server" /></td>
            </tr>
            <tr>
                <td>Commentaires</td>
                <td><asp:TextBox ID="CommentsTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Nom du client</td>
                <td><asp:TextBox ID="NomClientTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Email du client</td>
                <td><asp:TextBox ID="EmailClientTextBox" runat="server" /></td>
            </tr>
            <tr>
                <td>Addresse de Livraison</td>
                <td><asp:TextBox ID="AdrsLivraisonTextBox" runat="server" /></td>
            </tr>
        </table>
        <table>
            <tr>
                <td><asp:Button ID="editButton" runat="server" Text="Modifier" OnClick="editButton_Click"/></td>
                <td><asp:Button ID="updateButton" runat="server" Text="Mettre à jour" OnClick="updateButton_Click" /></td>
                <td><asp:Button ID="cancelButton" runat="server" Text="Annuler" OnClick="cancelButton_Click"/></td>
            </tr>
            <tr>
                <td><asp:Button ID="marqueVerifiEButton" runat="server" Text="Cmd Vérifiée" OnClick="marqueVerifiEButton_Click" /></td>
                <td><asp:Button ID="marqueCompletE" runat="server" Text="Cmd Completée" OnClick="marqueCompletE_Click"/></td>
                <td><asp:Button ID="marqueAnnulE" runat="server" Text="Cmd Annulée" OnClick="marqueAnnulE_Click"/></td>
            </tr>
        </table>
    <p>La commande contient ces produits</p>
    <asp:GridView ID="m_grid" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="ProduitID" HeaderText="ID Produit" ReadOnly="True" SortExpression="ProduitID" />
            <asp:BoundField DataField="ProduitTitre" HeaderText="Nom Produit" ReadOnly="True" SortExpression="ProduitTitre" />
            <asp:BoundField DataField="Quantite" HeaderText="Quantité" ReadOnly="True" SortExpression="Quantite" />
            <asp:BoundField DataField="CoutUnitaire" HeaderText="Cout Unitaire" ReadOnly="True" SortExpression="CoutUnitaire" />
            <asp:BoundField DataField="SousTotal" HeaderText="Sous Total" ReadOnly="True" SortExpression="SousTotal" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#242121" />
    </asp:GridView>
</asp:Content>

