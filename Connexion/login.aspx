<%@ Page Title="Connexion" Language="C#" MasterPageFile="~/frontend.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Connexion_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="m_mainContainer" Runat="Server">
    <p><asp:Label ID="info" runat="server" CssClass="Erreur"/></p>
    <article id="m_droite">
        <asp:Login ID="loginControl" runat="server" LoginButtonText="Connexion" TitleText="Connexion à mon compte" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt" DestinationPageUrl="~/index.aspx">
            <LabelStyle BorderStyle="None" />
            <LoginButtonStyle BackColor="#FFC59D" BorderStyle="None" />
            <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
        </asp:Login>
    </article>
</asp:Content>