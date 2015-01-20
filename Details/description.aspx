<%@ Page Title="Nouveau Livre Descrption" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="description.aspx.cs" Inherits="description" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <h2>Détail sur le livre</h2>
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="etat" runat="server" Text="etat" CssClass="Erreur"></asp:Label></td>
        </tr>
        <tr>
            <td width="15%"><b>Titre</b></td>
            <td><asp:Label ID="LabelTitre" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Auteur</b></td>
            <td><asp:Label ID="LabelAuteur" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Date d'apparution</b></td>
            <td><asp:Label ID="LabelDateApp" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><b>ISBN</b></td>
            <td><asp:Label ID="LabelIsbn" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Prix</b></td>
            <td><asp:Label ID="LabelPrix" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><b>Description</b></td>
            <td><asp:Label ID="LabelDescription" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Button ID="m_addShCart" runat="server" Text="Ajouter au pannier" OnClick="m_addShCart_Click1" BackColor="#478F8F" BorderStyle="None" CssClass="btn"></asp:Button></td>
        </tr>
    </table>
</asp:Content>

