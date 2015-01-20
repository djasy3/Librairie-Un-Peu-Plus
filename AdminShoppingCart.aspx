<%@ Page Title="Administrer le shopping cart" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminShoppingCart.aspx.cs" Inherits="AdminShoppingCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitrePlaceHolder" Runat="Server">
    <span class="AdminTitre">
        Librairie Un peu plus Administration
        <br />
        ShoppingCart
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="AdminPlaceHolder" Runat="Server">
    <p>
        <asp:Label ID="countLabel" runat="server" CssClass="AdminError">Salut Monsieur l'Administrateur !</asp:Label>
    </p>
        <ul>
            <li><a href="../index.aspx">retourner à la page d'accueil</a></li>
        </ul>
    <p>
        <span>Combien de jours?&nbsp;</span>
        <asp:DropDownList ID="listeDesJours" runat="server">
            <asp:ListItem Value="0">Tous les shopping Carts(Paniers)</asp:ListItem>
            <asp:ListItem Value="1">Un seul</asp:ListItem>
            <asp:ListItem Value="10" Selected="True">Dix</asp:ListItem>
            <asp:ListItem Value="30">Trente</asp:ListItem>
            <asp:ListItem Value="60">Soixante</asp:ListItem>
            <asp:ListItem Value="90">Nonante</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Button ID="countButton" runat="server" Text="Compter les vieux Shopping Carts" OnClick="countButton_Click"/>
        <asp:Button ID="deleteButton" runat="server" Text="Effacer les vieux Shopping Carts" OnClick="deleteButton_Click"/>
    </p>
</asp:Content>

