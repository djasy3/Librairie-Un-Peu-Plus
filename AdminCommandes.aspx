<%@ Page Title="Administrer les commandes" Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="AdminCommandes.aspx.cs" Inherits="AdminCommandes" %>

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
    <table>
        <tr>
            <td>Montrer les commandes récentes</td>
            <td></td>
            <td><asp:Button ID="ByrecentGo" runat="server" Text="afficher" CausesValidation="false" OnClick="ByrecentGo_Click" /></td>
        </tr>
        <tr>
            <td>Montrer les commandes passées entre</td>
            <td><asp:TextBox ID="jourDebutTextBox" runat="server" Width="75px"/>et<asp:TextBox ID="jourFinTextBox" runat="server" Width="75px"/></td>
            <td><asp:Button ID="ByDate" runat="server" Text="afficher" OnClick="ByDate_Click"/></td>
        </tr>
        <tr>
            <td>Montrer toutes les commandes non vérifiées et non annulées</td>
            <td></td>
            <td><asp:Button ID="NonVerifieGo" runat="server" Text="afficher" CausesValidation="false" OnClick="NonVerifieGo_Click"/></td>
        </tr>
        <tr>
            <td>Montrer toutes les commandes vérifiées, non complétée</td>
            <td></td>
            <td><asp:Button ID="NonCompleteGo" runat="server" Text="afficher" CausesValidation="false" OnClick="NonCompleteGo_Click"/></td>
        </tr>
    </table>
    <p><asp:Label ID="errorLabel" runat="server" CssClass="AdminError" EnableViewState="false" />
        <asp:RangeValidator ID="DateDebutValidator" runat="server" ErrorMessage="Date de début invalide" ControlToValidate="jourDebutTextBox" Display="None" MaximumValue="1/1/2017" MinimumValue="1/1/1999" Type="Date" />
        <asp:RangeValidator ID="DateFinValidator" runat="server" ErrorMessage="Date de fin invalide" ControlToValidate="jourFinTextBox" Display="None" MaximumValue="1/1/2017" MinimumValue="1/1/1999" Type="Date"/>
        <asp:CompareValidator ID="CompareDateValidator" runat="server" ErrorMessage="La date de fin ne doit pas être supérieure à la date de début" ControlToCompare="jourFinTextBox" ControlToValidate="jourDebutTextBox" Display="None" Operator="LessThan" Type="Date" />
        <asp:ValidationSummary ID="ValidationSummary" runat="server" CssClass="AdminError" HeaderText="Erreur lors de la validation des données:" />
    <asp:GridView ID="m_grid" runat="server" AutoGenerateColumns="False" DataKeyNames="CmdID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="m_grid_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="CmdID" HeaderText="ID Commande" ReadOnly="True" SortExpression="CmdID" />
            <asp:BoundField DataField="DateDeCmd" HeaderText="Date de commande" ReadOnly="True" SortExpression="DateDeCmd" />
            <asp:BoundField DataField="DateDeLivraison" HeaderText="Date de livraison" ReadOnly="True" SortExpression="DateDeLivraison" />
            <asp:CheckBoxField DataField="VerifiE" HeaderText="Verifié" ReadOnly="True" SortExpression="VerifiE" />
            <asp:CheckBoxField DataField="CompletE" HeaderText="Complété" ReadOnly="True" SortExpression="CompletE" />
            <asp:CheckBoxField DataField="AnnulE" HeaderText="Annulé" ReadOnly="True" SortExpression="AnnulE" />
            <asp:BoundField DataField="NomClient" HeaderText="Nom du client" ReadOnly="True" SortExpression="NomClient" />
            <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Selectionner" />
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

