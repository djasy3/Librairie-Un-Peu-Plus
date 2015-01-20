<%@ Page Title="Tous les livres" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="liste_livres.aspx.cs" Inherits="liste_livres" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <h1>Voici la liste de tous les livres diponibles pour le moment</h1>
    <asp:DataList ID="m_liste" runat="server" DataKeyNames="Numlivre" RepeatColumns="2" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Liens.Livres(Eval("Numlivre").ToString()) %>' Text='<%# HttpUtility.HtmlEncode(Eval("titre").ToString()) %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("description").ToString()) %>'>></asp:HyperLink>
        </ItemTemplate>
        <SelectedItemStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
    </asp:DataList>
</asp:Content>

