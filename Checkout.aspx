<%@ Page Title="" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="Checkout.aspx.cs" Inherits="Checkout" %>

<%@ Register Src="~/Controles_Utilisateurs/ModifierProfileUtilisateur.ascx" TagPrefix="uc1" TagName="ModifierProfileUtilisateur" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <asp:Label ID="labelTitre" runat="server" Text="Confirmer votre commande" CssClass="AdminTitre"/><br />
    <asp:Label ID="label" runat="server" Text="Commande #" Font-Bold="true" Font-Size="Larger"/>
    <asp:Label ID="NumCommande" runat="server" Font-Bold="true" Font-Size="Larger"/>
    <asp:GridView ID="m_grid" runat="server" AutoGenerateColumns="False" DataKeyNames="NumLivre" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <Columns>
            <asp:BoundField DataField="Titre" HeaderText="Titre" ReadOnly="true" SortExpression="Titre" />
            <asp:BoundField DataField="Quantite" HeaderText="Quantite" ReadOnly="true" SortExpression="Quantite"/>
            <asp:BoundField DataField="prix" HeaderText="Prix" DataFormatString="{0:c}" ReadOnly="true" SortExpression="CoutUnitaire"/>
            <asp:BoundField DataField="SubTotal" HeaderText="Sous-total" ReadOnly="true" DataFormatString="{0:c}" SortExpression="SousTotal"/>
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
    <asp:Label ID="etiquette" runat="server" Text="Somme totale" Font-Bold="true" ForeColor="OrangeRed"/>:&nbsp;<asp:Label ID="sommeTotale" runat="server" Text="Somme totale" Font-Bold="true"></asp:Label><br /><br />
    <uc1:ModifierProfileUtilisateur runat="server" ID="ModifierProfileUtilisateur" Editable="false" Titre="Modifier vos informations personnelles" /><br />
    <asp:Label ID="labelInfo" runat="server" ForeColor="OrangeRed" Font-Bold="true"/><br /><br />
    <asp:Button ID="validerCmd" runat="server" Text="Confirmer votre commande" OnClick="validerCmd_Click" BackColor="#478F8F" BorderStyle="None" CssClass="btn"/>
</asp:Content>

