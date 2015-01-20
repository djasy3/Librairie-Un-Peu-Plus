<%@ Page Title="LUP:Modifier votre Profile" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Connexion_Profile" %>

<%@ Register src="../Controles_Utilisateurs/ModifierProfileUtilisateur.ascx" tagname="ModifierProfileUtilisateur" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <h1>
        <span>Modifier les infos de votre compte</span>
    </h1>
    <uc1:ModifierProfileUtilisateur ID="ModifierProfileUtilisateur1" runat="server" />
</asp:Content>

