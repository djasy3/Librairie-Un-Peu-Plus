<%@ Page Title="" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="details.aspx.cs" Inherits="Details_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="etat" runat="server" Text="etat" CssClass="Erreur"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center"><b><asp:Label ID="LabelTitre" runat="server" Text="Label" /></b></td>
            <td><asp:Button ID="m_addShCart" runat="server" OnClick="m_addShCart_Click" Text="Ajouter au pannier" BackColor="#478F8F" BorderStyle="None" CssClass="btn"></asp:Button></td>
        </tr>
        <tr>
            <td width="20%"><b>Auteur</b></td>
            <td><asp:Label ID="LabelAuteur" runat="server" Text="Label"/></td>
            <td><b>Catégorie</b></td>
            <td><asp:HyperLink ID="lien_categorie" runat="server" NavigateUrl='<%# Liens.Categorie("LabelCategorie") %>' ToolTip='<%# HttpUtility.HtmlEncode(Eval("Categorie").ToString()) %>' ><asp:Label ID="LabelCategorie" runat="server" Text="Label" /></asp:HyperLink></td></tr><tr>
            <td><b>Maison d'édition</b></td><td><asp:Label ID="LabelMaisonEdition" runat="server" Text="Label" /></td>
            <td><b>Type</b></td><td><asp:Label  ID="LabelType" runat="server" Text="Label"/></td>
        </tr>
        <tr>
            <td><b>Année d'édition</b></td><td><asp:Label ID="LabelAnEdition" runat="server" Text="Label"/></td>
            <td><b>Prix</b></td><td><asp:Label ID="LabelPrix" runat="server" Text="Label"/></td>
        </tr>
        <tr>
            <td><b>ISBN</b></td><td><asp:Label ID="LabelIsbn" runat="server" Text="Label"/></td>
        </tr>
        <tr>
            <td colspan="3" style="text-align: center"><b>Description</b></td></tr><tr>
            <td colspan="3"><asp:Label ID="LabelDescription" runat="server" Text="Label"/></td>
        </tr>
    </table>
</asp:Content>

